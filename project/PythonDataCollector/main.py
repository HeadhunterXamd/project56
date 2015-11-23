__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'

import os
from InputManager import DataInputManager

print()

filepath = os.path.dirname(__file__)+"/sample data/"

username = input("please insert your username:  ")
password = input("please insert your password:  ")

inputman = DataInputManager()

filenames = ["Connections.csv", "Events.csv", "Monitoring.csv", "Positions.csv"]

for testFile in filenames:
    inputman.filename = filepath + testFile
    inputman.Collect()
