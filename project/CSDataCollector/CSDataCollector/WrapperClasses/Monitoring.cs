using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.WrapperClasses
{
    class Monitoring : Topic
    {
        private DateTime m_cBeginDate;

        public string BeginTime
        {
            get
            {
                return DateTimeToString(m_cBeginDate);
            }
            set
            {
                m_cBeginDate = ParseDate(value);
            }
        }

        private DateTime m_cEndTime;

        public string EndTime
        {
            get
            {
                return DateTimeToString(m_cEndTime);
            }
            set
            {
                m_cEndTime = ParseDate(value);
            }
        }

        public string type { get; private set; }

        public double min { get; private set; }

        public double max { get; private set; }

        public double sum { get; private set; }


        /// <summary>
        /// The basic constructor
        /// </summary>
        /// <param name="_cObject"></param>
        public Monitoring(JObject _cObject)
        {
            ValidMessage = true;
            PropertyInfo[] finfo = GetType().GetProperties();
            foreach (PropertyInfo property in finfo)
            {
                // this property is not from the Json, so we ignore this.
                if (property.Name.Equals("ValidMessage")) { continue; }
                // this is a gem in c#, this line sets the value of the Json on the corresponding property.
                property.SetValue(this, Convert.ChangeType(_cObject.GetValue(property.Name), property.PropertyType));
            }
        }

        public Monitoring()
        {
        }
    }
}
