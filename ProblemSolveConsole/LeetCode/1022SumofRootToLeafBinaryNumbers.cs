using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    internal class _1022SumofRootToLeafBinaryNumbers
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
#if false
        public double result = 0;
        public int SumRootToLeaf(TreeNode root)
        {
            Recursive(root, "");
            return (int)result;
        }

        public void Recursive(TreeNode node, string bit)
        {
            if (node == null)
                return;
            bit += node.val.ToString();
            if (node.left == null && node.right == null)
            {
                for (int i = 0; i < bit.Length; i++)
                {
                    if (bit[i] == '1')
                        result += Math.Pow(2, (bit.Length - 1 - i));
                }
                return;
            }
            else
            {
                Recursive(node.left, bit);
                Recursive(node.right, bit);
            }
            return;
        }
#endif
        public int SumRootToLeaf(TreeNode root)
        {
            return Recursive(root, 0);
        }

        public int Recursive(TreeNode node, int cur)
        {
            if (node == null) return 0;

            cur <<= 1;
            cur |= node.val;

            if (node.left == null && node.right == null)
            {
                return cur;
            }

            return Recursive(node.left, cur) + Recursive(node.right, cur);
        }
    }
}
