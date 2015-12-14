using CSDataCollector.WrapperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.DatabaseManagment
{
    class DbManager
    {


        public DbManager()
        {
            Input.DataParser.Instance.SubscribeToBufferFullEvent(test);
        }




        private void test(Queue<Topic> _buffer)
        {
            bool hasnext = true;

            while (hasnext)
            {
                try { _buffer.Peek(); } catch (Exception e) { hasnext = false; }

                Topic item = _buffer.Dequeue();

                if (item.GetType() == typeof(Monitoring))
                {
                    Monitoring m = item as Monitoring;
                }
                else if (item.GetType() == typeof(Event))
                {
                    Event e = item as Event;
                }
                else if (item.GetType() == typeof(Connection))
                {
                    Connection c = item as Connection;
                }
            }

        }
    }
}