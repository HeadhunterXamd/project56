__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'

import dbManager


class DataRowParser:
    """
        This class parses the row of data and buffers it all
    """

    def __init__(self, mapping: list):
        self.collection = {}
        self.mapping = mapping
        self.dbmanager = dbManager.DatabaseManager()
        self.deliminator = ";"

    def ParseLine(self, line: str) -> None:
        """
            This is the parsers main function, this function checks the line input.
            :rtype : None
            :param line: The data that will be parsed by this function
            :return: None
        """
        # the collection is the string, only it is split on the deliminator
        collection = line.split(self.deliminator)
        for column in range(len(self.mapping)):
            key = self.mapping[column]
            value = collection[column]

            # check if the key is already in the collection, because we use columns,
            # add it to the list if it already exists.
            # else we instantiate a new list with the value as initial content.
            for item in self.collection.keys():
                if key == item:
                    self.collection[key].append(value)
                else:
                    self.collection[key] = [value]
