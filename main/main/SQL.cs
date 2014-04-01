using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SQL
{
    //Static Information for easy changes
    class connection
    {
        //Need to know this to open a mysql prompt and initially configure the database
        public const string pathMYSQL = "C:\\Program Files\\MySQL\\MySQL Server 5.6\\bin\\mysql.exe"; //Don't forget to escape your '\'s 

        public const string sqlUsername = "OSUSVTuser";
        public const string sqlPassword = "ManBearPig";
        public const string sqlDatabase = "TELEMETRY";
        public const int sqlTimeout = 30;

    }
    class SQLclass
    {
        private static SqlConnection svt_telemetry = new SqlConnection("user id=OSUSVTuser; database=telemetry; password=ManBearPig; server=localhost;");
            /*"user id='"+connection.sqlUsername+"';" +
                                       "password='"+connection.sqlPassword+"';"+
                                       "database='"+connection.sqlDatabase+"'; " +
                                       "connection timeout="+connection.sqlTimeout+";");
        /*
        SqlCommand add_table = new SqlCommand("",svt_telemetry);
         */
        public SQLclass()
        {
            svt_telemetry.Open();
        }

        public void update_database(string date, string utc, string longitude, string latitude, string velocity, string altitude)
        {
            SqlCommand add_to_database = new SqlCommand();
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
