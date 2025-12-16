using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node = ProblemSolveConsole.LeetCode._0589N_aryTreePreorderTraversal.Node;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0589N_aryTreePreorderTraversalTest
    {

        private _0589N_aryTreePreorderTraversal _0589N_aryTreePreorderTraversal;

        public _0589N_aryTreePreorderTraversalTest()
        {
            _0589N_aryTreePreorderTraversal = new _0589N_aryTreePreorderTraversal();
        }

        [Fact]
        public void Test1()
        {
            IList<int> result = _0589N_aryTreePreorderTraversal.Preorder(
                new Node(1, new List<Node>() {
                    new Node(3, new List<Node>()
                    {
                        new Node(5, new List<Node>()),
                        new Node(6, new List<Node>())
                    }),
                    new Node(2, new List<Node>()),
                    new Node(4, new List<Node>())
                }));
            Assert.Equal([1, 3, 5, 6, 2, 4], result);
        }
    }
}
