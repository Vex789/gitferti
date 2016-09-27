/***************************************************
 This example uses software solution to calibration the ph meter, not the potentiometer. So it is more easy to use and calibrate.
 This is for SEN0161 and SEN0169.
  
 Created 2016-8-11
 By youyou from DFrobot <youyou.yu@dfrobot.com>
   
 GNU Lesser General Public License.
 See <http://www.gnu.org/licenses/> for details.
 All above must be included in any redistribution
 ****************************************************/
  
/***********Notice and Troubleshooting***************
 1.Connection and Diagram can be found here  http://www.dfrobot.com/wiki/index.php/PH_meter%28SKU:_SEN0161%29
 2.This code is tested on Arduino Uno.
 ****************************************************/
 
#include <EEPROM.h>
#define EEPROM_write(address, p) {int i = 0; byte *pp = (byte*)&(p);for(; i < sizeof(p); i++) EEPROM.write(address+i, pp[i]);}
#define EEPROM_read(address, p)  {int i = 0; byte *pp = (byte*)&(p);for(; i < sizeof(p); i++) pp[i]=EEPROM.read(address+i);}
 
#define ReceivedBufferLength 20
char receivedBuffer[ReceivedBufferLength+1];   // store the serial command
byte receivedBufferIndex = 0;
 
#define SCOUNT  30           // sum of sample point
int analogBuffer[SCOUNT];    //store the sample voltage
int analogBufferIndex = 0;
 
#define SlopeValueAddress 0     // (slope of the ph probe)store at the beginning of the EEPROM. The slope is a float number,occupies 4 bytes.
#define InterceptValueAddress (SlopeValueAddress+4) 
float slopeValue, interceptValue, averageVoltage;
boolean enterCalibrationFlag = 0;
 
#define SensorPin A0
#define VREF 5000  //for arduino uno, the ADC reference is the power(AVCC), that is 5000mV
String y,k,fin;

/*EC*/
#define StartConvert 0
#define ReadTemperature 1
 
const byte numReadings = 20;     //the number of sample times
byte ECsensorPin = A1;  //EC Meter analog output,pin on analog 1
unsigned int AnalogSampleInterval=25,printInterval=700,tempSampleInterval=850;  //analog sample interval;serial print interval;temperature sample interval
unsigned int readings[numReadings];      // the readings from the analog input
byte index = 0;                  // the index of the current reading
unsigned long AnalogValueTotal = 0;                  // the running total
unsigned int AnalogAverage = 0,averageVoltage1=0;                // the average
unsigned long AnalogSampleTime,printTime,tempSampleTime;
float temperature=23.19,ECcurrent;
/*****/

void setup()
{
  Serial.begin(115200);
  readCharacteristicValues(); //read the slope and intercept of the ph probe
  for (byte thisReading = 0; thisReading < numReadings; thisReading++)
    readings[thisReading] = 0;
  AnalogSampleTime=millis();
  printTime=millis();
  tempSampleTime=millis();
}
 
void loop()
{
  while (Serial.available() > 0 && (k!="sensorPH\r\n" || k!="sensorCE\r\n")) // Don't read unless                                 // there you know there is data
  {
     k=Serial.readString(); 
    
  }
  
  if(k=="sensorPH\r\n")
  {
    if(serialDataAvailable() > 0)
    {
        byte modeIndex = uartParse();
        phCalibration(modeIndex);    // If the correct calibration command is received, the calibration function should be called.
        EEPROM_read(SlopeValueAddress, slopeValue);     // After calibration, the new slope and intercept should be read ,to update current value.
        EEPROM_read(InterceptValueAddress, interceptValue);
    }
     
     static unsigned long sampleTimepoint = millis();
     if(millis()-sampleTimepoint>40U)
     {
       sampleTimepoint = millis();
       analogBuffer[analogBufferIndex] = analogRead(SensorPin)/1024.0*VREF;    //read the voltage and store into the buffer,every 40ms
       analogBufferIndex++;
       if(analogBufferIndex == SCOUNT) 
           analogBufferIndex = 0;
       averageVoltage = getMedianNum(analogBuffer,SCOUNT);   // read the stable value by the median filtering algorithm
     }
      
     static unsigned long printTimepoint = millis();
     if(millis()-printTimepoint>1000U)
     {
       printTimepoint = millis();
       if(enterCalibrationFlag)             // in calibration mode, print the voltage to user, to watch the stability of voltage
       {
         Serial.print("Voltage:");
         Serial.print(averageVoltage);
         Serial.println("mV");
       }else{
       Serial.print("pH:");              // in normal mode, print the ph value to user
       Serial.println(averageVoltage/1000.0*slopeValue+interceptValue);
       }
     }
   }
   if(k=="sensorCE\r\n")
   {
      if(millis()-AnalogSampleTime>=AnalogSampleInterval)  
      {
        AnalogSampleTime=millis();
         // subtract the last reading:
        AnalogValueTotal = AnalogValueTotal - readings[index];
        // read from the sensor:
        readings[index] = analogRead(ECsensorPin);
        // add the reading to the total:
        AnalogValueTotal = AnalogValueTotal + readings[index];
        // advance to the next position in the array:
        index = index + 1;
        // if we're at the end of the array...
        if (index >= numReadings)
        // ...wrap around to the beginning:
        index = 0;
        // calculate the average:
        AnalogAverage = AnalogValueTotal / numReadings;
      }
       /*
       Every once in a while,print the information on the serial monitor.
      */
      if(millis()-printTime>=printInterval)
      {
        printTime=millis();
        averageVoltage1=AnalogAverage*(float)5000/1024;
        Serial.print("Analog value:");
        Serial.print(AnalogAverage);   //analog average,from 0 to 1023
        Serial.print("    Voltage:");
        Serial.print(averageVoltage1);  //millivolt average,from 0mv to 4995mV
        Serial.print("mV    ");
        Serial.print("temp:");
        Serial.print(temperature);    //current temperature
        Serial.print("^C     EC:");
         
        float TempCoefficient=1.0+0.0185*(temperature-25.0);    //temperature compensation formula: fFinalResult(25^C) = fFinalResult(current)/(1.0+0.0185*(fTP-25.0));
        float CoefficientVolatge=(float)averageVoltage1/TempCoefficient;   
        if(CoefficientVolatge<150)Serial.println("No solution!");   //25^C 1413us/cm<-->about 216mv  if the voltage(compensate)<150,that is <1ms/cm,out of the range
        else if(CoefficientVolatge>3300)Serial.println("Out of the range!");  //>20ms/cm,out of the range
        else
        { 
          if(CoefficientVolatge<=448)ECcurrent=6.84*CoefficientVolatge-64.32;   //1ms/cm<EC<=3ms/cm
          else if(CoefficientVolatge<=1457)ECcurrent=6.98*CoefficientVolatge-127;  //3ms/cm<EC<=10ms/cm
          else ECcurrent=5.3*CoefficientVolatge+2278;                           //10ms/cm<EC<20ms/cm
          ECcurrent/=1000;    //convert us/cm to ms/cm
          Serial.print(ECcurrent,2);  //two decimal
          Serial.println("ms/cm");
        }
       }
        while (Serial.available() > 0 && (y!="finCE\r\n")) // Don't read unless                                 // there you know there is data
        {
            y=Serial.readString(); 
        }
        if(y=="finCE\r\n")
        {
          y="";
          k="";
        }
   }
}
 
boolean serialDataAvailable(void)
{
  char receivedChar;
  static unsigned long receivedTimeOut = millis();
  while (Serial.available()>0) 
  {   
    if (millis() - receivedTimeOut > 1000U) 
    {
      receivedBufferIndex = 0;
      memset(receivedBuffer,0,(ReceivedBufferLength+1));
    }
    receivedTimeOut = millis();
    receivedChar = Serial.read();
    if (receivedChar == '\n' || receivedBufferIndex==ReceivedBufferLength){
        receivedBufferIndex = 0;
        strupr(receivedBuffer);
        return true;
    }
    else{
      receivedBuffer[receivedBufferIndex] = receivedChar;
      receivedBufferIndex++;
    }
  }
  return false;
}
 
byte uartParse()
{
  byte modeIndex = 0;
  if(strstr(receivedBuffer, "CALIBRATION") != NULL) 
      modeIndex = 1;
  else if(strstr(receivedBuffer, "EXIT") != NULL) 
      modeIndex = 4;
  else if(strstr(receivedBuffer, "ACID:") != NULL)   
      modeIndex = 2;  
  else if(strstr(receivedBuffer, "ALKALI:") != NULL)
      modeIndex = 3;
  else if(strstr(receivedBuffer, "FIN") != NULL)
      k="";
  return modeIndex;
}
 
void phCalibration(byte mode)
{
    char *receivedBufferPtr;
    static byte acidCalibrationFinish = 0, alkaliCalibrationFinish = 0;
    static float acidValue,alkaliValue;
    static float acidVoltage,alkaliVoltage;
    float acidValueTemp,alkaliValueTemp,newSlopeValue,newInterceptValue;
    switch(mode)
    {
      case 0:
      if(enterCalibrationFlag)
         Serial.println(F("Command Error"));
      break;
       
      case 1:
      receivedBufferPtr=strstr(receivedBuffer, "CALIBRATION");
      enterCalibrationFlag = 1;
      acidCalibrationFinish = 0;
      alkaliCalibrationFinish = 0;
      Serial.println(F("Enter Calibration Mode"));
      break;
      
      case 2:
      if(enterCalibrationFlag)
      {
          receivedBufferPtr=strstr(receivedBuffer, "ACID:");
          receivedBufferPtr+=strlen("ACID:");
          acidValueTemp = strtod(receivedBufferPtr,NULL);
          if((acidValueTemp>3)&&(acidValueTemp<5))        //typical ph value of acid standand buffer solution should be 4.00
          {
             acidValue = acidValueTemp;
             acidVoltage = averageVoltage/1000.0;        // mV -> V
             acidCalibrationFinish = 1;
             Serial.println(F("Acid Calibration Successful"));
           }else {
             acidCalibrationFinish = 0;
             Serial.println(F("Acid Value Error"));
           }
      }
      break;
  
       case 3:
       if(enterCalibrationFlag)
       {
           receivedBufferPtr=strstr(receivedBuffer, "ALKALI:");
           receivedBufferPtr+=strlen("ALKALI:");
           alkaliValueTemp = strtod(receivedBufferPtr,NULL);
           if((alkaliValueTemp>8)&&(alkaliValueTemp<11))        //typical ph value of alkali standand buffer solution should be 9.18 or 10.01
           {
                 alkaliValue = alkaliValueTemp;
                 alkaliVoltage = averageVoltage/1000.0;
                 alkaliCalibrationFinish = 1;
                 Serial.println(F("Alkali Calibration Successful"));
            }else{
               alkaliCalibrationFinish = 0;
               Serial.println(F("Alkali Value Error"));
            }
       }
       break;
 
        case 4:
        if(enterCalibrationFlag)
        {
            if(acidCalibrationFinish && alkaliCalibrationFinish)
            {
              newSlopeValue = (acidValue-alkaliValue)/(acidVoltage - alkaliVoltage);
              EEPROM_write(SlopeValueAddress, newSlopeValue);
              newInterceptValue = acidValue - (slopeValue*acidVoltage);
              EEPROM_write(InterceptValueAddress, newInterceptValue);
              Serial.print(F("Calibration Successful"));
            }
            else Serial.print(F("Calibration Failed"));       
            Serial.println(F(",Exit Calibration Mode"));
            acidCalibrationFinish = 0;
            alkaliCalibrationFinish = 0;
            enterCalibrationFlag = 0;
        }
        break;
    }
}
 
int getMedianNum(int bArray[], int iFilterLen) 
{
      int bTab[iFilterLen];
      for (byte i = 0; i<iFilterLen; i++)
      {
      bTab[i] = bArray[i];
      }
      int i, j, bTemp;
      for (j = 0; j < iFilterLen - 1; j++) 
      {
      for (i = 0; i < iFilterLen - j - 1; i++) 
          {
        if (bTab[i] > bTab[i + 1]) 
            {
        bTemp = bTab[i];
            bTab[i] = bTab[i + 1];
        bTab[i + 1] = bTemp;
         }
      }
      }
      if ((iFilterLen & 1) > 0)
    bTemp = bTab[(iFilterLen - 1) / 2];
      else
    bTemp = (bTab[iFilterLen / 2] + bTab[iFilterLen / 2 - 1]) / 2;
      return bTemp;
}
 
void readCharacteristicValues()
{
    EEPROM_read(SlopeValueAddress, slopeValue);
    EEPROM_read(InterceptValueAddress, interceptValue);
    if(EEPROM.read(SlopeValueAddress)==0xFF && EEPROM.read(SlopeValueAddress+1)==0xFF && EEPROM.read(SlopeValueAddress+2)==0xFF && EEPROM.read(SlopeValueAddress+3)==0xFF)
    {
      slopeValue = 3.5;   // If the EEPROM is new, the recommendatory slope is 3.5.
      EEPROM_write(SlopeValueAddress, slopeValue);
    }
    if(EEPROM.read(InterceptValueAddress)==0xFF && EEPROM.read(InterceptValueAddress+1)==0xFF && EEPROM.read(InterceptValueAddress+2)==0xFF && EEPROM.read(InterceptValueAddress+3)==0xFF)
    {
      interceptValue = 0;  // If the EEPROM is new, the recommendatory intercept is 0.
      EEPROM_write(InterceptValueAddress, interceptValue);
    }
}
