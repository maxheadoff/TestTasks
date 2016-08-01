using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCrowd
{
    /*
     * 3. В музее регистрируется в течении дня время прихода и ухода каждого посетителя. 
     * Таким образом за день получены N пар значений, где первое значение в паре показывает время прихода посетителя,
     * а второе значения - время его ухода. Необходимо написать функцию для нахождения промежутка времени, 
     * в течении которого в музее одновременно находилось максимальное число посетителей.
     * 
     * таких промежутков может быть не один
     * 
     * */

    /// <summary>
    /// Класс с оптимизированным алгоритмом, подразумеваем, что в музей один вход и выход, 
    /// в одно время может проходить только один посетитель.
    /// Подразумеваем, что к концу списка ни одного посетителя в музее не осталось
    /// </summary>
    public class CrowdOpt : MuseumCrowd.ICrowd
    {

        private SortedList<DateTime ,Direction> checkins= new SortedList<DateTime,Direction>();
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="visits">список посещений посетителями</param>
        public CrowdOpt(List<TimePair> visits)
        {
            foreach (TimePair pair in visits)
            {
                checkins.Add(pair.inTime, Direction.IN);
                checkins.Add(pair.outTime, Direction.OUT);
            }
        }


             
        /// <summary>
        /// Продолжаем искать период.
        /// Если предположить, что все посетители приходят раньше чем уходят, 
        /// и из музея вышли все посетители...
        /// то нет смысла проходить весь список! Работы меньше, эврика!
        /// </summary>
        /// <returns>TimePair </returns>
        public TimePair GetPeriod()
        {
            int persons = 0;
            int maxPersons = 0;
            DateTime beginTime = DateTime.MinValue;
            DateTime endTime = DateTime.MaxValue;
            // Найденное максимальное количество не может быть больше 
            // чем оставшееся количество проходов, ведь выйти должны все
            if (checkins.Count != 0) // А если никто не пришел? Тогда вернем DateTime.MinValue-DateTime.MaxValue
            {
                for (int i = 0; maxPersons <= (checkins.Count - i); i++)
                {
                    if (persons == maxPersons)
                        endTime = checkins.Keys[i];
                    persons += (int)(checkins.Values[i]);
                    if (maxPersons <= persons)
                    {
                        maxPersons = persons;
                        beginTime = checkins.Keys[i];
                    }
                }
            }
            return new TimePair(beginTime, endTime);
        }

      
    }
 
}
