using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueAdv;

namespace QueueTest
{
    [TestClass]
    public class UnitTestQueue
    {
        /// <summary>
        /// Проверяем на строках
        /// </summary>
        [TestMethod]
        public void TestGeneralString()
        {
            string[]  nodes= {"first","second","third","fourth","fifth"};
            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < nodes.Length; i++)
                queue.Enqueue(nodes[i]);

            Assert.AreEqual(queue.Dequeue(), nodes[0]);
            Assert.AreEqual(queue.Dequeue(), nodes[1]);
            Assert.AreEqual(queue.Dequeue(), nodes[2]);
            Assert.AreEqual(queue.Dequeue(), nodes[3]);
            Assert.AreEqual(queue.Dequeue(), nodes[4]);
        }

        /// <summary>
        /// Вызываем исключение если нет нода
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestException()
        {
            string node="string";
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(node);
            Assert.AreEqual(queue.Dequeue(), node);

            queue.Dequeue();
        }

        /// <summary>
        /// проверяем на  типах- значениях
        /// </summary>
        [TestMethod]
        public void TestGeneralValue()
        {
            Guid[] nodes = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            Queue<Guid> queue = new Queue<Guid>();
            for (int i = 0; i < nodes.Length; i++)
                queue.Enqueue(nodes[i]);

            Assert.AreEqual(queue.Dequeue(), nodes[0]);
            Assert.AreEqual(queue.Dequeue(), nodes[1]);
            Assert.AreEqual(queue.Dequeue(), nodes[2]);
            Assert.AreEqual(queue.Dequeue(), nodes[3]);
            Assert.AreEqual(queue.Dequeue(), nodes[4]);
        }
        /// <summary>
        /// Свой объект
        /// </summary>
        [TestMethod]
        public void TestGeneralObj()
        {
            TestData[] nodes;
            Queue<TestData> queue;
            GetQueueObj(out nodes, out queue);
            Assert.AreEqual(queue.Peek(), nodes[0]);
            Assert.AreEqual(queue.Dequeue(), nodes[0]);
            Assert.AreEqual(queue.Peek(), nodes[1]); // "заглянули" не доставая
            Assert.AreEqual(queue.Dequeue(), nodes[1]);
            Assert.AreEqual(queue.Peek(), nodes[2]);
            Assert.AreEqual(queue.Dequeue(), nodes[2]);
            Assert.AreEqual(queue.Peek(), nodes[3]);
            Assert.AreEqual(queue.Dequeue(), nodes[3]);
            Assert.AreEqual(queue.Peek(), nodes[4]);
            Assert.AreEqual(queue.Dequeue(), nodes[4]);
        }

        /// <summary>
        /// Тестируем конструктор с параметром и исключение на пустоту в Peek()
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeek()
        {
            string testNode = "one";
            Queue<String> queue=new Queue<String>(testNode);
            Assert.AreEqual(queue.Peek(), testNode);
            Assert.AreEqual(queue.Dequeue(), testNode);
            Assert.AreEqual(queue.Peek(), testNode); // тут нет ничего
        }

        /// <summary>
        /// Подготавливает тестовые данные
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="queue"></param>
        private static void GetQueueObj(out TestData[] nodes, out Queue<TestData> queue)
        {
            nodes = new TestData[]{ TestData.NewTestData("one"),
                             TestData.NewTestData("two"),
                             TestData.NewTestData("three"),
                             TestData.NewTestData("four"),
                             TestData.NewTestData("five"),
                             };
            queue = new Queue<TestData>();
            for (int i = 0; i < nodes.Length; i++)
                queue.Enqueue(nodes[i]);
        }

        
        /// <summary>
        /// Для тестирования собственным типом
        /// </summary>
        class TestData
        {
            public static TestData NewTestData(string name)
            {
                return new TestData(name);
            }
            public string Name;
            public DateTime CreateDate;

            private TestData(string name)
            {
                this.Name = name;
                CreateDate = DateTime.Now;
            }

        }

    }




}
