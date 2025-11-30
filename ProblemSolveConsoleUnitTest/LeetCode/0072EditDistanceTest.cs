using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0072EditDistanceTest
    {

        private _0072EditDistance _0072EditDistance;

        public _0072EditDistanceTest()
        {
            _0072EditDistance = new _0072EditDistance();
        }

        [Fact]
        public void Test1()
        {
            int result = _0072EditDistance.MinDistance("horse", "ros");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0072EditDistance.MinDistance("intention", "execution");
            Assert.Equal(5, result);
        }
    }
}
