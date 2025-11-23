using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0056MergeIntervalsTest
    {
        private _0056MergeIntervals _0056MergeIntervals;

        public _0056MergeIntervalsTest()
        {
            _0056MergeIntervals = new _0056MergeIntervals();
        }

        [Fact]
        public void Test1()
        {
            int[][] result = _0056MergeIntervals.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]);
            Assert.Equal([[1, 6], [8, 10], [15, 18]], result);
        }

        [Fact]
        public void Test2()
        {
            int[][] result = _0056MergeIntervals.Merge([[1, 4], [4, 5]]);
            Assert.Equal([[1, 5]], result);
        }

        [Fact]
        public void Test3()
        {
            int[][] result = _0056MergeIntervals.Merge([[4, 7], [1, 4]]);
            Assert.Equal([[1, 7]], result);
        }

        [Fact]
        public void Test4()
        {
            int[][] result = _0056MergeIntervals.Merge([[1, 4], [0, 2], [3, 5]]);
            Assert.Equal([[0, 5]], result);
        }
    }
}
