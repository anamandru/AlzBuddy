int sensorPin = A0; // Analog input pin for MQ-7 sensor
int numSamples = 100;
float sensorValueSum = 0.0;

void setup() {
  Serial.begin(9600);
}

void loop() {
  // Take multiple samples and average the values
  for (int i = 0; i < numSamples; i++) {
    sensorValueSum += analogRead(sensorPin);
    delay(100);
  }

  // Calculate the average sensor value in clean air
  float sensorAvg = sensorValueSum / numSamples;

  // Convert the average sensor value to voltage
  float sensorVolt = sensorAvg / 1024.0 * 5.0;

  // Calculate the resistance of the sensor in clean air (R0)
  float R0 = (5.0 - sensorVolt) / sensorVolt;

  Serial.println("Calibration complete.");
  Serial.print("R0 value: ");
  Serial.println(R0);

  // Stop further readings
  while (1);
}
