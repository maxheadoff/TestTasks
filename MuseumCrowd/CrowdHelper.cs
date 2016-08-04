using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumCrowd
{
    /// <summary>
    /// contain the method witch find the most crowded period
    /// </summary>
    public static class CrowdHelper
    {
        /// <summary>
        /// find the most crowded period
        /// </summary>
        /// <param name="visits">List &lt TimePair &gt </param>
        /// <returns></returns>
        public static TimePair GetPeriod(List<TimePair> visits)
        {

            // Объединяем времена приходов и выходов в один общий список
            // вместо Action можно обойтись и абстрактным классом, но с ним код легче читается
            var union = visits.Select(item => new Action(item.inTime, 1))
               .Union(visits.Select(item => new Action(item.outTime, -1)));
            // Группируем список по одинаковому времени и сортируем, небольшой оверхед, в принципе, группировать не обязательно
            var list = union.GroupBy(item => item.Time).Select(ac => new Action { Time = ac.Key, Value = ac.Sum(i => i.Value) })
                .Where(act => act.Value != 0) // исключаем события, где in=out
                .OrderBy(act => act.Time);
            // Подсчитываем количество посетителей и выбираем самый загруженный период
            var result = list.Where(item => item.Time < list.Max(time => time.Time)).Select(item => new
            {
                TimeIn = item.Time,
                TimeOut = list.First(itemOutTime => itemOutTime.Time > item.Time).Time,
                Sum = list.Where(inItem => inItem.Time <= item.Time).Sum(sItem => sItem.Value)
            }).OrderBy(resItem => resItem.Sum).Last();
            return new TimePair(result.TimeIn, result.TimeOut);

        }

    }
}
