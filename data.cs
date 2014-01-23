using system;

namespace datamanagement{

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
			
}
