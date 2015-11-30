using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.Input
{
    class DataParser
    {

        /// <summary>
        /// The buffer which contains the data to be sent to the DBManager
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
        public void ParseData(byte[] _lData)
        {

        }

        /// <summary>
        /// Here we decode the JSON code.
        /// </summary>
        /// <param name="_sData"></param>
        public void DecodeData(string _sData)
        {

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
