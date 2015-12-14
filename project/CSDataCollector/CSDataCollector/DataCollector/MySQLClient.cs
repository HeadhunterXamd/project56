using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CSDataCollector.WrapperClasses;

namespace MySQLClass
{

    //Link to the .NET Connector (MS Installer) http://dev.mysql.com/downloads/connector/net/


    class MySQLClient
    {
        MySqlConnection conn = null;


        #region Constructors
        public MySQLClient(string hostname, string database, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database +";username=" + username +";password=" + password +";");
        }

        public MySQLClient(string hostname, string database, string username, string password, int portNumber)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() +";");
        }

        public MySQLClient(string hostname, string database, string username, string password, int portNumber, int connectionTimeout)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";Connection Timeout=" + connectionTimeout.ToString() +";");
        }
        #endregion

        #region Open/Close Connection
        private bool Open()
        {
            //This opens temporary connection
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                //Here you could add a message box or something like that so you know if there were an error.
                return false;
            }
        }

        private bool Close()
        {
            //This method closes the open connection
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void Insert(string table, string column, string value)
        {
            //Insert values into the database.

            //Example: INSERT INTO names (name, age) VALUES('John Smith', '33')
            //Code: MySQLClient.Insert("names", "name, age", "'John Smith, '33'");
            string query = "INSERT INTO " + table + " (" + column + ") VALUES (" + value + ")";

            try
            {
                if (this.Open())
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void InsertConnection(string port, string value, string dateTime, string unitId)
        {
            //Insert a whole Connection topic into the database.
            //Example: INSERT INTO connection(`port`, `value`, `dateTime`, `unitId`) VALUES ([value-1],[value-2],[value-3],[value-4])
            //Code: MySQLClient.InsertConnection("Connection", "1", "2015-3-10 00:47:24", "357566040024266");

            string query = "INSERT INTO connection(port, value, dateTime, unitId) VALUES ('" + port +"', '" + value +"', '" + dateTime + "', '" + unitId + "')";

            try
            {
                if (this.Open())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void InsertEvents(string port, string value, string dateTime, string unitId)
        {
            //Insert a whole Events topic into the database.
            //Example: INSERT INTO events(`port`, `value`, `dateTime`, `unitId`) VALUES ([value-1],[value-2],[value-3],[value-4])
            //Code: MySQLClient.InsertConnection("Ignition", "1", "2015-3-10 00:47:24", "357566040024266");

            string query = "INSERT INTO events(port, value, dateTime, unitId) VALUES ('" + port + "', '" + value + "', '" + dateTime + "', '" + unitId + "')";

            try
            {
                if (this.Open())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void InsertMonitoring(string unitId, string beginTime, string endTime, string type, string min, string max, string sum)
        {
            //Insert a whole Monitoring topic into the database.
            //Example: INSERT INTO monitoring(`unitId`, `beginTime`, `endTime`, `type`, `min`, `max`, `sum`) VALUES ([value-1],[value-2],[value-3],[value-4],[value-5],[value-6],[value-7])
            //Code: MySQLClient.InsertMonitoring("14100071", "2015-3-10 00:47:24", "2015-3-10 00:47:24", "Gps/GpsAccuracyGyroBias", "0", "0", "0");

            string query = "INSERT INTO monitoring(unitId, beginTime, endTime, type, min, max, sum) VALUES ('" + unitId + "', '" + beginTime + "', '" + endTime + "', '" + type + "', '" + min + "', '" + max + "', '" + sum + "')";

            try
            {
                if (this.Open())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void InsertPosition(string rdx, string rdy, string speed, string course, string numSatellites, string hdop, string quality, string dateTime, string unitId)
        {
            //Insert a whole Positions topic into the database.
            //Example: INSERT INTO position(`rDx`, `rDy`, `speed`, `course`, `numSattellites`, `hdop`, `quality`, `dateTime`, `unitId`) VALUES ([value-1],[value-2],[value-3],[value-4],[value-5],[value-6],[value-7],[value-8],[value-9])
            //Code: MySQLClient.InsertPosition("2015-3-10 00:47:24", "357566000058106", "158126102542985", "380446027478599", "0", "31", "7", "1", "Gps");

            string query = "INSERT INTO position(rDx, rDy, speed, course, numSatellites, hdop, quality, dateTime, unitId) VALUES ('" + rdx + "', '" + rdy + "', '" + speed + "', '" + course + "', '" + numSatellites + "', '" + hdop + "', '" + quality + "', '" + dateTime + "', '" + unitId + "')";

            try
            {
                if (this.Open())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void Update(string table, string SET, string WHERE)
        {
            //Update existing values in the database.

            //Example: UPDATE names SET name='Joe', age='22' WHERE name='John Smith'
            //Code: MySQLClient.Update("names", "name='Joe', age='22'", "name='John Smith'");
            string query = "UPDATE " + table + " SET " + SET + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        public void Delete(string table, string WHERE) 
        {
            //Removes an entry from the database.

            //Example: DELETE FROM names WHERE name='John Smith'
            //Code: MySQLClient.Delete("names", "name='John Smith'");
            string query = "DELETE FROM " + table + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        public Dictionary<string, string> Select(string table, string WHERE)
        {
            //This methods selects from the database, it retrieves data from it.
            //You must make a dictionary to use this since it both saves the column
            //and the value. i.e. "age" and "33" so you can easily search for values.

            //Example: SELECT * FROM names WHERE name='John Smith'
            // This example would retrieve all data about the entry with the name "John Smith"

            //Code = Dictionary<string, string> myDictionary = Select("names", "name='John Smith'");
            //This code creates a dictionary and fills it with info from the database.

            string query = "SELECT * FROM " + table + " WHERE " + WHERE + "";

            Dictionary<string, string> selectResult = new Dictionary<string, string>();

            if (this.Open())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                try
                {
                    while (dataReader.Read())
                    {

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            selectResult.Add(dataReader.GetName(i).ToString(), dataReader.GetValue(i).ToString());
                        }

                    }
                    dataReader.Close();
                }
                catch { }
                this.Close();

                return selectResult;
            }
            else
            {
                return selectResult;
            }
        }

        public int Count(string table)
        {
            //This counts the numbers of entries in a table and returns it as an integear

            //Example: SELECT Count(*) FROM names
            //Code: int myInt = MySQLClient.Count("names");

            string query = "SELECT Count(*) FROM " + table + "";
            int Count = -1;
            if (this.Open() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    this.Close();
                }
                catch { this.Close(); }
                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
