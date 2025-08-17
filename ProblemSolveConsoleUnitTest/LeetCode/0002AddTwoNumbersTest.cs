using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0002AddTwoNumbersTest
    {
        private _0002AddTwoNumbers _0002AddTwoNumbers;

        public _0002AddTwoNumbersTest()
        {
            _0002AddTwoNumbers = new _0002AddTwoNumbers();
        }
        [Fact]
        public void Test1()
        {
            var node1 = new _0002AddTwoNumbers.ListNode(2, new _0002AddTwoNumbers.ListNode(4, new _0002AddTwoNumbers.ListNode(3)));
            var node2 = new _0002AddTwoNumbers.ListNode(5, new _0002AddTwoNumbers.ListNode(6, new _0002AddTwoNumbers.ListNode(4)));
            var answer = new _0002AddTwoNumbers.ListNode(7, new _0002AddTwoNumbers.ListNode(0, new _0002AddTwoNumbers.ListNode(8)));

            var result = _0002AddTwoNumbers.AddTwoNumbers(node1, node2);
            Assert.Equal(answer, result);
        }

        [Fact]
        public void Test2()
        {
            var node1 = new _0002AddTwoNumbers.ListNode(0);
            var node2 = new _0002AddTwoNumbers.ListNode(0);
            var answer = new _0002AddTwoNumbers.ListNode(0);

            var result = _0002AddTwoNumbers.AddTwoNumbers(node1, node2);
            Assert.Equal(answer, result);
        }
    }
}
