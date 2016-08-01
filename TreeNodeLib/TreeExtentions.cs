using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeLib
{
    /// <summary>
    /// Расширение для TreeNode
    /// Методы прохода по дереву, подразумеваем, что дерево не может быть замкнутым по определению
    /// Не проверяем входной граф на этот счет, а так-же на связность.
    /// </summary>
    public static class TreeExtentions
    {

        /// <summary>
        /// Проход по дереву "в глубину"
        /// </summary>
        /// <typeparam name="T">Определенный пользователем тип узла</typeparam>
        /// <param name="node">TreeNode &lt T &qt стартовый узел </param>
        /// <returns>IEnumerable &lt T &qt перечисление пройденных узлов</returns>
        public static IEnumerable<T> WalkInDepth<T>(this TreeNode<T> node)
        {
            // Добавляем значение отправного узла
            yield return node.Value;
            foreach (TreeNode<T> tNode in node.Children)
            {
                foreach (T item in WalkInDepth<T>(tNode))
                    yield return item;
            }
        }

        /// <summary>
        /// Проход по дереву "в ширину"
        /// </summary>
        /// <typeparam name="T">Определенный пользователем тип узла</typeparam>
        /// <param name="node">TreeNode &lt T &qt стартовый узел </param>
        /// <returns>IEnumerable &lt T &qt перечисление пройденных узлов</returns>
        public static IEnumerable<T> WalkInBreadth<T>(this TreeNode<T> node)
        {
            Queue<TreeNode<T>> steps = new Queue<TreeNode<T>>();
            TreeNode<T> step;
            steps.Enqueue(node);
            while (steps.Count > 0)
            {
                step = steps.Dequeue();
                foreach (TreeNode<T> child in step.Children)
                {
                    steps.Enqueue(child);
                }
                yield return step.Value;
            }
        }
    }
}

