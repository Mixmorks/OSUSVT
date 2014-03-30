using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SQL
{
    class SQLclass
    {
        private static SqlConnection svt_telemetry = new SqlConnection("user id=REDACTED;" +
                                       "password=REDACTED;server=JAN-PC\\SQLEXPRESS;" +
                                       "Trusted_Connection=yes;" +
                                       "database=SVTTELEMETRY; " +
                                       "connection timeout=30");

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
