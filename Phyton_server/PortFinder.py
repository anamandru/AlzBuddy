import serial.tools.list_ports
import time


class PortFinder:

    @staticmethod
    def find_arduino_port():
        # Get a list of available serial ports
        available_ports = list(serial.tools.list_ports.comports())

        for port in available_ports:
            try:
                # Attempt to open the serial port
                ser = serial.Serial(port.device, 9600, timeout=1)

                # Send a test command to the Arduino (change as needed)
                ser.write(b"HelloArduino")
                time.sleep(1)  # Give the Arduino time to respond

                # Read the response
                response = ser.readline().decode().strip()

                # Check if the response indicates successful communication
                if response == "ArduinoReady":
                    print(f"Arduino found on port: {port.device}")
                    return port.device

            except serial.SerialException:
                pass  # Ignore errors and try the next port

        print("Arduino not found. Make sure it is connected.")
        return None


