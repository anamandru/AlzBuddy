import json
import socket
import time

class Server:
    __slots__ = ('server_socket','packet','host','port')

    def __init__(self, packet):
        self.packet = packet

        # Create a socket object
        self.server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

        # Bind the socket to a specific address and port
        self.host = '192.168.35.169'
        self.port = 12345
        self.server_socket.bind((self.host, self.port))

    def start_server(self):

        # Listen for incoming connections
        self.server_socket.listen(5)

        print(f"Server listening on {self.host}:{self.port}")
        # Establish connection with the client
        client_socket, addr = self.server_socket.accept()
        print(f"Got connection from {addr}")

        while True:
            # Send a message to the client
            data = self.packet.get_data_packet()
            json_data = json.dumps(data)
            client_socket.send(json_data.encode())

            # Receive data from the client
            data = client_socket.recv(1024)
            print(f"Received from client: {data.decode()}")

            time.sleep(0.5)