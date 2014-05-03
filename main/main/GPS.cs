using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace GPS
{

    class GPSclass
    {
        
 
            public string Latitude { get; set; }   //Data read from the GPRMC output from GPS.
            public string Longitude { get; set; }  //Data read from the GPRMC output from GPS.
            public string Sat_count { get; set; }  //Number of Sattelites AKA NumInUse (from GPGGA)
            public string Velocity { get; set; }   //Velocity deteriorated to MPH. We really ought to change this to the motorcontroller.
            public string Altitude { get; set; }   //Altitude (from GPGGA) above or below MEAN sea level data (taking into account the earth's ellipsoid shape) in METERS
            public string Bearing { get; set; }    //
            public string Quality { get; set; }    //GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix) (from GPGGA)
            public string NoS { get; set; }
            public string EoW { get; set; }
            public string UTC { get; set; }        //Time at position of GPS.
            
            public bool GPS_found_flag = false;
            public SerialPort gps_port;
        
        public GPSclass()
        {
            Thread gps_initializer = new Thread(init_gps_port);
            gps_initializer.Start();
        }

        public void init_gps_port()
        {
            string potential_GPS_data ="";
            bool port_is_open = false;
            string[] valid_ports; //Makes an array of available port names

            Latitude = "Initializing...";
            Longitude = "Initializing...";

            while (!GPS_found_flag)
            {
                valid_ports = SerialPort.GetPortNames();

                foreach (string port in valid_ports) //Cycles through each individual port 
                {
                    gps_port = new SerialPort(port, 9600);
                    gps_port.ReadTimeout = 1000; //ReadTimeout is important, else the thread will never scan another port.

                    try
                    {
                        gps_port.Open();
                        port_is_open = true;
                    }
                    catch (UnauthorizedAccessException) //We need to catch this because both the thread that builds the GPS and the thread that builds the BodyControlModule are trying to access the ports.
                    {
                        port_is_open = false;
                    }

                    if (port_is_open) //This means that we have successfully fetched a port and opened it, now we can 
                    {
                        try //Reading data from that port for a second.
                        {
                            try
                            {
                                potential_GPS_data = gps_port.ReadLine(); //If data exists, read it.
                            }
                            catch (InvalidOperationException) { }

                            if (potential_GPS_data.Contains("$GPRMC") || potential_GPS_data.Contains("$GPGGA")) //Check if it contains one of the two GPS keywords.
                            {
                                GPS_found_flag = true; //If so, yay! Set flag and keep port open.
                                gps_port.DataReceived += handle_GPS_data_available; //Shortcut way of writing port.DataReceived += new SerialDataReceivedEventHandler(eventhandler)
                                return;
                            }
                        }
                        catch (TimeoutException) { }

                        gps_port.Close(); //If not close port and move to next port.
                    }

                }
            }
            return;
        }

        public void handle_GPS_data_available(object sender, SerialDataReceivedEventArgs e) //This needs to be an event.
        {

            string gps_serial_data;
            string[] gps_data;

            try //Reading data from that port for a second.
            {
                gps_serial_data = gps_port.ReadLine();
                gps_data = gps_serial_data.Split(',');
                
                Latitude = gps_data[2];
                if ((gps_data[0] == "$GPRMC") && (gps_data[2] == "A"))
                {
                    Altitude = gps_data[0];
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
                    UTC = gps_data[1];
                    Latitude = gps_data[3];
                    Longitude = gps_data[5];
                    NoS = gps_data[4];
                    EoW = gps_data[6];
                    Velocity = (Math.Round(double.Parse(gps_data[7]) * 1.15077945)).ToString();


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

                    Quality = gps_data[6];
                    Sat_count = gps_data[7];
                    Altitude = gps_data[9];

                }
            
            }catch (TimeoutException)
            {
               //We can add code in here to indicate to the driver that communication with the GPS has been lost.
            }

        }

    }
}