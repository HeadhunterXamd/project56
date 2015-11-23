__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'

import dbManager
import json

class DataRowParser:
    """
        This class parses the row of data and buffers it all
    """

    def __init__(self, mapping: list):
        self.collection = {}
        self.mapping = mapping

        # disabled the database manager, because this is not operational yet.
        # self.dbmanager = dbManager.DatabaseManager()
        self.deliminator = ";"

    def ParseLine(self, line: str) -> bool:
        """
            This is the parsers main function, this function checks the line input.
            :rtype : None
            :param line: The data that will be parsed by this function
            :return: bool, if True data is done parsing
        """
        try:
            if len(self.collection[self.mapping[0]]) >= 20:
                print(self.collection)
                self.collection = {}
                print("The collection is buffered, flushing it...")
                print("\n\n")
        except:
            print()

        # the collection is the string, only it is split on the deliminator
        coll = line.split(self.deliminator)
        for column in range(len(self.mapping)):
            key = self.mapping[column]
            value = coll[column]

            reference = []
            for item in self.collection.keys():
                reference.append(item)
            # check if the key is already in the collection, because we use columns,
            # add it to the list if it already exists.
            # else we instantiate a new list with the value as initial content.
            for item in reference:
                if key == item:
                    self.collection[key].append(value)
                    break
            else:
                self.collection[key] = [value]
