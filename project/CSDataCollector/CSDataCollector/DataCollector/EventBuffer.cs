using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector
{
    class EventBuffer<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>
    {
        /// <summary>
        /// The function blueprint to be used on the event when the buffer is full.
        /// </summary>
        /// <param name="buffer"></param>
        private delegate void OnBufferFull(EventBuffer<Tkey, Tvalue> buffer);

        /// <summary>
        /// 
        /// </summary>
        private event OnBufferFull BufferFull;


        public new void Add(Tkey key, Tvalue value)
        {
            base.Add(key, value);
        }


    }
}
