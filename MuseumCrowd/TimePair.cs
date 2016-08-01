using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCrowd
{
    /// <summary>
    /// Представляет период времени от inTime до outTime 
    /// </summary>
    public class TimePair
    {
        public DateTime inTime { get; private set;}
        public DateTime outTime { get; private set;}

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="inTime">DateTime открытие периода</param>
        /// <param name="outTime">DateTime закрытие периода</param>
        public TimePair(DateTime inTime, DateTime outTime)
        {
            this.inTime = inTime;
            this.outTime = outTime;
        }
    }
}
