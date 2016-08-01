using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCrowd
{
    /// <summary>
    /// Говорят, что в Китае совпали Гуиды, поэтому, 
    /// следующий тип реализует возможность одновременного прохода посетителями
    /// Здесь я рискнул использовать линк, в задании запрета небыло, однако лишний референс...
    /// </summary>
    public class CrowdMulty :ICrowd
    {
        private IOrderedEnumerable<Action> list;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="visits">список посещений посетителями</param>
        public CrowdMulty(List<TimePair> visits)
        {
            // Объединяем времена приходов и выходов в один общий список
             var union = visits.Select(item=> new Action(item.inTime,1))
                .Union(visits.Select(item=> new Action(item.outTime,-1)));
            // Группируем список по одинаковому времени и сортируем, небольшой оверхед, в принципе, группировать не обязательно
            list= union.GroupBy(item=>item.Time).Select(ac=> new Action {Time=ac.Key,Value=ac.Sum(i=>i.Value)})
                .Where(act => act.Value != 0) // исключаем события, где in=out
                .OrderBy(act=>act.Time); 
           
        }
        /// <summary>
        /// Метод позволяет выбирать период из списка где есть одновременные входа-выхода
        /// </summary>
        /// <returns>TimePair - последний период наибольшей загруженности</returns>
        public TimePair GetPeriod()
        {
            int persons = 0;
            int maxPersons = 0;
            DateTime beginTime = DateTime.MinValue;
            DateTime endTime = DateTime.MaxValue;
            foreach(Action act in list)
            {
                   if (persons == maxPersons)
                       endTime=act.Time;
                persons+=act.Value;
                if(maxPersons<=persons)
                {
                    maxPersons=persons;
                    beginTime=act.Time;
                }
            }
            return new TimePair(beginTime, endTime);
        }
    }
}
