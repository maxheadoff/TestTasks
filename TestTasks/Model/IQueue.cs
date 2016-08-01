using System;
using System.Text;
using System.Threading.Tasks;

namespace QueueAdv
{
    interface IQueue<T>
    {
        /// <summary>
        /// Кладем в очередь
        /// </summary>
        /// <param name="node">T - добавляемое значение</param>
        void Enqueue(T node);
        /// <summary>
        /// Забираем первого
        /// </summary>
        /// <returns>T - забирамое значение</returns>
        T Dequeue();
        /// <summary>
        /// Возвращает объект, находящийся в начале Queue, но не удаляет его.
        /// </summary>
        /// <returns>ListNode<T> начальный элемент </returns>
        T Peek();
    }
}
