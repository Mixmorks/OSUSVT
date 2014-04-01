using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SQL
{
    //Static Information for easy changes
    class connection
    {
        public const string sqlUsername = "OSUSVT";
        public const string sqlPassword = "ManBearPig";
        public const string sqlDatabase = "TELEMETRY";
    }
    class SQLclass
    {
        private static MySqlConnection svt_telemetry = new MySqlConnection(
                                       "user id="+connection.sqlUsername+";" +
                                       "password="+connection.sqlPassword+";"+
                                       "database="+connection.sqlDatabase+";" +
                                       "server=localhost;"
                                       );
        /*
        SqlCommand add_table = new SqlCommand("",svt_telemetry);
         */
        public SQLclass()
        {
            try
            {
                svt_telemetry.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException exep)
            {
                if (exep.Number == 1042) //We Cant establish a connection because the server is not on or installed
                {
                    MessageBox.Show(exep.Message + "\nMySQL is probably not running or not installed");
                } 
                /*
                 * Try to Automatically Create Database and a user
                 */
                if (exep.Number == 0) //Permissions Denied, we can attempt to fix this
                {
                    string sqlRoot = Microsoft.VisualBasic.Interaction.InputBox("In order to Please Enter MySQL root password: ", "Root Password", "OSUSVT");
                    try
                    {
                        MySqlConnection setupdatabase = new MySqlConnection("uid=root; server=localhost; password=" + sqlRoot + ";");
                        setupdatabase.Open();
                        MySqlCommand adddata = new MySqlCommand("DROP USER '" + connection.sqlUsername + "'; ", setupdatabase);
                        adddata.ExecuteNonQuery();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        ;//If there is a probelm droping the user, we don't care about it, it probably did not exist
                    }
                    try
                    {
                        MySqlConnection setupdatabase = new MySqlConnection("uid=root; server=localhost; password=" + sqlRoot + ";");
                        setupdatabase.Open();
                        string CommandText = "CREATE DATABASE IF NOT EXISTS " + connection.sqlDatabase + "; " +
                            "CREATE USER '" + connection.sqlUsername + "'@'%' IDENTIFIED BY '" + connection.sqlPassword + "'; " +
                            "GRANT ALL PRIVILEGES ON " + connection.sqlDatabase + ".* TO '" + connection.sqlUsername + "'@'%'; ";

                        MySqlCommand adddata = new MySqlCommand(CommandText, setupdatabase);
                        adddata.ExecuteNonQuery();

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Failed to Configure the Database Automatically, try configuring manually or check the root password.\n" + "ERROR TEXT: " + ex.Message);
                        //Program should quit here?
                    }
                    
                }
            }

        }

        public void update_database(string date, string utc, string longitude, string latitude, string velocity, string altitude)
        {
            MySqlCommand add_to_database = new MySqlCommand();
            add_to_database.Connection = svt_telemetry;
            add_to_database.Parameters.AddWithValue("@date", date); //Stackoverflow insisted this be the way this is done. I think it prevents SQL injections. Not that we should ever have to be concerned about those.
            add_to_database.Parameters.AddWithValue("@utc", utc);
            add_to_database.Parameters.AddWithValue("@longitude", longitude);
            add_to_database.Parameters.AddWithValue("@latitude", latitude);
            add_to_database.Parameters.AddWithValue("@altitude", altitude);
            add_to_database.Parameters.AddWithValue("@velocity", velocity);
            add_to_database.CommandText = "INSERT INTO SVTTELEMETRYtable(Date,UTC,Longitude,Latitude,Altitude,Velocity) VALUES (@date,@utc,@longitude,@latitude,@altitude,@velocity)";
            add_to_database.ExecuteNonQuery();
        }
    }
}
