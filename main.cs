using System;
using Data;

namespace SolarCar{
	hello
	class PortOpening{ /* This is a comment. */
	
		int number_of_ports;
		double baud_rate; // All variables in C# must be declared within classes.
		
		public double number_to_baud(int){
		
			return number_of_ports * 0.3214;
		
		}
	
	}
	
	
	class Data{
		
		public
		
			void setGPS(GPS x);
		
		private
		
			struct GPS{
				string Longtitude;
				string Latitude;
				string SatCoun;
				string Velocity;
				string Altitude;
				string Bearings;
				string Quality;
				string NoW;
				string EoW;
				string UTC;
			}
			
			struct BCM{
				bool Ready;
				bool EPO;
				bool ACChargerPlugged;
				bool HVIL;
				
				int MainContactorState;
				int ChargeContactorState;
				
				bool PowerRelayCommandState;
				bool PowerRelayRelayMonitor;
				bool
			}
		
	}
	
	class MainRoutine{
	
		static void Main(){
		
				
		
		}
	
	}

}
