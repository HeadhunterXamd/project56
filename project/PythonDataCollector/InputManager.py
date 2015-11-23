__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'

from DataParser import DataRowParser
import json


class DataInputManager:
    """
        The data input manager, this class is responsible for the collection and the passthrough of the data to the
        Dataparser. This will collect the data line for line and send them properly through as a string.
    """

    def __init__(self):
        """
            The data input manager, this class is responsible for the collection and the passthrough of the data to the
            Dataparser. This will collect the data line for line and send them properly through as a string.
        """
        self.filename = ""
        self.Dataparser = None

    def Collect(self, filename:str=None) -> None:
        """
            Collects line for line the data of the corresponding input.
            This can be a datastream or a file.
        """
        jsonData = json.load(input)
        # for now get the file instead of the data stream.
        file = None
        if filename is None:
            file = open(self.filename, "r")
        else:
            file = open(filename, "r")

        liner = file.readline()
        liner = liner.strip("\n")
        # create the dataParser mapping, these are the names used for the columns
        mapperline = liner.split(";")
        self.Dataparser = DataRowParser(mapperline)

        # read all the lines given from the file.
        for line in file.readlines():
            self.Dataparser.ParseLine(line.strip())

        # never forget to close the file.
        file.close()


    def PassThrough(self,line:str) -> None:
        """
            Pass the data to the Parser
        """
        pass
