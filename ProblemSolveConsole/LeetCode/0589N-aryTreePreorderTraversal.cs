using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ProblemSolveConsole.LeetCode._0589N_aryTreePreorderTraversal;

namespace ProblemSolveConsole.LeetCode
{
    public class _0589N_aryTreePreorderTraversal
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public IList<int> Preorder(Node root)
        {
            //time:O(n)
            //space:O(n)
            //很單純的先中間，然後左到右的深度優先
            List<int> result = new List<int>();

            if (root == null)
            {
                return result;
            }

            Recursive(root, result);

            return result;
        }

        private void Recursive(Node node, List<int> result)
        {
            result.Add(node.val);

            foreach (Node sub in node.children) //會跑DFS
            {
                Recursive(sub, result);
            }
        }

        //100%的人用的也是完全一樣的方法，差異性理論上不大
        //https://leetcode.com/problems/n-ary-tree-preorder-traversal/description/?page=3
        //這位Iterative and Recursive都有，下次記得練習一下Iterative

    }
}
