using CSDataCollector.WrapperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make a connection with the mqtt broker and subscribe to several topics.
            //Input.InputManager man = new Input.InputManager("m20.cloudmqtt.com");

            // the database manager is separate from the chain so it can keep itself on a separate thread.
            // in the constructor we can subscribe to the bufferfull event of the DataParser.
            //DatabaseManagment.DbManager dbman = new DatabaseManagment.DbManager();

            Topic t = new Topic();
            t.DateTimeToString(DateTime.Now);
            Console.In.Read();

        }
    }
}
