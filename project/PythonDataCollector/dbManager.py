__author__ = 'Niels van Schooten'
__email__ = 'nielsvanschooten@gmail.com'

import _mssql
import json


class DatabaseManager:
    """
        The database manager, this manager manages the connection between the system and the database.
        You can use this manager to push a query, send a dataset and change the database connection.

    """

    def __init__(self, username: str, password: str):
        """
            The database manager, this manager manages the connection between the system and the database.
            You can use this manager to push a query, send a dataset and change the database connection.
            :type username: string
        """
        # self.connectionString = r"Driver={SQL Server};Server=145.24.222.206;
        # Database=INFPRJ2110;Trusted_Connection=yes;"
        self.tables = ["Connections", "Events", "Monitoring", "Positions"]
        self.username = username
        self.password = password
        self.serverAddress = "localhost"
        self.DatabaseName = "INFPRJ2110"
        self.connection = None
        _mssql.login_timeout = 10

    def ExecuteQuery(self, query: str) -> bool:
        """
            Execute a query given to this function.
            the query is used on the current database connection returns true if the query completed successfully.
        """

        # connect with the database.
        print("making connection to the database")
        self.connection = _mssql.connect(server=self.serverAddress, user=self.username, password=self.password,
                                         database=self.DatabaseName)
        self.connection.execute_query(query)
        self.connection.commit()

    def ConnectDatabase(self, dbConnectionString: str) -> bool:
        """
            Connect to a database with a given connection string, on initialization no connection is made.
            returns true if the connection is made successfully.
        """
        pass

    def SendDatasetToDB(self, dataset: dict) -> bool:
        """
            tries to send the given dataset to the database in the given format(the key is the column name).
            returns true if the dataset is successfully sent.
        """
        file = open("FullDatabase.json", "r+")
        data = json.load(file)
        for key in dataset.keys():
            for localkey in data.keys():
                if key is localkey:
                    for item in data[key]:
                        dataset[key].append(item)
                else:
                    dataset[localkey] = data[localkey]

        json.dump(dataset, file)
        file.close()


dbman = DatabaseManager("test", "test")
dbman.ExecuteQuery("SELECT * FROM Connections")
