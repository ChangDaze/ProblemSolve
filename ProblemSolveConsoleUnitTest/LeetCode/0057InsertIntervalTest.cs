using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0057InsertIntervalTest
    {
        private _0057InsertInterval _0057InsertInterval;

        public _0057InsertIntervalTest()
        {
            _0057InsertInterval = new _0057InsertInterval();
        }

        [Fact]
        public void Test1()
        {
            int[][] result = _0057InsertInterval.Insert([[1, 3], [6, 9]], [2, 5]);
            Assert.Equal([[1, 5], [6, 9]], result);
        }

        [Fact]
        public void Test2()
        {
            int[][] result = _0057InsertInterval.Insert([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4, 8]);
            Assert.Equal([[1, 2], [3, 10], [12, 16]], result);
        }
    }
}
