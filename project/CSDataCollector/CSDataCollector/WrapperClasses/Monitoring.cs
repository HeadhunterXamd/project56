using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector.WrapperClasses
{
    class Monitoring : Topic
    {

        public DateTime BeginTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public string type { get; private set; }

        public double min { get; private set; }

        public double max { get; private set; }

        public double sum { get; private set; }
    }
}
