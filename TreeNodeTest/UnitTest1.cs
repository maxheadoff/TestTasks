using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeNodeLib;
using System.Collections.Generic;
using System.Text;

namespace TreeNodeTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тестируем методв прохода по дереву.
        /// 
        /// </summary>
        [TestMethod]
        public void TestTree()
        {
            // эталонные строки для глубины и ширины
            string breadthExpected="ROOTB1B2B3B4C2C4D2"; // Ширина
            string depthExpected="ROOTB1B2C2D2B3B4C4";
            TreeNode<string> node = new TreeNode<string>();
            TreeNode<string> childNode = new TreeNode<string>();
            TreeNode<string> childChildNode = new TreeNode<string>();
            // В тестовом дереве - уровни A-B-C-D, в ширину 1-2-3-4
            node.Value = "ROOT";
            childNode.Value = "B1";
            node.Children.Add(childNode);
            childNode = new TreeNode<string>();
            childNode.Value = "B2";
            node.Children.Add(childNode);
            childChildNode.Value="C2";
            childNode.Children.Add(childChildNode);
            childNode = new TreeNode<string>();
            childNode.Value = "D2";
            childChildNode.Children.Add(childNode);
            childNode = new TreeNode<string>();
            childNode.Value = "B3";
            node.Children.Add(childNode);
            childNode = new TreeNode<string>();
            childNode.Value = "B4";
            childChildNode = new TreeNode<string>();
            childChildNode.Value = "C4";
            childNode.Children.Add(childChildNode);
            node.Children.Add(childNode);
            IEnumerable<string> res;
            Console.WriteLine("WalkInBreadth");
            res=node.WalkInBreadth<string>();
            StringBuilder builder = new StringBuilder();
            foreach (string value in res)
            {
                Console.WriteLine(value);
                builder.Append(value);
            }
            Assert.AreEqual(breadthExpected,builder.ToString());
            Console.WriteLine("WalkInDepth");
            res=node.WalkInDepth<string>();
            builder.Clear();
            foreach (string value in res)
            {
                builder.Append(value);
                Console.WriteLine(value);
            }
            Assert.AreEqual(depthExpected, builder.ToString());
       
        }
    }
}
