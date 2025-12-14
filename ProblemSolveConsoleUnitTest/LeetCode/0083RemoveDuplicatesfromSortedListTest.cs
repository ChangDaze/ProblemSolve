using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0083RemoveDuplicatesfromSortedListTest
    {
        private _0083RemoveDuplicatesfromSortedList _0083RemoveDuplicatesfromSortedList;

        public _0083RemoveDuplicatesfromSortedListTest()
        {
            _0083RemoveDuplicatesfromSortedList = new _0083RemoveDuplicatesfromSortedList();
        }

        [Fact]
        public void Test1()
        {
            ListNode result = new ListNode(1, new ListNode(1, new ListNode(2)));
            ListNode expect = new ListNode(1, new ListNode(2));

            _0083RemoveDuplicatesfromSortedList.DeleteDuplicates(result);
            Assert.Equal(expect, result);
        }

        [Fact]
        public void Test2()
        {
            ListNode result = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3)))));
            ListNode expect = new ListNode(1, new ListNode(2, new ListNode(3)));

            _0083RemoveDuplicatesfromSortedList.DeleteDuplicates(result);
            Assert.Equal(expect, result);
        }
    }
}
