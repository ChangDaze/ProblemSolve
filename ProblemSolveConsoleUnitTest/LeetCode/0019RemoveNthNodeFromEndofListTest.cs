using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0019RemoveNthNodeFromEndofListTest
    {
        private _0019RemoveNthNodeFromEndofList _0019RemoveNthNodeFromEndofList;

        public _0019RemoveNthNodeFromEndofListTest()
        {
            _0019RemoveNthNodeFromEndofList = new _0019RemoveNthNodeFromEndofList();
        }

        [Fact]
        public void Test1()
        {
            var result = _0019RemoveNthNodeFromEndofList.RemoveNthFromEnd(
                new _0019RemoveNthNodeFromEndofList.ListNode(1, 
                    new _0019RemoveNthNodeFromEndofList.ListNode(2,
                        new _0019RemoveNthNodeFromEndofList.ListNode(3,
                            new _0019RemoveNthNodeFromEndofList.ListNode(4,
                                new _0019RemoveNthNodeFromEndofList.ListNode(5, null))))),2
            );
            var expected = 
                new _0019RemoveNthNodeFromEndofList.ListNode(1,
                    new _0019RemoveNthNodeFromEndofList.ListNode(2,
                        new _0019RemoveNthNodeFromEndofList.ListNode(3,
                            new _0019RemoveNthNodeFromEndofList.ListNode(5, null))));

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            _0019RemoveNthNodeFromEndofList.ListNode result = _0019RemoveNthNodeFromEndofList.RemoveNthFromEnd(
                new _0019RemoveNthNodeFromEndofList.ListNode(1), 1
            );
            _0019RemoveNthNodeFromEndofList.ListNode expected = null;

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            _0019RemoveNthNodeFromEndofList.ListNode result = _0019RemoveNthNodeFromEndofList.RemoveNthFromEnd(
                new _0019RemoveNthNodeFromEndofList.ListNode(1,
                    new _0019RemoveNthNodeFromEndofList.ListNode(2, null)), 1
            );
            _0019RemoveNthNodeFromEndofList.ListNode expected =
                new _0019RemoveNthNodeFromEndofList.ListNode(1);

            Assert.Equal(Normalize(expected), Normalize(result));
        }

        private List<int> Normalize(_0019RemoveNthNodeFromEndofList.ListNode head)
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
