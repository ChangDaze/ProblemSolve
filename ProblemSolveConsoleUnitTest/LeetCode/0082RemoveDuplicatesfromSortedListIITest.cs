using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListNode = ProblemSolveConsole.LeetCode._0082RemoveDuplicatesfromSortedListII.ListNode;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0082RemoveDuplicatesfromSortedListIITest
    {
        private _0082RemoveDuplicatesfromSortedListII _0082RemoveDuplicatesfromSortedListII;

        public _0082RemoveDuplicatesfromSortedListIITest()
        {
            _0082RemoveDuplicatesfromSortedListII = new _0082RemoveDuplicatesfromSortedListII();
        }

        [Fact]
        public void Test1()
        {
            ListNode input = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3, new ListNode(4, new ListNode(4, new ListNode(5)))))));
            ListNode expect = new ListNode(1, new ListNode(2, new ListNode(5)));

            ListNode result = _0082RemoveDuplicatesfromSortedListII.DeleteDuplicates(input);
            Assert.Equal(expect, result);
        }

        [Fact]
        public void Test2()
        {
            ListNode input = new ListNode(1, new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3)))));
            ListNode expect = new ListNode(2, new ListNode(3));

            ListNode result = _0082RemoveDuplicatesfromSortedListII.DeleteDuplicates(input);
            Assert.Equal(expect, result);
        }

        [Fact]
        public void Test3()
        {
            ListNode input = new ListNode(1, new ListNode(1));
            ListNode expect = null;

            ListNode result = _0082RemoveDuplicatesfromSortedListII.DeleteDuplicates(input);
            Assert.Equal(expect, result);
        }
    }
}
