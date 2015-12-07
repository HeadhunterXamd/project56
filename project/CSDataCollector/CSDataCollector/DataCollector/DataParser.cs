using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CSDataCollector.WrapperClasses;

namespace CSDataCollector.Input
{
    class DataParser
    {

        /// <summary>
        /// The buffer which contains the data to be sent to the DBManager <para/>
        /// The data is topic->column->list of data in chronological order.
        /// </summary>
        public Dictionary<string, Dictionary<string, List<string>>> buffer { get; set; }

        public delegate void OnBufferFull(Dictionary<string, Dictionary<string, List<string>>> data);

        private event OnBufferFull BufferFull;


        private static DataParser m_cInstance;
        


        /// <summary>
        /// Static getter for the Dataparser for utility.
        /// </summary>
        public static DataParser Instance
        {
            get
            {
                return m_cInstance;
            }
        }


        /// <summary>
        /// The database manager to send the data to so the data can be sent to the database.
        /// </summary>
        private DatabaseManagment.DbManager manager { get; set; }

        /// <summary>
        /// The dataparser responsible for the parsing of the incoming messages of the mqtt broker.
        /// </summary>
        public DataParser()
        {
            m_cInstance = this;
            manager = new DatabaseManagment.DbManager();
            buffer = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        /// <summary>
        /// Parse the byte array into a readable string.
        /// </summary>
        /// <param name="_lData"></param>
        public void ParseData(byte[] _lData, string _sTopic)
        {
            string data = Encoding.UTF8.GetString(_lData);
            DecodeData(data, _sTopic);

        }

        /// <summary>
        /// Here we decode the JSON code.
        /// </summary>
        /// <param name="_sData"></param>
        public void DecodeData(string _sData, string _sTopic)
        {
            Topic item = null;
            if (_sTopic.Equals("Connection"))
            {
               item = JsonConvert.DeserializeObject<Connection>(_sData);
            }
            else if (_sTopic.Equals("Event"))
            {
                item = JsonConvert.DeserializeObject<Event>(_sData);
            }
            else if (_sTopic.Equals("Monitoring"))
            {
                item = JsonConvert.DeserializeObject<Monitoring>(_sData);
            }
            else if (_sTopic.Equals("Position"))
            {
                item = JsonConvert.DeserializeObject<Position>(_sData);
            }
            else
            {
                Console.WriteLine("The topic is not correct. " + _sTopic);
                return;
            }
            item.MessageTopic = _sTopic;
            Connection test = item as Connection;
            Console.WriteLine(test.dateTime);
        }

        /// <summary>
        /// Subscribe to the Buffer Full event.
        /// </summary>
        /// <param name="_cMethod"></param>
        public void SubscribeToBufferFullEvent(OnBufferFull _cMethod)
        {
            BufferFull += _cMethod;
        }

        /// <summary>
        /// Unsubscribe from the Buffer Full Event.
        /// </summary>
        /// <param name="_cMethod"></param>
        public void UnsubscribeToBufferFullEvent(OnBufferFull _cMethod)
        {
            BufferFull -= _cMethod;
        }
    }
}
