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
    /// "Веселая очередь", умеет только добавлять в конец,
    /// забирать первого и посмотреть первого.
    /// Особенность - readonly Nodes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IQueue<T>
    {
        /// <summary>
        /// Очередь
        /// </summary>
        ListNode<T> headNode=null;
        ListNode<T> tailNode = null;
        
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
           
            if (tailNode != null)
            {
                headNode = Uturn(tailNode);
            }
            ListNode<T> newNode = new ListNode<T>(node, headNode);
                headNode = newNode;
        }

        /// <summary>
        /// Забираем первого
        /// </summary>
        /// <returns>T - забирамое значение</returns>
        public T Dequeue()
        {
            if (headNode != null)
            {
                tailNode = Uturn(headNode);
            }
            T result;
            if (tailNode != null)
            {
                result = tailNode.Value;
                tailNode = tailNode.Next;
            }
            else
                throw new InvalidOperationException();
            return result;
        }
        

        /// <summary>
        /// разворачиваем очередь
        /// </summary>
        /// <returns>ListNode<T></returns>
        public ListNode<T> Uturn(ListNode<T> node)
        {
            if (node == headNode) headNode = null;
            else
                tailNode = null;
            ListNode<T> outNode;
                outNode = node;
                node = new ListNode<T>(node.Value, null);
                while (outNode.Next != null)
                {
                    outNode = outNode.Next;
                    node = new ListNode<T>(outNode.Value, node);
                }
            return node;
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале Queue, но не удаляет его.
        /// </summary>
        /// <returns>ListNode<T> начальный элемент </returns>
        public T Peek()
        {
            if (headNode == null & tailNode==null)
                throw new InvalidOperationException("Queue is empty");
            if (headNode != null)
            {
                tailNode = Uturn(headNode);
            }
            T result;
            if (tailNode != null)
            {
                result = tailNode.Value;
            }
            else
                throw new InvalidOperationException();
            return result;
        }
    }
}
