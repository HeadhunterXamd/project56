__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'


class DataRowParser:
    """
        This class parses the row of data and buffers it all
    """

    def __init__(self):
        self.collection = {}
        self.dbmanager = None

    def ParseLine(self, line: str) -> None:
        """
            This is the parsers main function, this function checks the line input.
            :rtype : None
            :param line: The data that will be parsed by this function
            :return: None
            """
        pass
