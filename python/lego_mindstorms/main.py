#!/usr/bin/env python3
from ev3dev.ev3 import *
import math
class Robot:
        def __init__(self):
                #import math
                self.silnikP = LargeMotor('outD')
                self.silnikL = LargeMotor('outA')

                # pozycja startowa
                self.x = 0
                self.y = 0

                # pozycja koncowa, inicjalizacja
                self.xg = 100
                self.yg = 100

                self.theta = 0
                self.N = 360
                self.prev_nP = self.silnikP.position
                self.prev_nL = self.silnikL.position

                self.R = 2.8
                self.L = 11.8
                self.a = 500

                self.silnikP.run_forever(speed_sp = 100)
                self.silnikL.run_forever(speed_sp = 100)

        def stop_engines(self):
                self.silnikP.stop()
                self.silnikL.stop()

        def calculate_position(self):
                #import math
                current_nP = self.silnikP.position
                current_nL = self.silnikL.position

                delta_nP = current_nP - self.prev_nP
                delta_nL = current_nL - self.prev_nL

                # przyrost drogi
                D_L = 2 * math.pi * self.R * (delta_nL/self.N)
                D_R = 2 * math.pi * self.R * (delta_nP/self.N)
                D_C = (D_L + D_R)/2

                # update
                self.prev_nP = current_nP
                self.prev_nL = current_nL

                self.x = self.x + D_C * math.cos(self.theta)
                self.y = self.y + D_C * math.sin(self.theta)
                self.theta = self.theta + (D_R - D_L)/self.L

        def angle_to_goal(self, xg, yg):
                return math.atan2(yg - self.y, xg - self.x)

        def go_to_goal(self,xg,yg ):
                v = 300
                self.xg = xg
                self.yg = yg
                e = self.theta - self.angle_to_goal(xg,yg)
                e = math.atan2(math.sin(e), math.cos(e))
                k = 100
                self.silnikL.run_forever(speed_sp = v + k * e)
                self.silnikP.run_forever(speed_sp = v - k * e)

        def check(self,xg,yg):
                if (abs(self.x - self.xg) <=  2) and (abs(self.y - self.yg) <= 2):
                        return True
                return False

        def run(self, xg, yg ):
                #import time
                self.xg = xg
                self.yg = yg
                while self.check(xg,yg) != True:
                        print(self.x, self.y, self.xg, self.yg)
                        self.calculate_position()
                        self.go_to_goal(self.xg,self.yg)

                print("s eniu")
                self.stop_engines()


robot = Robot()
robot.run(200,0)
robot.run(125,100)
robot.run(125,200)