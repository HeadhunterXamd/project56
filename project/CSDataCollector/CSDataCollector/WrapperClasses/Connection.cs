using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.WrapperClasses
{
    class Connection : Topic
    {

        public string port { get; private set; }

        public int value { get; private set; }

        private DateTime m_cDateTime;

        public string dateTime {
            get
            {
                return m_cDateTime.ToString();
            }
            set
            {
                m_cDateTime = DateTime.Parse(value.ToString());
            }

        }

        public Connection(string port, string value, string dateTime, string UnitId)
        {
            this.port = port;
            this.UnitId = int.Parse(UnitId);
            this.value = int.Parse(value);
            m_cDateTime = ParseDate(dateTime);
        }
    }
}
