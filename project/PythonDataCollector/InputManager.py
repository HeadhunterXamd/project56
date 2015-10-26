__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'


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

    def Collect(self, filename:str=None):
        """

            :param filename:
            :return:
        """
        file = None
        if filename is None:
            file = open(self.filename, "r")
        else:
            file = open(filename, "r")


    def PassThrough(self,line:str) -> None:
        pass
