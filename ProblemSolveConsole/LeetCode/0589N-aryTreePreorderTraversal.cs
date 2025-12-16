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
        public IList<int> Preorder(Node root)
        {
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
    }
}
