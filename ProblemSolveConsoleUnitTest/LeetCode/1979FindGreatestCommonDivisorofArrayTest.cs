using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1979FindGreatestCommonDivisorofArrayTest
    {
        private _1979FindGreatestCommonDivisorofArray _1979FindGreatestCommonDivisorofArray;

        public _1979FindGreatestCommonDivisorofArrayTest()
        {
            _1979FindGreatestCommonDivisorofArray = new _1979FindGreatestCommonDivisorofArray();
        }
        [Fact]
        public void Test1()
        {
            var result = _1979FindGreatestCommonDivisorofArray.FindGCD([2, 5, 6, 9, 10]);
            Assert.Equal(2, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1979FindGreatestCommonDivisorofArray.FindGCD([7, 5, 6, 8, 3]);
            Assert.Equal(1, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _1979FindGreatestCommonDivisorofArray.FindGCD([3, 3]);
            Assert.Equal(3, result);
        }
    }
}
