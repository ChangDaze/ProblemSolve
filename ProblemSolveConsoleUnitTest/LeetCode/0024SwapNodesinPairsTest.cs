using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0024SwapNodesinPairsTest
    {
        private _0024SwapNodesinPairs _0024SwapNodesinPairs;

        public _0024SwapNodesinPairsTest()
        {
            _0024SwapNodesinPairs = new _0024SwapNodesinPairs();
        }

        [Fact]
        public void Test1()
        {
            _0024SwapNodesinPairs.ListNode result = _0024SwapNodesinPairs.SwapPairs(
                new _0024SwapNodesinPairs.ListNode(1,
                    new _0024SwapNodesinPairs.ListNode(2,
                        new _0024SwapNodesinPairs.ListNode(3,
                            new _0024SwapNodesinPairs.ListNode(4, null)))));
            _0024SwapNodesinPairs.ListNode expected =
                new _0024SwapNodesinPairs.ListNode(2,
                    new _0024SwapNodesinPairs.ListNode(1,
                        new _0024SwapNodesinPairs.ListNode(4,
                            new _0024SwapNodesinPairs.ListNode(3, null))));

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            _0024SwapNodesinPairs.ListNode result = _0024SwapNodesinPairs.SwapPairs(null);
            _0024SwapNodesinPairs.ListNode expected = null;

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            _0024SwapNodesinPairs.ListNode result = _0024SwapNodesinPairs.SwapPairs(
                new _0024SwapNodesinPairs.ListNode(1, null));
            _0024SwapNodesinPairs.ListNode expected =
                new _0024SwapNodesinPairs.ListNode(1, null);

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test4()
        {
            var result = _0024SwapNodesinPairs.SwapPairs(
                new _0024SwapNodesinPairs.ListNode(1,
                    new _0024SwapNodesinPairs.ListNode(2,
                        new _0024SwapNodesinPairs.ListNode(3, null))));
            var expected =
                new _0024SwapNodesinPairs.ListNode(2,
                    new _0024SwapNodesinPairs.ListNode(1,
                        new _0024SwapNodesinPairs.ListNode(3, null)));

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        private List<int> Normalize(_0024SwapNodesinPairs.ListNode head)
        {
            var list = new List<int>();
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }
            return list;
        }
    }
}
