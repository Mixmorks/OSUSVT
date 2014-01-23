using system;

namespace datamanagement{

	class GPS{
		
		public
			
			public Data();
			
			/* We should really see that we run the incoming data through some checkers and then
			store the actual datatype we want. (Bool/Float etc...)*/
			void setLongditude(string x);
			void setLatidude(string x);
			void setSatCount(string x);
			void setVelocity(string x);
			void setAltitude(string x);
			void setBearings(string x);
			void setQuality(string x);
			void setNoW(string x);
			void setEoW(string x);
			void set UTC(string x);
			
			
			

		
		private

				string Longditude;
				string Latitude;
				string SatCount;
				string Velocity;
				string Altitude;
				string Bearings;
				string Quality;
				string NoW;
				string EoW;
				string UTC;
			
	}
}

Data::Data(){
	
}

void Data::setLongditude(string x){
	
	GPSdata.Longditude = x;
	
}
