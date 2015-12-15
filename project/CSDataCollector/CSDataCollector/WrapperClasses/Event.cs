
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

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
            set
            {
                m_cDateTime = ParseDate(value);
            }
        }

        public Event(JObject _cObject)
        {
            ValidMessage = true;
            PropertyInfo[] finfo = GetType().GetProperties();
            foreach (PropertyInfo property in finfo)
            {
                if (property.Name.Equals("ValidMessage")) { continue; }
                property.SetValue(this, Convert.ChangeType(_cObject.GetValue(property.Name), property.PropertyType));
            }
        }
    }
}