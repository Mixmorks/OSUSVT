using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
/*
CREATE TABLE telemetry (
        id INTEGER NOT NULL AUTO_INCREMENT,
        epochtime BIGINT,
        time CHAR(16) NOT NULL,
        latitude NUMERIC(12, 6) NOT NULL,
        longitude NUMERIC(12, 6) NOT NULL,
        elevation NUMERIC(10, 4) NOT NULL,
        velocity NUMERIC(10, 4) NOT NULL,
        mainpacksoc NUMERIC(10, 4) NOT NULL,
        mainpackcurrent NUMERIC(10, 4) NOT NULL,
        voltagemainpackcurrent NUMERIC(10, 4) NOT NULL,
        arraycurrent NUMERIC(10, 4) NOT NULL,
        auxpackvoltage NUMERIC(10, 4) NOT NULL,
        PRIMARY KEY (id)
)
*/

namespace SQL
{
    //Static Information for easy changes
    class connection
    {
        public const string sql_username = "solar";
        public const string sql_password = "Phenix";
        public const string sql_database = "solarcar";
        public static string sql_root = "OSUSVT"; //Default, Prompts if cannot be configured automatically

        public const string sql_remote_username = "svtremote";
        public const string sql_remote_password = "Phenix";

    }
    class SQLclass
    {
        private static MySqlConnection svt_telemetry = new MySqlConnection(
                                       "user id="+connection.sql_username+";" +
                                       "password="+connection.sql_password+";"+
                                       "database="+connection.sql_database+";" +
                                       "server=localhost;"
                                       );

        private bool connection_enabled;

        public SQLclass()
        {
            try
            {
                /*
                 * The checkdatabase function will succeed if:
                 * If it is already setup,
                 * If SQL is not running (Will be disabled latter)
                 * If it gets setup
                 *
                 * It could throw an exception if something weird happens,
                 * if an incorrect root password is given, or anyother exception is thrown
                 */
                checkdatabase();
                svt_telemetry.Open(); //If this still doesn't work we also have a problem...
                //^^This could create a duplicate error message if the MySQL Database is just offline
                connection_enabled = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Failed to Configure the Database Automatically, try configuring manually or check the root password.\n" + "ERROR TEXT: " + ex.Message);
                connection_enabled = false;
            }
        }
        ~SQLclass() //Is this a correct declaration?
        {
            svt_telemetry.Close();
        }

        public static void checkdatabase()
        {
            try
            {
                svt_telemetry.Open();
                svt_telemetry.Close();
                return; //Everything works fine...
            }
            catch (MySql.Data.MySqlClient.MySqlException exep)
            {
                if (exep.Number == 1042) //We Cant establish a connection because the server is not on or installed
                {
                    MessageBox.Show(exep.Message + "\nMySQL is probably not running or not installed. Database will be disabled");
                    return; //Nothing more to do here
                }
                if (exep.Number == 0) //Permissions Denied, we can attempt to fix this
                {
                    connection.sql_root = Microsoft.VisualBasic.Interaction.InputBox("In order to configure MySQL, Please Enter MySQL root password: ", "Root Password", connection.sql_root);
                }
                else
                {
                    //MessageBox.Show(ex.Message + "\n");
                    throw exep; //Send it up the stack, we wont be handling it here
                }
            }
            MySqlConnection setupdatabase = new MySqlConnection("uid=root; server=localhost; password=" + connection.sql_root + ";");
            setupdatabase.Open(); //Will Throw Exception outside of Function if Credentials are incorect

            //Drop our Users if they exist already

            try
            {
                MySqlCommand removeuser = new MySqlCommand("DROP USER '" + connection.sql_username + "'@'localhost'; ", setupdatabase);
                removeuser.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ;//If there is a probelm droping the user, we don't care about it, it probably did not exist
            }


            try
            {
                MySqlCommand removeremoteuser = new MySqlCommand("DROP USER '" + connection.sql_remote_username + "'@'%'; ", setupdatabase);
                removeremoteuser.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ;//If there is a probelm droping the user, we don't care about it, it probably did not exist
            }

            //We are done droping the user lets add our database tables and users

            string setupdbstring = "CREATE DATABASE IF NOT EXISTS " + connection.sql_database + "; " +
                                   "CREATE USER '" + connection.sql_username + "'@'localhost' IDENTIFIED BY '" + connection.sql_password + "'; " +
                                   "GRANT ALL PRIVILEGES ON " + connection.sql_database + ".* TO '" + connection.sql_username + "'@'localhost'; " +
                                   "CREATE USER '" + connection.sql_remote_username + "'@'%' IDENTIFIED BY '" + connection.sql_remote_password + "'; " +
                                   "GRANT ALL ON " + "*.* TO '" + connection.sql_remote_username + "'@'%'; ";

            MySqlCommand setupdb = new MySqlCommand(setupdbstring, setupdatabase);
            setupdb.ExecuteNonQuery();
            //
            //Create table(s)
            //
            string createtablestring = "USE " + connection.sql_database + ";" + @"
                                        CREATE TABLE telemetry (
                                                id INTEGER NOT NULL AUTO_INCREMENT,
                                                epochtime BIGINT,
                                                time CHAR(16) NOT NULL,
                                                latitude NUMERIC(12, 6) NOT NULL,
                                                longitude NUMERIC(12, 6) NOT NULL,
                                                elevation NUMERIC(10, 4) NOT NULL,
                                                velocity NUMERIC(10, 4) NOT NULL,
                                                mainpacksoc NUMERIC(10, 4) NOT NULL,
                                                mainpackcurrent NUMERIC(10, 4) NOT NULL,
                                                voltagemainpackcurrent NUMERIC(10, 4) NOT NULL,
                                                arraycurrent NUMERIC(10, 4) NOT NULL,
                                                auxpackvoltage NUMERIC(10, 4) NOT NULL,
                                                PRIMARY KEY (id)
                                       ";

            MySqlCommand createtable = new MySqlCommand(createtablestring, setupdatabase);
            createtable.ExecuteNonQuery();
        }
        public void insert(string longitude, string latitude, string elevation, string velocity)
        {
            if (!connection_enabled)
                return;
            MySqlCommand add_to_database = new MySqlCommand();
            add_to_database.Connection = svt_telemetry;
            //Stackoverflow insisted this be the way this is done. I think it prevents SQL injections. Not that we should ever have to be concerned about those.
            add_to_database.Parameters.AddWithValue("@epochtime", (Int32)((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds * 1000));
            add_to_database.Parameters.AddWithValue("@time", DateTime.Now.ToString("mm/dd/yyyy HH:mm:ss"));
            //GPS Data
            add_to_database.Parameters.AddWithValue("@latitude", latitude);
            add_to_database.Parameters.AddWithValue("@longitude", longitude);
            add_to_database.Parameters.AddWithValue("@elevation", elevation);
            add_to_database.Parameters.AddWithValue("@velocity", velocity);
            //Batery Controler Data
            add_to_database.Parameters.AddWithValue("@mainpacksoc", mainpacksoc);
            add_to_database.Parameters.AddWithValue("@mainpackcurrent", mainpackcurrent);
            add_to_database.Parameters.AddWithValue("@voltagemainpackcurrent", voltagemainpackcurrent);
            //Array Controller?
            add_to_database.Parameters.AddWithValue("@arraycurrent", arraycurrent);
            add_to_database.Parameters.AddWithValue("@auxpackvoltage", auxpackvoltage);

            //Insertion Statement
            add_to_database.CommandText = "INSERT INTO telemetry(epochtime, time, latitude, longitude, elevation, velocity, mainpacksoc, mainpackcurrent, voltagemainpackcurrent, arraycurrent, auxpackvoltage) VALUES (@epochtime, @time, @latitude, @longitude, @elevation, @velocity, @mainpacksoc, @mainpackcurrent, @voltagemainpackcurrent, @arraycurrent, @auxpackvoltage)";
            try
            {
                add_to_database.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ;//If there is a problem, we don't want it to affect us. To bad we loose that data though....
            }
        }
    }
}
