import threading
import  datetime

from ArduReader import ArduReader
from DataPacket import DataPacket
from flask import Flask, jsonify

app = Flask(__name__)

class Server2:
    data_packet = None  # Class variable to store the DataPacket instance

    @classmethod
    def init_app(cls, data_packet):
        cls.data_packet = data_packet

        @app.route('/get_data', methods=['GET'])
        def get_data():
            try:
                print("ceau")
                # Get the current timestamp when the request is received
                timestamp_received = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')

                # Log or print the timestamp
                print(f"GET request received at: {timestamp_received}")
                data = Server2.data_packet.get_data_packet()
                print(data)
                return jsonify(data)
            except Exception as e:
                print(f"Error in get_data: {e}")
                return jsonify({'error': 'An error occurred'}), 500

    @classmethod
    def start_server(cls):
        print("Server runs")
        #cls.init_app(cls.data_packet)  # Initialize the app within the class
        app.run(host='172.20.10.2', port=5000, debug=False)

def main():
    # Data structure that will be sent over to the client
    data_packet = DataPacket()

    # Arduino reader class
    ardu_reader = ArduReader('COM5', data_packet)

    # Server side
    server = Server2()

    # Thread for reading serial data
    reader_thread = threading.Thread(target=ardu_reader.readSearialData)

    # Thread for starting the server
    server_thread = threading.Thread(target=server.start_server)

    # Start reading serial data
    reader_thread.start()

    # Initialize and start the server
    server.init_app(data_packet)
    server_thread.start()

    # Wait for both threads to finish
    reader_thread.join()
    server_thread.join()

if __name__ == "__main__":
    main()