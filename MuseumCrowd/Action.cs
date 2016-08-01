using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCrowd
{
    public class Action
    {
        /// <summary>
        /// Время действия
        /// </summary>
        public DateTime Time;
        /// <summary>
        /// Сумма входящих и выходящих посетителей (Value=IN-OUT)
        /// </summary>
        public int Value; // знак "минус" - выходят, "плюс" - заходят

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="time">DateTime время действия </param>
        /// <param name="value">int Сумма входящих и выходящих посетителей (Value=IN-OUT)</param>
        public Action(DateTime time, int value)
        {
            this.Time = time;
            this.Value = value;
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Action()
        {
        }
    }
}
