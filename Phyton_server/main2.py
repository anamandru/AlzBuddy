import threading
from ArduReader import ArduReader
from DataPacket import DataPacket
from main import Server2


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
