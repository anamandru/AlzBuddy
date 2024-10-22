
class DataPacket:

    __slots__ = ('data_packet')

    def __init__(self):
        self.data_packet = None

    def set_data_packet(self, data):
        self.data_packet = data

    def get_data_packet(self):
        return self.data_packet
