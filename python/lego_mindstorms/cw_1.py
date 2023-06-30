#!/usr/bin/env python3
from ev3dev.ev3 import *
czujnik = ColorSensor()
silnikP = LargeMotor('outD')
silnikl = LargeMotor('outB')
czujnik.mode = 'COL_COLOR'
while czujnik.value() != 5:
    aktualny_odczyt = czujnik.value()
    if aktualny_odczyt == 1:
        silnikl.stop()
        silnikp.run_forever (speed_sp = 500)

    elif aktualny_odczyt != 5 or aktualny_odczyt != 1:
        silnikP.stop()
        silnikl.run_forever (speed_sp = 500)
silnikP.stop()
silnikl.stop()