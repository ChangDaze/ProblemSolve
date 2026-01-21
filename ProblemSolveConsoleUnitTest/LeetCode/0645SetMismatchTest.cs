using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0645SetMismatchTest
    {
        private _0645SetMismatch _0645SetMismatch;

        public _0645SetMismatchTest()
        {
            _0645SetMismatch = new _0645SetMismatch();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _0645SetMismatch.FindErrorNums([1, 2, 2, 4]);
            Assert.Equal([2, 3], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _0645SetMismatch.FindErrorNums([1, 1]);
            Assert.Equal([1, 2], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _0645SetMismatch.FindErrorNums([2, 2]);
            Assert.Equal([2, 1], result);
        }
    }
}
