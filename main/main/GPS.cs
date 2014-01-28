using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace main
{
    namespace GPS{

        class GPS
        {

            private

                float Latitude;        //Data read from the GPRMC output from GPS.
                float Longitude;       //Data read from the GPRMC output from GPS.
                int SatCount;        //Number of Sattelites AKA NumInUse (from GPGGA)
                float Velocity;        //Velocity deteriorated to MPH. We really ought to change this to the motorcontroller.
                float Altitude;        //Altitude (from GPGGA) above or below MEAN sea level data (taking into account the earth's ellipsoid shape) in METERS
                string Bearing;         //
                int Quality;         //GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix) (from GPGGA)
                bool NoS;
                bool EoW;
                string UTC;             //Time at position of GPS.

            public

                void setLatitude();
                void setLongitude();
                void setSatCount();
                void setVelocity();
                void setAltitude();
                void setBearing();
                void setQuality();
                void setNoS();
                void setEoW();
                void setUTC();
        }

    }
}
