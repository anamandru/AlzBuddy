import serial

class ArduReader:

    __slots__ = ('ser', 'data_retrieved_dict', 'data_packet')

    def __init__(self, port, data_packet):
        self.ser = serial.Serial(port, 9600)  # Replace 'COMx' with the correct serial port identifier

        self.data_retrieved_dict = {"Temperature(C)": None,
                               "CO PPM": None,
                               "Distance": None,
                               "Water Level": None
                               }
        self.data_packet = data_packet

    def readSearialData(self):
        try:
            while True:
                line = self.ser.readline().decode('utf-8').strip()
                # Check if the line contains a comma
                if ':' in line:
                    label, value = line.split(':')
                    self.data_retrieved_dict[label] = value

                    if (label == "Water Level"):
                        self.data_packet.set_data_packet(self.data_retrieved_dict)
                        #print(self.data_retrieved_dict)

        except KeyboardInterrupt:
            self.ser.close()


