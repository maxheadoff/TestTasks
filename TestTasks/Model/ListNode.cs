using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAdv
{
    /// <summary>
    /// элемент неизменяемой очереди
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListNode<T>
    {
           public readonly T Value;
           public readonly ListNode<T> Next;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value">T - значение элемента </param>
           /// <param name="next">ListNode<T>- следующий элемент</param>
           public ListNode(T value, ListNode<T> next)
           {
               this.Value = value;
               this.Next = next;
           }

    }
}
