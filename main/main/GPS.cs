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

            string _latitude  = "";    //Data read from the GPRMC output from GPS.
            string _longitude = "";    //Data read from the GPRMC output from GPS.
            string _sat_count = "";    //Number of Sattelites AKA NumInUse (from GPGGA)
            string _velocity  = "";    //Velocity deteriorated to MPH. We really ought to change this to the motorcontroller.
            string _altitude  = "";    //Altitude (from GPGGA) above or below MEAN sea level data (taking into account the earth's ellipsoid shape) in METERS
            string _bearing = "N/A";   //
            string _quality = "";      //GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix) (from GPGGA)
            string _NoS = "";
            string _EoW = "";
            string _UTC = "N/A";       //Time at position of GPS.
            static SerialPort gps_port;

        public delegate void GPS_data_received();
        public GPS_data_received handler;

        public event GPS_data_received GPS_data_available;
        
        public GPSclass(string gps_port_name, int gps_port_baud)
        {
            //gps_port = new SerialPort(gps_port_name , gps_port_baud);  
            //gps_port.Open();
        }

        public void handle_GPS_data_available() //This needs to be an event.
        {
            string gps_serial_data;
            string[] gps_data;
                
            gps_serial_data = gps_port.ReadLine();
            gps_data = gps_serial_data.Split(',');

            
            if ( (gps_data[0] == "$GPRMC") && (gps_data[2] == "A") )
            {

                /*
                1    = UTC of position fix
                2    = Data status (V=navigation receiver warning)
                3    = Latitude of fix
                4    = N or S
                5    = Longitude of fix
                6    = E or W
                7    = Speed over ground in knots
                8    = Track made good in degrees True
                9    = UT date
                10   = Magnetic variation degrees (Easterly var. subtracts from true course)
                11   = E or W
                12   = Checksum
                */
                _UTC = gps_data[1];
                _latitude = gps_data[3];
                _longitude = gps_data[5];
                _NoS = gps_data[4];
                _EoW = gps_data[6];
                _velocity = (Math.Round(double.Parse(gps_data[7]) * 1.15077945)).ToString();

            }

            if ((gps_data[0] == "$GPGGA") && (gps_data[2] == "A"))
            {

                /*
                1    = UTC of Position
                2    = Latitude
                3    = N or S
                4    = Longitude
                5    = E or W
                6    = GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix)
                7    = Number of satellites in use [not those in view]
                8    = Horizontal dilution of position
                9    = Antenna altitude above/below mean sea level (geoid)
                10   = Meters  (Antenna height unit)
                11   = Geoidal separation (Diff. between WGS-84 earth ellipsoid and
                       mean sea level.  -=geoid is below WGS-84 ellipsoid)
                12   = Meters  (Units of geoidal separation)
                13   = Age in seconds since last update from diff. reference station
                14   = Diff. reference station ID#
                15   = Checksum
                */

                _quality = gps_data[6];
                _sat_count = gps_data[7];
                _altitude = gps_data[9];

            }
             

        }

        static public void close_gps_port()
        {
            gps_port.Close();
        }



    }
}