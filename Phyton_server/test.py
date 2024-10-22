import pyfirmata
import time

board = pyfirmata.Arduino('COM6')

while True:
    board.digital[13].write(1)
    time.sleep(1)
    board.digital[13].write(0)
    time.sleep(1)

    print(board.analog[0].read())

    print("nimc")