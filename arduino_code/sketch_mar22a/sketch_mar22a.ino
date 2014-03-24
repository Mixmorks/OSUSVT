int var = 0;

void setup()
{
    Serial.begin(9600);
}

void loop()
{
  
  if(var == 10)
    var = 0;
    
  
  Serial.write(var+"\n");
  var++;
  delay(1000);
  
}
