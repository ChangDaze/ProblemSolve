using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1590MakeSumDivisiblebyPTest
    {
        private _1590MakeSumDivisiblebyP _1590MakeSumDivisiblebyP;

        public _1590MakeSumDivisiblebyPTest()
        {
            _1590MakeSumDivisiblebyP = new _1590MakeSumDivisiblebyP();
        }

        [Fact]
        public void Test1()
        {
            int result = _1590MakeSumDivisiblebyP.MinSubarray([3, 1, 4, 2], 6);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1590MakeSumDivisiblebyP.MinSubarray([6, 3, 5, 2], 9);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1590MakeSumDivisiblebyP.MinSubarray([1, 2, 3], 3);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _1590MakeSumDivisiblebyP.MinSubarray([1, 2, 3], 7);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Test5()
        {
            int result = _1590MakeSumDivisiblebyP.MinSubarray([1000000000, 1000000000, 1000000000], 3);
            Assert.Equal(0, result);
        }
    }
}
