int setupflag = 0;
int var = 0;
char data[9];
String test;

void setup()
{
    Serial.begin(9600);
}

void loop()
{  
}

void serialEvent()
{
    delay(15);
    for(int i=0; i < 8; i++)
         data[i] = Serial.read();  
    
    for(var = 0; var < 8; var++)
         test += data[var];  
    
    if(test == "initport")
    {
      Serial.println("arduinos");
    }
    if(test == "buttonaa")
    {
      Serial.println("I heard you.");
    }

    test = "";
}
