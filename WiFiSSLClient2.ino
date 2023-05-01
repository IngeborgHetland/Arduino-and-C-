#include <Adafruit_BNO055.h>

/*
This example creates a client object that connects and transfers
data using always SSL.

It is compatible with the methods normally related to plain
connections, like client.connect(host, port).

Written by Arturo Guadalupi
last revision November 2015

*/
#include <Wire.h>
#include <SPI.h>
#include <Adafruit_Sensor.h>
#include <utility/imumaths.h>
#include <math.h>
#include <WiFiNINA.h>
#include "DW1000Ranging.h"
 int sPort= 80; 


#include "arduino_secrets.h" 
///////please enter your sensitive data in the Secret tab/arduino_secrets.h
char ssid[] = SECRET_SSID;        // your network SSID (name)
char pass[] = SECRET_PASS;    // your network password (use for WPA, or use as key for WEP)
int keyIndex = 0;            // your network key index number (needed only for WEP)

int status = WL_IDLE_STATUS;
// if you don't want to use DNS (and reduce your sketch size)
// use the numeric IP instead of the name for the server:
IPAddress server(192,168,100,103);  // numeric IP 
//char server[] = "www.google.com";    // name address for Google (using DNS)

// Initialize the Ethernet client library
// with the IP address and port of the server
// that you want to connect to (port 80 is default for HTTP):
WiFiClient client;

#define BNO055_SAMPLERATE_DELAY_MS (100)
#define BNO055_ADDRESS_A 0x28
#define BNO055_ADDRESS_B 0x29
#define BNO055_ID        0xA0

Adafruit_BNO055 Imu= Adafruit_BNO055(BNO055_ADDRESS_A);
Adafruit_BNO055 Imu2= Adafruit_BNO055(BNO055_ADDRESS_B);
 // Variable for IMU
float thetaM;
float phiM;
float thetaFold=0;
float thetaFnew;
float phiFold=0;
float phiFnew;

float thetaM2;
float phiM2;
float thetaFold2=0;
float thetaFnew2;
float phiFold2=0;
float phiFnew2;

float thetaG=0;
float phiG=0;

float thetaG2=0;
float phiG2=0;

float theta;
float phi;
 
float theta2;
float phi2;
 
float thetaRad;
float phiRad;

float thetaRad2;
float phiRad2;
 
float Xm;
float Ym;
float psi;
float Xm2;
float Ym2;
float psi2;
 
float dt;
float dt2;
unsigned long millisOld;

//Variable for UWB
const uint8_t PIN_RST = 9; // reset pin
const uint8_t PIN_IRQ = 2; // irq pin
const uint8_t PIN_SS = 10; // spi select pin




void setup() {
  //Initialize serial and wait for port to open:
Serial.begin(5000);
Imu.begin();
Imu2.begin();
delay(1000);

int8_t temp=Imu.getTemp();
int8_t temp2=Imu2.getTemp();

Imu.setExtCrystalUse(true);
Imu2.setExtCrystalUse(true);

millisOld=millis();
/*
//Config for UWB:
//init the configuration
  DW1000Ranging.initCommunication(PIN_RST, PIN_SS, PIN_IRQ); //Reset, CS, IRQ pin
//define the sketch as anchor. It will be great to dynamically change the type of module
 // DW1000Ranging.attachNewRange(newRange);
  //DW1000Ranging.attachNewDevice(newDevice);
  //DW1000Ranging.attachInactiveDevice(inactiveDevice);
//Enable the filter to smooth the distance
  DW1000Ranging.useRangeFilter(true);

  DW1000.enableDebounceClock();
  DW1000.enableLedBlinking();
  DW1000.setGPIOMode(MSGP0, LED_MODE);
  DW1000.setGPIOMode(MSGP2, LED_MODE);
  DW1000.setGPIOMode(MSGP3, LED_MODE);

//we start the module as a tag
  DW1000Ranging.startAsTag("7D:00:22:55:82:60:00:00", DW1000.MODE_LONGDATA_RANGE_ACCURACY);

*/
  
/* Ola endrer 
  // check for the WiFi module:
  if (WiFi.status() == WL_NO_MODULE) {
    Serial.println("Communication with WiFi module failed!");
    // don't continue
    while (true);
  }
  */

  String fv = WiFi.firmwareVersion();
  if (fv < WIFI_FIRMWARE_LATEST_VERSION) {
    Serial.println("Please upgrade the firmware");
  }

  // attempt to connect to WiFi network:
  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to SSID: ");
    Serial.println(ssid);
    // Connect to WPA/WPA2 network. Change this line if using open or WEP network:
    status = WiFi.begin(ssid, pass);

    // wait 10 seconds for connection:
    delay(10000);
  }
  Serial.println("Connected to WiFi");
  printWiFiStatus();  
  
  Serial.println("\nStarting connection to server...");
  // if you get a connection, report back via serial:

   while ( client.connect(server,sPort)){
   Serial.println("connected to server");
   client.print('#');
   client.print('I');
   client.print('%');
   client.print((theta+theta2)/2); //Roll
   client.print(':');
   client.print((phi+phi2)/2);  //Pitch
   client.print(':');
   client.print((psi+psi2)/2); //Yaw
   //client.print(':');
  // client.print(DW1000Ranging.getDistantDevice()->getRange());
   client.print('!');
   
  //int c = (int)client.parseInt();
  int c=(int)client.read(); 
   Serial.println(c);
 } 
 
   
    // Make a HTTP request:
  
}

void loop() {
  // if there are incoming bytes available
  // from the server, read them and print them:
 
//while(client.connected()){
   
//}
  
   if (!client.connected()) {
    Serial.println();
    Serial.println("disconnecting from server.");
    client.connect(server,sPort); 
    Serial.println("I am trying to connect again"); 

  }

 
  /*
   
 
  while (client.connected()){
    
   client.print('#');
   client.print('I');
   client.print('%');
   client.print((theta+theta2)/2); //Roll
   client.print(':');
   client.print((phi+phi2)/2);  //Pitch
   client.print(':');
   client.print((psi+psi2)/2); //Yaw
   client.print(':');
  // client.print(DW1000Ranging.getDistantDevice()->getRange());
   client.print('!');
         
    }
    */
   //String line= client.readStringUntil('/r');
   //client.print(line) 
   
  

  // if the server's disconnected, stop the client:
 
}


void printWiFiStatus() {
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your board's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print the received signal strength:
  long rssi = WiFi.RSSI();
  Serial.print("signal strength (RSSI):");
  Serial.print(rssi);
  Serial.println(" dBm");
}

 void IMU()
{
   uint8_t system, gyros, accel, magn = 0;
  Imu.getCalibration(&system,&gyros,&accel,&magn);
  Imu2.getCalibration(&system,&gyros,&accel,&magn);
  
imu::Vector<3> acc =Imu.getVector(Adafruit_BNO055::VECTOR_ACCELEROMETER);
imu::Vector<3> gyr =Imu.getVector(Adafruit_BNO055::VECTOR_GYROSCOPE);
imu::Vector<3> mag =Imu.getVector(Adafruit_BNO055::VECTOR_MAGNETOMETER);

imu::Vector<3> acc2 =Imu2.getVector(Adafruit_BNO055::VECTOR_ACCELEROMETER);
imu::Vector<3> gyr2 =Imu2.getVector(Adafruit_BNO055::VECTOR_GYROSCOPE);
imu::Vector<3> mag2 =Imu2.getVector(Adafruit_BNO055::VECTOR_MAGNETOMETER);

thetaM=-atan2(acc.x()/9.8,acc.z()/9.8)/2/3.141592654*360;
phiM=-atan2(acc.y()/9.8,acc.z()/9.8)/2/3.141592654*360;
phiFnew=.95*phiFold+.05*phiM;
thetaFnew=.95*thetaFold+.05*thetaM;

thetaM2=-atan2(acc2.x()/9.8,acc2.z()/9.8)/2/3.141592654*360;
phiM2=-atan2(acc2.y()/9.8,acc2.z()/9.8)/2/3.141592654*360;
phiFnew2=.95*phiFold2+.05*phiM2;
thetaFnew2=.95*thetaFold2+.05*thetaM2;
 
dt=(millis()-millisOld)/1000.;
millisOld=millis();
theta=(theta+gyr.y()*dt)*.95+thetaM*.05;
phi=(phi-gyr.x()*dt)*.95+ phiM*.05;
thetaG=thetaG+gyr.y()*dt;
phiG=phiG-gyr.x()*dt;

dt2=(millis()-millisOld)/1000.;
millisOld=millis();
theta2=(theta2+gyr2.y()*dt)*.95+thetaM2*.05;
phi2=(phi2-gyr2.x()*dt2)*.95+ phiM2*.05;
thetaG2=thetaG2+gyr2.y()*dt2;
phiG2=phiG2-gyr2.x()*dt2;
 
 
phiRad=phi/360*(2*3.14);
thetaRad=theta/360*(2*3.14);

phiRad2=phi2/360*(2*3.14);
thetaRad2=theta2/360*(2*3.14);

Xm=mag.x()*cos(thetaRad)-mag.y()*sin(phiRad)*sin(thetaRad)+mag.z()*cos(phiRad)*sin(thetaRad);
Ym=mag.y()*cos(phiRad)+mag.z()*sin(phiRad);

Xm2=mag2.x()*cos(thetaRad2)-mag2.y()*sin(phiRad2)*sin(thetaRad2)+mag2.z()*cos(phiRad2)*sin(thetaRad2);
Ym2=mag2.y()*cos(phiRad2)+mag2.z()*sin(phiRad2);
 
psi=atan2(Ym,Xm)/(2*3.14)*360;
 
psi2=atan2(Ym2,Xm2)/(2*3.14)*360;

//client.print("Roll: ");
 
//client.print("Pitch: ");

//client.print("Yaw: ");

//client.print("Calibration values for IMUs: ");
//client.print(gyros);
//client.print(","); 
//client.print(accel);
//client.print(","); 
//client.print(magn);
//client.print(","); 
//client.println(system);

phiFold=phiFnew;
thetaFold=thetaFnew;
 
phiFold2=phiFnew2;
thetaFold2=thetaFnew2;
 
delay(BNO055_SAMPLERATE_DELAY_MS);
}
