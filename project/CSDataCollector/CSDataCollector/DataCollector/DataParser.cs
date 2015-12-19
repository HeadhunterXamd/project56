using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CSDataCollector.WrapperClasses;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CSDataCollector.Input
{
    class DataParser
    {

        /// <summary>
        /// The buffer which contains the data to be sent to the DBManager <para/>
        /// The data is topic->column->list of data in chronological order.
        /// </summary>
        public Queue<Topic> buffer { get; set; }


        /// <summary>
        /// The delegate function where the <see cref="BufferFull"/> event is based on.
        /// </summary>
        /// <param name="data">The buffer when it is full.</param>
        public delegate void OnBufferFull(Queue<Topic> data);

        /// <summary>
        /// The bufferfull event that is called when the buffer has 20 or more elements inside.
        /// </summary>
        private event OnBufferFull BufferFull;


        /// <summary>
        /// The instance.
        /// </summary>
        private static DataParser m_cInstance;


        /// <summary>
        /// The subjects we will subscribe to.
        /// </summary>
        private string[] subjects = new string[4] { "CONNECTIONS", "EVENTS", "MONITORING", "POSITIONS" };

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
        /// The dataparser responsible for the parsing of the incoming messages of the mqtt broker.
        /// </summary>
        public DataParser()
        {
            m_cInstance = this;
            buffer = new Queue<Topic>();
        }

        /// <summary>
        /// Parse the byte array into a readable string.
        /// </summary>
        /// <param name="_lData">The incoming byte array from the message of the broker</param>
        /// <param name="_sTopic">The topic where this message comes from.</param>
        public void ParseData(byte[] _lData, string _sTopic)
        {
            // the standard string encoding is used by mqtt so we use the same for decoding.
            try
            {
                string data = Encoding.UTF8.GetString(_lData);
                DecodeData(data, _sTopic);
            }
            catch (Exception e)
            {
                Program.Log(e.Message);
            }
        }

        /// <summary>
        /// Here we decode the JSON code.
        /// </summary>
        /// <param name="_sData">The data decoded into a string of json.</param>
        /// <param name="_sTopic">The topic from this message.</param>
        public void DecodeData(string _sData, string _sTopic)
        {
            Topic item = null;
            JObject ob = JObject.Load(new JsonTextReader(new StringReader(_sData)));
            try
            {
                if (_sTopic.Equals("CONNECTIONS"))
                {
                    item = new Connection(ob);
                }
                else if (_sTopic.Equals("EVENTS"))
                {
                    item = new Event(ob);
                }
                else if (_sTopic.Equals("MONITORING"))
                {
                    item = new Monitoring(ob);
                }
                else if (_sTopic.Equals("POSITIONS"))
                {
                    item = new Position(ob);
                }
                else
                {
                    Program.Log("The topic is not correct. " + _sTopic);
                    return;
                }
            }
            catch (Exception e)
            {
                Program.Log(e.Message);
                return;
            }
            // check if the decoding worked, else it will show an error.
            if (item != null)
            {
                item.MessageTopic = _sTopic;
                if(item.ValidMessage == true)
                {
                    FillBuffer(item);
                }
            }
            else
            {
                throw new Exception("The message from topic " + _sTopic + " couldn't be decoded from json");
            }
        }


        /// <summary>
        /// Add the item to the buffer
        /// </summary>
        /// <param name="_cItem"></param>
        private void FillBuffer(Topic _cItem)
        {
            buffer.Enqueue(_cItem);
            if(buffer.Count >= 20)
            {
                Console.WriteLine("The Buffer is full... \n\n\n\n");
                BufferFull(buffer);
            }
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
