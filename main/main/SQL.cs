using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SQL
{
    //Static Information for easy changes
    class connection
    {
        public const string sql_username = "OSUSVT";
        public const string sql_password = "ManBearPig";
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
            string createtablestring = "USE " + connection.sql_database + ";" +
                                       "CREATE TABLE IF NOT EXISTS telemetry (" +
                                       "Id BIGINT NOT NULL PRIMARY KEY AUTO_INCREMENT, " +
                                       "RecDate TEXT, RecTime TEXT, Longitude TEXT, " +
                                       "Latitude TEXT, " +
                                       "Altitude DECIMAL, " +
                                       "Velocity DECIMAL);";
            
            MySqlCommand createtable = new MySqlCommand(createtablestring, setupdatabase);
            createtable.ExecuteNonQuery();
        }
        //Gets the last 5 rows from the database and averages them
        public double get_average(string fieldname, int numRecords)
        {
            if (!connection_enabled)
                return 0;
            try
            {
                const string tablename = "telemetrytable";
                string CommandText = "SELECT SUM( " + fieldname + " ) FROM (SELECT " + fieldname + " FROM " + tablename + " ORDER BY Id DESC LIMIT " + numRecords + " ) AS subquery;";
                MySqlCommand select = new MySqlCommand(CommandText, svt_telemetry);
                /*select.Parameters.AddWithValue("@fieldname", fieldname);
                select.Parameters.AddWithValue("@number", numRecords);
                */
                //Parameterizing Did not work, because it adds "" around the parameters
                return Convert.ToDouble(select.ExecuteScalar()) / numRecords;
            }catch(InvalidCastException){
                return -666;
            }
        }

        public void update_database(string longitude, string latitude, string velocity, string altitude)
        {
            if (!connection_enabled)
                return;
            MySqlCommand add_to_database = new MySqlCommand();
            add_to_database.Connection = svt_telemetry;
            add_to_database.Parameters.AddWithValue("@date", DateTime.Now.ToString("M/d/yyyy")); //Stackoverflow insisted this be the way this is done. I think it prevents SQL injections. Not that we should ever have to be concerned about those.
            add_to_database.Parameters.AddWithValue("@utc", DateTime.Now.ToString("h:mm:ss tt"));
            add_to_database.Parameters.AddWithValue("@longitude", longitude);
            add_to_database.Parameters.AddWithValue("@latitude", latitude);
            add_to_database.Parameters.AddWithValue("@altitude", altitude);
            add_to_database.Parameters.AddWithValue("@velocity", velocity);
            //If Structure Changes remember to change the CREATE TABLE command in the constructer and delete the database...
            add_to_database.CommandText = "INSERT INTO telemetry(RecDate,RecTime,Longitude,Latitude,Altitude,Velocity) VALUES (@date,@utc,@longitude,@latitude,@altitude,@velocity)";
            add_to_database.ExecuteNonQuery();
        }
    }
}
