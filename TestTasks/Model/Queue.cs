using System;
using System.Text;
using System.Threading.Tasks;

/*
 * 1. Структуры данных. Реализовать безразмерную очередь (Queue) с использованием односвязных неизменяемых списков. 
Односвязанный неизменяемый список определяется примерно так:
  
class ListNode<T> {
           public readonly T Value;
           public readonly ListNode<T> Next;
…}
*/

namespace QueueAdv
{
    /// <summary>
    /// Веселая очередь, умеет только добавлять в конец,
    /// забирать первого и посмотреть первого
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IQueue<T>
    {
        ListNode<T> headNode=null;
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Queue()
        {
            
        }
        /// <summary>
        /// Конструктор, ставит в очередь первый элемент
        /// </summary>
        /// <param name="headValue"></param>
        public Queue(T headValue)
        {
            headNode = new ListNode<T>(headValue, null);
        }

        /// <summary>
        /// Кладем в очередь
        /// </summary>
        /// <param name="node">T - добавляемое значение</param>
        public void Enqueue(T node)
        {
            ListNode<T> newNode=new ListNode<T>(node, headNode);
                headNode = newNode;
        }

        /// <summary>
        /// Забираем первого
        /// </summary>
        /// <returns>T - забирамое значение</returns>
        public T Dequeue()
        {
            T result;
            if (headNode == null) // Поступаем так-же, как и в существующем прототипе
                throw new InvalidOperationException();
          if (headNode.Next == null) // Вдруг только один элемент в очереди
            {
                result= headNode.Value;
                headNode = null;
                return result;
            } 
            result = Uturn(true).Value;
            Uturn(false);
            return result;
        }

        /// <summary>
        /// разворачиваем очередь
        /// </summary>
        /// <param name="forgetLastNode">Если параметр true, значит мы "достаем" последний элемент из очереди,
        /// иначе просто разворачиваем</param>
        /// <returns>ListNode<T></returns>
        public ListNode<T> Uturn(bool forgetLastNode)
        {
            ListNode<T> lastNode;
            lock (headNode)     // Неизменяемые списки часто применяют для потоковой безопастности, 
            {                   // поставлю здесь блокировку , но что-бы в полной мере назвать эту библиотеку потокобезопасной
                                // нужны тесты на потокобезопастность - это отдельная тема, в задании небыло указано на это.
                lastNode = headNode;
                headNode = new ListNode<T>(headNode.Value, null);
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                    if (lastNode.Next == null & forgetLastNode)
                    {
                        break;
                    }
                    headNode = new ListNode<T>(lastNode.Value, headNode);
                }
            }
            return lastNode;
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале Queue, но не удаляет его.
        /// </summary>
        /// <returns>ListNode<T> начальный элемент </returns>
        public T Peek()
        {
            if (headNode == null)
                throw new InvalidOperationException("Queue is empty");
            ListNode<T> stepNode = headNode;
            while (stepNode.Next != null)
                stepNode = stepNode.Next;
            return stepNode.Value;
        }
    }
}
