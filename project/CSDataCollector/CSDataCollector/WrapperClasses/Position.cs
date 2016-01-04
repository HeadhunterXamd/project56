using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.WrapperClasses
{
    /// <summary>
    /// Basic Data wrapper for the topic POSITIONS, this makes the gathering of the information through code easier.
    /// </summary>
    class Position : Topic
    {

        public double rDx { get; private set; }

        public double rDy { get; private set; }

        public double speed { get; private set; }

        public double course { get; private set; }

        public int numSattellites { get; private set; }

        public int hdop { get; private set; }

        public string quality { get; private set; }

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

        /// <summary>
        /// standard constructor
        /// </summary>
        /// <param name="_cObject"></param>
        public Position(JObject _cObject)
        {
            ValidMessage = true;
            PropertyInfo[] finfo = GetType().GetProperties();
            foreach (PropertyInfo property in finfo)
            {
                if (property.Name.Equals("ValidMessage")) { continue; }
                property.SetValue(this, Convert.ChangeType(_cObject.GetValue(property.Name), property.PropertyType));
            }
        }

        public Position()
        {
        }

        public override string ToString()
        {
            return "rDx " + rDx + " - rDy " + rDy + " - speed " + speed + " - course " + course + " - numSattellites " + numSattellites + " - hdop " + hdop + " - quality " + quality + " - dateTime " + dateTime;
        }
    }
}
