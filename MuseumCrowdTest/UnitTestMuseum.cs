using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuseumCrowd;
using System.Collections.Generic;

namespace MuseumCrowdTest
{
    [TestClass]
    public class UnitTestMuseum
    {

        /// <summary>
        /// по легенде, мы находим только один период, последний
        /// Здесь в тестовых данных есть несколько одинаковых пиков посещаемости
        /// </summary>
        [TestMethod]
        public void TestManyPeaks()
        {
            List<TimePair> list = new List<TimePair>();
            DateTime firstTime=DateTime.Parse("2016-01-01");
            list.Add(new TimePair(firstTime, firstTime.AddHours(10))); // один
            list.Add(new TimePair(firstTime.AddSeconds(1), firstTime.AddHours(5))); //  два
            list.Add(new TimePair(firstTime.AddHours(1), firstTime.AddHours(4))); // 
            list.Add(new TimePair(firstTime.AddHours(2), firstTime.AddHours(5).AddSeconds(1))); // 
            list.Add(new TimePair(firstTime.AddHours(3), firstTime.AddHours(4).AddSeconds(1))); // Максимально = 5
            list.Add(new TimePair(firstTime.AddHours(4).AddMinutes(10)
                , firstTime.AddHours(9).AddMinutes(55))); //  опять пять
            list.Add(new TimePair(firstTime.AddHours(6), firstTime.AddHours(9))); // 3
            list.Add(new TimePair(firstTime.AddHours(7), firstTime.AddHours(9).AddMinutes(50))); // 4
            list.Add(new TimePair(firstTime.AddHours(8), firstTime.AddHours(9).AddMinutes(40))); // 5
            
            TimePair actual=new TimePair(firstTime.AddHours(8)
                , firstTime.AddHours(9));
            ICrowd crowd = new CrowdOpt(list);
            GetPeriod(list, actual, crowd);
            crowd = new CrowdBrutForce(list);
            GetPeriod(list, actual, crowd);
            crowd = new CrowdMulty(list);
            GetPeriod(list, actual, crowd);
        }

        /// <summary>
        /// Один пик посещаемости
        /// </summary>
        [TestMethod]
        public void TestGeneralOpt()
        {
            List<TimePair> list = new List<TimePair>();
            DateTime firstTime = DateTime.Parse("2016-01-01");
            list.Add(new TimePair(firstTime, firstTime.AddHours(10))); // один
            list.Add(new TimePair(firstTime.AddSeconds(1), firstTime.AddHours(5))); //  два
            list.Add(new TimePair(firstTime.AddHours(1), firstTime.AddHours(9))); // 
            list.Add(new TimePair(firstTime.AddHours(3), firstTime.AddHours(8))); // 
            list.Add(new TimePair(firstTime.AddHours(4), firstTime.AddHours(6))); // 
            list.Add(new TimePair(firstTime.AddHours(4).AddMinutes(10)
                , firstTime.AddHours(4).AddMinutes(20))); // 
            TimePair expected = new TimePair(firstTime.AddHours(4).AddMinutes(10)
                , firstTime.AddHours(4).AddMinutes(20));
            
            GetPeriod(list, expected, new CrowdOpt(list));
            GetPeriod(list, expected, new CrowdBrutForce(list));
            GetPeriod(list, expected, new CrowdMulty(list));
        }
        /// <summary>
        /// Тестируем CrowdMulty данными, где есть одновременные события
        /// </summary>
        [TestMethod]
        public void TestCrowdMulty()
        {
            List<TimePair> list = new List<TimePair>();
            DateTime firstTime = DateTime.Parse("2016-01-01");
            list.Add(new TimePair(firstTime, firstTime.AddHours(10))); // один
            list.Add(new TimePair(firstTime, firstTime.AddHours(5))); //  два
            list.Add(new TimePair(firstTime.AddHours(1), firstTime.AddHours(4))); // 3
            list.Add(new TimePair(firstTime.AddHours(1), firstTime.AddHours(5))); // 4
            list.Add(new TimePair(firstTime.AddHours(3), firstTime.AddHours(4).AddSeconds(1))); // Максимально = 5
            list.Add(new TimePair(firstTime.AddHours(4).AddMinutes(10)
                , firstTime.AddHours(9))); //  опять пять
            list.Add(new TimePair(firstTime.AddHours(6), firstTime.AddHours(9))); // 3
            list.Add(new TimePair(firstTime.AddHours(7), firstTime.AddHours(9).AddMinutes(50))); // 4
            list.Add(new TimePair(firstTime.AddHours(8), firstTime.AddHours(9).AddMinutes(40))); // 5

            TimePair expected = new TimePair(firstTime.AddHours(8)
                , firstTime.AddHours(9));

            GetPeriod(list, expected, new CrowdMulty(list));
        }

        /// <summary>
        /// Пустой музей
        /// </summary>
        [TestMethod]
        public void TestEmpty()
        {
            List<TimePair> list = new List<TimePair>();
            TimePair expected = new TimePair(DateTime.MinValue, DateTime.MaxValue);
            GetPeriod(list, expected, new CrowdMulty(list));
            GetPeriod(list, expected, new CrowdBrutForce(list));
            GetPeriod(list, expected, new CrowdOpt(list));
        }

        /// <summary>
        /// Запускает тестируемый метод и сравнивает резултаты
        /// </summary>
        /// <param name="list">List &ltTimePair&qt </param>
        /// <param name="actual">TimePair - "ответ" </param>
        /// <param name="crowd"> ICrowd Тестируемый класс</param>
        private static void GetPeriod(List<TimePair> list, TimePair expected,ICrowd crowd)
        {
            
            TimePair result = crowd.GetPeriod();
            Compare(expected,result);
        }

        /// <summary>
        /// Сравнивает результаты
        /// </summary>
        /// <param name="expected">TimePair </param>
        /// <param name="actual">TimePair </param>
        private static void Compare(TimePair expected, TimePair actual)
        {
            Assert.AreEqual(expected.inTime, actual.inTime);
            Assert.AreEqual(expected.outTime, actual.outTime);
        }
    }
}
