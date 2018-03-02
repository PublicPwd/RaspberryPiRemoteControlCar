# -*- coding: utf-8 -*-
import RPi.GPIO as GPIO
import time
import socket
import sys
GPIO.setmode(GPIO.BOARD)
if sys.getdefaultencoding() != 'utf-8':
    reload(sys)
    sys.setdefaultencoding('utf-8')

INT1=11
INT2=13
INT3=15
INT4=16

def init():
	GPIO.setmode(GPIO.BOARD)
	GPIO.setup(INT1,GPIO.OUT)
	GPIO.setup(INT2,GPIO.OUT)
	GPIO.setup(INT3,GPIO.OUT)
	GPIO.setup(INT4,GPIO.OUT)

def go(second):
	GPIO.output(INT1,GPIO.HIGH)
	GPIO.output(INT2,GPIO.LOW)
	GPIO.output(INT3,GPIO.LOW)
	GPIO.output(INT4,GPIO.HIGH)
	time.sleep(second)

def right(second):
	GPIO.output(INT1,GPIO.HIGH)
	GPIO.output(INT2,GPIO.LOW)
	GPIO.output(INT3,GPIO.HIGH)
	GPIO.output(INT4,GPIO.LOW)
	time.sleep(second)

def left(second):
	GPIO.output(INT1,GPIO.LOW)
	GPIO.output(INT2,GPIO.HIGH)
	GPIO.output(INT3,GPIO.LOW)
	GPIO.output(INT4,GPIO.HIGH)
	time.sleep(second)

def back(second):
	GPIO.output(INT1,GPIO.LOW)
	GPIO.output(INT2,GPIO.HIGH)
	GPIO.output(INT3,GPIO.HIGH)
	GPIO.output(INT4,GPIO.LOW)
	time.sleep(second)

def stop():
	GPIO.output(INT1,GPIO.LOW)
	GPIO.output(INT2,GPIO.LOW)
	GPIO.output(INT3,GPIO.LOW)
	GPIO.output(INT4,GPIO.LOW)

server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
address = ("192.168.1.1", 10000)
server_socket.bind(address)
while True:
    receive_data, client_address = server_socket.recvfrom(1024)
    cmd = receive_data.decode()
    if cmd == 'g':
        print('前进')
		go(0.2)
        stop()
    elif cmd == 'l':
        print('左转')
		left(0.15)
        stop()
    elif cmd == 'r':
        print('右转')
		right(0.15)
        stop()
    elif cmd == 'b':
        print('后退')
		back(0.2)
        stop()
    elif cmd == 's':
        print('关闭')
        stop()
        GPIO.cleanup()
    elif cmd == 'i':
        print('启动')
        init()
        stop()