using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                return DateTimeToString(m_cDateTime);
            }
            set
            {
                m_cDateTime = ParseDate(value);
            }

        }

        public Connection(JObject _cObject)
        {
            ValidMessage = true;
            PropertyInfo[] propertyInfo = GetType().GetProperties();
            foreach (PropertyInfo property in propertyInfo)
            {
                if (property.Name.Equals("ValidMessage")) { continue; }
                property.SetValue(this, Convert.ChangeType(_cObject.GetValue(property.Name), property.PropertyType));
            }
        }

        public Connection()
        {
        }
    }
}
