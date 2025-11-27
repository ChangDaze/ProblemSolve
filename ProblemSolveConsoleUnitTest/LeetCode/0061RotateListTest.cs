using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0061RotateListTest
    {
        private _0061RotateList _0061RotateList;

        public _0061RotateListTest()
        {
            _0061RotateList = new _0061RotateList();
        }

        [Fact]
        public void Test1()
        {
            var head = new _0061RotateList.ListNode(1,
                            new _0061RotateList.ListNode(2,
                                new _0061RotateList.ListNode(3,
                                    new _0061RotateList.ListNode(4,
                                        new _0061RotateList.ListNode(5, null)))));
            var result = _0061RotateList.RotateRight(head, 2);
            var answer = new _0061RotateList.ListNode(4,
                            new _0061RotateList.ListNode(5,
                                new _0061RotateList.ListNode(1,
                                    new _0061RotateList.ListNode(2,
                                        new _0061RotateList.ListNode(3, null)))));
            Assert.Equal(answer, result);
        }

        [Fact]
        public void Test2()
        {
            var head = new _0061RotateList.ListNode(0,
                            new _0061RotateList.ListNode(1,
                                new _0061RotateList.ListNode(2)));
            var result = _0061RotateList.RotateRight(head, 4);
            var answer = new _0061RotateList.ListNode(2,
                            new _0061RotateList.ListNode(0,
                                new _0061RotateList.ListNode(1)));
            Assert.Equal(answer, result);
        }


        [Fact]
        public void Test3()
        {
            _0061RotateList.ListNode head = null;
            var result = _0061RotateList.RotateRight(head, 0);
            _0061RotateList.ListNode answer = null;
            Assert.Equal(answer, result);
        }
    }
}
