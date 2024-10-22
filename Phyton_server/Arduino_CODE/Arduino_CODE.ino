#include <dht11.h>
#define DHT11PIN 2  //Digital pin to read the room temperature


// VARIABLES DECLARATION
// Temperature sensor
dht11 DHT11;

// Mq7 sensor
int mq7_PIN = A0; //analog input pin for Mq-7 sensor
float mq7_volatage = 0;
float RS_gas = 0;
float monoxide_ratio = 0;
float monoxide_ppm = 0;
int nr = 0;
int R0 = 0;

// Ultrasonic sensor
int ultrasonic_trigPin = 3;    // TRIG pin
int ultrasonic_echoPin = 4;    // ECHO pin
float ultrasonic_duration_us = 0;
float ultrasonic_distance_cm = 0;
const int doorOpenThreshold = 3;  // Adjust this threshold based on your setup (distance in centimeters)
unsigned long doorOpenTimeStart = 0;  // Variable to store the time the door was opened


// Water level sensor
#define LEVEL_POWER_PIN  7
#define LEVEL_SIGNAL_PIN A6
int level_sensor_min = 400;
int level_sensor_max = 700;
int level_value = 0; // variable to store the water level
int level_sensor_value = 0; // variable to store the sensor value

void  setup()
{
  Serial.begin(9600);
  R0 = 2.11; // value of mq-7 sensor resistance after calibration in clear air
  
  // configure the trigger pin to output mode
  pinMode(ultrasonic_trigPin, OUTPUT);
  // configure the echo pin to input mode
  pinMode(ultrasonic_echoPin, INPUT);
  
  // configure D7 pin as an OUTPUT
  pinMode(LEVEL_POWER_PIN, OUTPUT);   
  // turn the sensor OFF
  digitalWrite(LEVEL_POWER_PIN, LOW); // turn the sensor OFF
}

void loop()
{ 
  Serial.println();

  //---------------TEMP SENSOR---------------
  int chk = DHT11.read(DHT11PIN);
  
  Serial.print("Temperature(C):");
  Serial.println((float)DHT11.temperature, 2);


  //---------------MQ7 MONOXIDE SENSOR---------------
  int sensorValue = analogRead(mq7_PIN);

  // Convert the analog value to voltage (0-5V)
  mq7_volatage = sensorValue / 1024.0 * 5.0;

  // Calculate RS/R0 ratio
  RS_gas = (5.0 - mq7_volatage) / mq7_volatage;
  monoxide_ratio = RS_gas / R0;

  // Use the ratio to calculate PPM concentration
  monoxide_ppm = pow(10, (1.69 * log10(monoxide_ratio) + 1.04));

  // Print the PPM value to the serial monitor
  Serial.print("CO PPM:");
  Serial.println(monoxide_ppm);

  //---------------ULTRASONIC SENSOR---------------
  // generate 10-microsecond pulse to TRIG pin
  digitalWrite(ultrasonic_trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(ultrasonic_trigPin, LOW);

  // measure duration of pulse from ECHO pin
  ultrasonic_duration_us = pulseIn(ultrasonic_echoPin, HIGH);

  // calculate the distance
  ultrasonic_distance_cm = 0.017 * ultrasonic_duration_us;
   Serial.print("dist  cm:");
    Serial.println(ultrasonic_distance_cm );  // Convert milliseconds to seconds

  // Check if the door is open
  if (ultrasonic_distance_cm > doorOpenThreshold) {
    // If the door is open, print the time it has been open
    unsigned long currentTime = millis();
    unsigned long doorOpenTime = currentTime - doorOpenTimeStart;
    Serial.print("Door_open_seconds:");
    Serial.println(doorOpenTime / 1000);  // Convert milliseconds to seconds

    // Add your actions or alerts here
  } else {
    // If the door is closed, reset the timer
    doorOpenTimeStart = millis();
    Serial.print("Door_open_seconds:");
    Serial.println(0); 
  }


  //---------------WATER LEVEL SENSOR---------------
  // turn the sensor ON
  digitalWrite(LEVEL_POWER_PIN, HIGH);  
  // wait 10 milliseconds
  delay(10);                 
  // read the analog value from sensor     
  level_sensor_value = analogRead(LEVEL_SIGNAL_PIN); 
  
  // turn the sensor OFF
  digitalWrite(LEVEL_POWER_PIN, LOW);   

  // Map the analog value to a percentage based on the recorded range
  if(level_sensor_value >= 0 && level_sensor_value <= 500) level_value=0;
  else
  if(level_sensor_value > 500 && level_sensor_value <=600) level_value=1;
  else
    if(level_sensor_value > 600 && level_sensor_value <=615) level_value=2;
    else
      level_value=3;
  //level_value = map(level_sensor_value, level_sensor_min, level_sensor_max, 0, 100);
  Serial.print("Water Level:");
  Serial.println(level_value);
  Serial.println();
  delay(1000);

}
