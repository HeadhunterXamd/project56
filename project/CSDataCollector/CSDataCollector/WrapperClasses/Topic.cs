using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.WrapperClasses
{
    class Topic
    {

        /// <summary>
        /// This is the topic of the class, THIS IS ONLY SET IN THE DATAPARSER.
        /// </summary>
        public string MessageTopic { get; set; }


        public int UnitId { get; protected set; }


        /// <summary>
        /// Parse the string into their correct DateTime.
        /// </summary>
        /// <param name="_sData">The data to be parsed to a <see cref="DateTime"/></param>
        /// <returns>A new <see cref="DateTime"/> based on the input string.</returns>
        protected DateTime ParseDate(string _sData)
        {
            string[] date = _sData.Split('T');
            string[] jmd = date[0].Split('-');
            string[] hmsn = date[1].Split('-');
            return new DateTime(int.Parse(jmd[0]), int.Parse(jmd[1]), int.Parse(jmd[2]), int.Parse(hmsn[0]), int.Parse(hmsn[1]), int.Parse(hmsn[2]));
        }

    }
}
