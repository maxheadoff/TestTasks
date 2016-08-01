using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCrowd
{
    /// <summary>
    /// Расчет методом грубой силы
    /// Класс с оптимизированным алгоритмом, подразумеваем, что в музей один вход/выход, 
    /// в одно время может проходить только один посетитель.
    /// </summary>
    public class CrowdBrutForce :ICrowd
    {
        private SortedList<DateTime, Direction> checkins = new SortedList<DateTime, Direction>();


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="visits">List &lt TimePair &qt - список пар вход- выход </param>
         public CrowdBrutForce(List<TimePair> visits)
        {
            foreach (TimePair pair in visits)
            {
                checkins.Add(pair.inTime, Direction.IN);
                checkins.Add(pair.outTime, Direction.OUT);
            }
        }


        /// <summary>
        /// Ищем период, когда в музее было максимальное количество народа
        /// Метод грубой силы
        /// </summary>
        /// <returns>TimePair</returns>
        public TimePair GetPeriod()
        {
            int persons = 0;
            int maxPersons = 0;
            DateTime beginTime = DateTime.MinValue;
            DateTime endTime = DateTime.MaxValue;
            foreach (KeyValuePair<DateTime, Direction> pair in checkins)
            {
                int increment = ((int)pair.Value);
                /*
                 * Следующее условие проходит, если мы в следующей итерации после
                 * обновления максимума посетителей. Если в текущей итерации будет приход,
                 * максимум снова обновится, если расход, мы получаем пик, который является 
                 * кандидатом на искомый период.
                 * */
                if (persons == maxPersons)
                    endTime = pair.Key;
                persons += increment;
                /*Следующее условие обновляет максимум
                 * если условие будет не <= а < , мы получим период, где начало - первый пик из 
                 * N одинаковых пиков, а конец- последний пик. 
                 * Наверное, это не очень соответствует условию задачи
                 * Итак, в методе мы получаем последний период максимального количества посетителей 
                 * из всех периодов, когда достигалось максимальное количество.
                 * */
                if (maxPersons <= persons)
                {
                    maxPersons = persons;
                    beginTime = pair.Key;
                }


            }
            return new TimePair(beginTime, endTime);
        }
    }
}
