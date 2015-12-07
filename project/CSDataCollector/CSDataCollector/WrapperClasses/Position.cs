using System;
using System.Collections.Generic;
using System.Linq;
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

        public DateTime dateTime { get; private set; }

        /// <summary>
        /// standard constructor
        /// </summary>
        /// <param name="rdx"></param>
        /// <param name="rdy"></param>
        /// <param name="speed"></param>
        /// <param name="course"></param>
        /// <param name="numsat"></param>
        /// <param name="hdop"></param>
        /// <param name="quality"></param>
        /// <param name="datetime"></param>
        /// <param name="UnitID"></param>
        public Position(double rdx, double rdy, double speed, double course, int numsat, int hdop, string quality, string datetime, int UnitID)
        {
            rDx = rdx;
            rDy = rdy;
            this.speed = speed;
            this.course = course;
            numSattellites = numsat;
            this.hdop = hdop;
            this.quality = quality;
            dateTime = ParseDate(datetime);
            UnitId = UnitID;
        }
    }
}
