using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0064MinimumPathSumTest
    {
        private _0064MinimumPathSum _0064MinimumPathSum;

        public _0064MinimumPathSumTest()
        {
            _0064MinimumPathSum = new _0064MinimumPathSum();
        }

        [Fact]
        public void Test1()
        {
            int result = _0064MinimumPathSum.MinPathSum([[1, 3, 1], [1, 5, 1], [4, 2, 1]]);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0064MinimumPathSum.MinPathSum([[1, 2, 3], [4, 5, 6]]);
            Assert.Equal(12, result);
        }
    }
}
