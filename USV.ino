#include <Wire.h>
#include <SPI.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>
#include <math.h>
#include <DW1000Ranging.h>
#include <WiFiNINA.h>
#include <Servo.h> 


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

//Variable for internet connections

//Wifi credentials
char ssid[] = "dlink-F434";//"Get-2G-9315CC";//"Hetland"; //"eduroam";//"Hetland"; // SSID
char pass[] = "ymgqq28732";//"ctymnzm2qd";//"NhHetland2532"; //"Ijh950923Katt";// //NhHetland2532 Password

int status=WL_IDLE_STATUS;

IPAddress server(192,168,100,102);

WiFiClient client;

Servo winch;
float winchPin= 6; 
 bool greenSignal = true; 
int pos = 0; // variable to store the servo posisjon 
int teller=0;

  
void setup() {
  // put your setup code here, to run once:
Serial.begin(115200);

Imu.begin();
Imu2.begin();
delay(1000);

int8_t temp=Imu.getTemp();
int8_t temp2=Imu2.getTemp();

Imu.setExtCrystalUse(true);
Imu2.setExtCrystalUse(true);

millisOld=millis();

////Config for UWB:
// //init the configuration
//  DW1000Ranging.initCommunication(PIN_RST, PIN_SS, PIN_IRQ); //Reset, CS, IRQ pin
//  //define the sketch as anchor. It will be great to dynamically change the type of module
//  DW1000Ranging.attachNewRange(newRange);
//  DW1000Ranging.attachBlinkDevice(newBlink);
//  DW1000Ranging.attachInactiveDevice(inactiveDevice);
//  //Enable the filter to smooth the distance
//  DW1000Ranging.useRangeFilter(true);
//  
//  //we start the module as an anchor
//  DW1000Ranging.startAsAnchor("82:17:5B:D5:A9:9A:E2:9C", DW1000.MODE_LONGDATA_RANGE_ACCURACY);

// Loop for wifi connection
while(!Serial){
  ;  
}

// check for the WiFi module:
  if (WiFi.status() == WL_NO_MODULE) {
    Serial.println("Communication with WiFi module failed!");
    // don't continue
    while (true);
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
  //printWiFiStatus();

  Serial.println("\nStarting connection to server...");
  // if you get a connection, report back via serial:
 // Make a HTTP request:
  
  while (client.connect(server, 80))
  {
    Serial.println("connected to server");
   // IMU();
    
    DW1000Ranging.loop();
   client.print('#');
   client.print('I');
    client.print('%');
   client.print((theta+theta2)/2); //Roll
   client.print(':');
   client.print((phi+phi2)/2);  //Pitch
   client.print(':');
   client.print((psi+psi2)/2); //Yaw
   client.print(':');
//   newRange();
  // client.print(DW1000Ranging.getDistantDevice()->getRange());
   client.print('!');
   
  
    }
     //winch.attach(6);
}


void loop() {
    // if there are incoming bytes available
  // from the server, read them and print them:
  while (client.available()) {
   char c = char(client.read());
    Serial.println(c);;
  //}
  
   //String line= client.readStringUntil('/r');
   //client.print(line) 
   

  // if the server's disconnected, stop the client:
  if (!client.connected()) {
    Serial.println();
    Serial.println("disconnecting from server.");
    client.stop();

    // do nothing forevermore:
    while (true);
  }
//IMU();
  
// DW1000Ranging.loop();
 
 //Winch();

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

/*Serial.print("Roll: ");
Serial.print((theta+theta2)/2); //Roll
Serial.print(","); 
Serial.print("Pitch: ");
Serial.print((phi+phi2)/2);  //Pitch
Serial.print(",");
Serial.print("Heave: ");
Serial.println((psi+psi2)/2); //Heave

Serial.print("Calibration values for IMUs: ");
Serial.print(gyros);
Serial.print(","); 
Serial.print(accel);
Serial.print(","); 
Serial.print(magn);
Serial.print(","); 
Serial.println(system);*/

phiFold=phiFnew;
thetaFold=thetaFnew;
 
phiFold2=phiFnew2;
thetaFold2=thetaFnew2;
 
delay(BNO055_SAMPLERATE_DELAY_MS);
}
void newRange() {
  Serial.print("from: "); Serial.print(DW1000Ranging.getDistantDevice()->getShortAddress(), HEX);
  Serial.print("\t Range: "); client.print(DW1000Ranging.getDistantDevice()->getRange()); Serial.print(" m");
  Serial.print("\t RX power: "); Serial.print(DW1000Ranging.getDistantDevice()->getRXPower()); Serial.println(" dBm");
}

void newBlink(DW1000Device* device) {
  Serial.print("blink; 1 device added ! -> ");
  Serial.print(" short:");
  Serial.println(device->getShortAddress(), HEX);
}

void inactiveDevice(DW1000Device* device) {
  Serial.print("delete inactive device: ");
  Serial.println(device->getShortAddress(), HEX);
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
  void Winch()
  {
 
  
    for(teller = 0; teller<=pos; teller++){
  for (pos=0; pos<= 360; pos+=1)//goes from 0 degree to 180 degree 
  { 
   winch.write(pos); //tell motoren to go to position (pos)

   
    delay(50);//wait 15ms for the servo to reach the position 
    
   }
   teller++;
   Serial.print(teller);
    }

    
    
  }
