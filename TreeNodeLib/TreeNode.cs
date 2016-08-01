using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeLib
{
    public class TreeNode<T>
    {
        public T Value;
        public readonly List<TreeNode<T>> Children = new List<TreeNode<T>>();
    }
}
