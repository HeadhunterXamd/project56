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
        public string MessageTopic;


        public string unitId { get; protected set; }

        /// <summary>
        /// Check if this message is valid...
        /// if something is null in the message this will be set to false.
        /// </summary>
        public bool ValidMessage { get; protected set; }

        /// <summary>
        /// Parse the string into their correct DateTime.
        /// </summary>
        /// <param name="_sData">The data to be parsed to a <see cref="DateTime"/></param>
        /// <returns>A new <see cref="DateTime"/> based on the input string.</returns>
        protected DateTime ParseDate(string _sData)
        {
            if (_sData == null)
            {
                ValidMessage = false;
                return new DateTime();
            }
            DateTime Date;
            string[] date = _sData.Split(' ');
            string[] jmd = date[0].Split('/');
            if(jmd[2].Length > 2)
            {
                string temp;
                temp = jmd[2];
                jmd[2] = jmd[0];
                jmd[0] = temp;
            }
            string[] hmsn = date[1].Split(':');
            if(hmsn.Count() == 3)
            {
                Date = new DateTime(int.Parse(jmd[0]), int.Parse(jmd[1]), int.Parse(jmd[2]), int.Parse(hmsn[0]), int.Parse(hmsn[1]), int.Parse(hmsn[2]));
            }
            else
            {
                Date = new DateTime(int.Parse(jmd[0]), int.Parse(jmd[1]), int.Parse(jmd[2]), int.Parse(hmsn[0]), int.Parse(hmsn[1]), 0);
            }
            return Date;
        }

        /// <summary>
        /// ToString method to format the datetime for mysql.
        /// </summary>
        /// <param name="_cDateTime"></param>
        /// <returns></returns>
        public string DateTimeToString(DateTime _cDateTime)
        {
            string firstpart = _cDateTime.Date.ToString();
            string secondpart = _cDateTime.TimeOfDay.ToString().Split('.')[0];
            string[] firstnew = firstpart.Split(' ')[0].Split('/');
            string fixedFirstPart = "" + firstnew[2] + "-" + firstnew[1] + "-" + firstnew[0];

            return fixedFirstPart + " " + secondpart;
        }

        public override string ToString()
        {
            return "Message Topic " + MessageTopic + " UnitId "  + unitId + " Valid message " + ValidMessage;
        }
    }
}
