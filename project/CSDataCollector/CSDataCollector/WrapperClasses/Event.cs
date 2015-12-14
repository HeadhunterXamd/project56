
using System;

namespace CSDataCollector.WrapperClasses
{
    class Event : Topic
    {

        public string port { get; private set; }

        public int value { get; private set; }

        private DateTime m_cDateTime;

        public string dateTime
        {
            get
            {
                return DateTimeToString(m_cDateTime);
            }
        }

        public Event(string port, string value, string dateTime, string UnitId)
        {
            this.port = port;
            this.UnitId = int.Parse(UnitId);
            this.value = int.Parse(value);
            m_cDateTime = ParseDate(dateTime);
        }
    }
}