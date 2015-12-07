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



        /*"unitId": "14100071",
  "beginTime": {
    "date": {
      "year": 2015,
      "month": 3,
      "day": 10
    },
    "time": {
      "hour": 7,
      "minute": 22,
      "second": 21,
      "nano": 0
    }
  },
  "endTime": {
    "date": {
      "year": 2015,
      "month": 3,
      "day": 10
    },
    "time": {
      "hour": 7,
      "minute": 23,
      "second": 20,
      "nano": 0
    }
  },
  "type": "Gps/GpsGyroMean",
  "min": 27024.23,
  "max": 35480.5,
  "sum": 1902215.0*/



    }
}
