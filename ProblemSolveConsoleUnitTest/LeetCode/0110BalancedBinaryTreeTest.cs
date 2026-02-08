using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._0110BalancedBinaryTree;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0110BalancedBinaryTreeTest
    {
        private _0110BalancedBinaryTree _0110BalancedBinaryTree;

        public _0110BalancedBinaryTreeTest()
        {
            _0110BalancedBinaryTree = new _0110BalancedBinaryTree();
        }

        [Fact]
        public void Test1()
        {
            TreeNode node = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20,
                    new TreeNode(15),
                    new TreeNode(7)));
            bool result = _0110BalancedBinaryTree.IsBalanced(node);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            TreeNode node = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3,
                        new TreeNode(4),
                        new TreeNode(4)),
                    new TreeNode(3)),
                new TreeNode(2));
            bool result = _0110BalancedBinaryTree.IsBalanced(node);
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            TreeNode node = null;
            bool result = _0110BalancedBinaryTree.IsBalanced(node);
            Assert.True(result);
        }

        [Fact]
        public void Test4()
        {
            TreeNode node = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4,
                        new TreeNode(8),
                        null),
                    new TreeNode(5)),
                new TreeNode(3,
                    new TreeNode(6,
                    null)));
            bool result = _0110BalancedBinaryTree.IsBalanced(node);
            Assert.True(result);
        }
    }
}
