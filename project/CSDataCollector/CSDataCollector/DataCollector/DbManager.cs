using CSDataCollector.WrapperClasses;
//using MySQLClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.DatabaseManagment
{
    class DbManager
    {

        //private MySQLClient connDB = new MySQLClient("localhost", "project56", "root", "", 3306);
        public DbManager()
        {
            Input.DataParser.Instance.SubscribeToBufferFullEvent(addTopicsToDatabase);
        }

        private void addTopicsToDatabase(Queue<Topic> _buffer)
        {
            bool hasnext = true;

            while (hasnext)
            {
                try { _buffer.Peek(); } catch (Exception e) { Console.WriteLine(e); hasnext = false; }

                Topic item = _buffer.Dequeue();

                if (item.GetType() == typeof(Monitoring))
                {
                    Monitoring m = item as Monitoring;
                    //connDB.InsertMonitoring(m);
                    Console.WriteLine(m);
                }
                else if (item.GetType() == typeof(Event))
                {
                    Event e = item as Event;
                    //connDB.InsertEvents(e);
                    Console.WriteLine(e);
                }
                else if (item.GetType() == typeof(Connection))
                {
                    Connection c = item as Connection;
                    //connDB.InsertConnection(c);
                    Console.WriteLine(c);
                }
                else if(item.GetType() == typeof(Position))
                {
                    Position p = item as Position;
                    //connDB.InsertPosition(p);
                    Console.WriteLine(p);
                }
            }

        }
    }
}