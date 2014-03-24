byte input_byte_0;
byte input_byte_1;
short arduino_initialized_flag = 1;

void setup(){
 Serial.begin(9600); 
}

void loop(){
  if(arduino_initialized_flag)
  {
    if(Serial.available() == 2)
    { 
      input_byte_0 = Serial.read();
      delay(100);    
      input_byte_1 = Serial.read();
      delay(100);      
    }
    
     if(input_byte_0 == 128)
     {
       if(input_byte_1 == 1)
       {
        Serial.write("HELLO SVT\n");
        arduino_initialized_flag = 0;
       }
     } 
  }else
  {
  Serial.write("Waiting...\n");
  }
}
