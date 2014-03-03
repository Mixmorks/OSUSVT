using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace GPS
{

    class GPSclass
    {

        private

            float _latitude = 0;     //Data read from the GPRMC output from GPS.
            float _longitude = 0;    //Data read from the GPRMC output from GPS.
            int _sat_count = 0;      //Number of Sattelites AKA NumInUse (from GPGGA)
            float _velocity = 0;     //Velocity deteriorated to MPH. We really ought to change this to the motorcontroller.
            float _altitude = 0;     //Altitude (from GPGGA) above or below MEAN sea level data (taking into account the earth's ellipsoid shape) in METERS
            string _bearing = "N/A"; //
            int _quality = 0;        //GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix) (from GPGGA)
            bool _NoS = false;
            bool _EoW = false;
            string _UTC = "N/A";     //Time at position of GPS.
            static SerialPort gps_port;

        public GPSclass(string gps_port_name, int gps_port_baud)
        {
            gps_port = new SerialPort(gps_port_name , gps_port_baud);
            gps_port.Open();

        }

        public float latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        static public string read_gps_port()
        {
            string data = "";

            while (data == "")
            {
                data = gps_port.ReadLine();
            }
            
            return data; 
        }

        static public void close_gps_port()
        {
            gps_port.Close();
        }

    }
}