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

            TimePair expected = new TimePair(firstTime.AddHours(8)
                , firstTime.AddHours(9));
            Compare(expected, CrowdHelper.GetPeriod(list));
        }

        /// <summary>
        /// Один пик посещаемости
        /// </summary>
        [TestMethod]
        public void TestGeneral()
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

            Compare(expected, CrowdHelper.GetPeriod(list));
        }
   

        /// <summary>
        /// Пустой музей
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEmpty()
        {
            List<TimePair> list = new List<TimePair>();
            TimePair expected = new TimePair(DateTime.MinValue, DateTime.MaxValue);
            Compare(expected, CrowdHelper.GetPeriod(list));
        }

        [TestMethod]
        public void TestOneMore()
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
            TimePair actual=CrowdHelper.GetPeriod(list);
            Compare(expected, actual);
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
