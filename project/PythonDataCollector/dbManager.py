__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'

import pypyodbc

class DatabaseManager:
    """
        The database manager, this manager manages the connection between the system and the database.
        You can use this manager to push a query, send a dataset and change the database connection.

    """

    def __init__(self):
        """
            The database manager, this manager manages the connection between the system and the database.
            You can use this manager to push a query, send a dataset and change the database connection.
        """
        self.connectionString = r"Driver={SQL Server};Server=145.24.222.206;Database=INFPRJ2110;Trusted_Connection=yes;"


    def ExecuteQuery(self, query: str) -> bool:
        """
            Execute a query given to this function.
            the query is used on the current database connection returns true if the query completed successfully.
        """
        connection = pypyodbc.connect(self.connectionString)

    def ConnectDatabase(self, dbConnectionString: str) -> bool:
        """
            Connect to a database with a given connection string, on initialization no connection is made.
            returns true if the connection is made successfully.
        """
        pass

    def SendDatasetToDB(self, dataset:dict) -> bool:
        """
            tries to send the given dataset to the database in the given format(the key is the column name).
            returns true if the dataset is successfully sent.
        """
        pass
