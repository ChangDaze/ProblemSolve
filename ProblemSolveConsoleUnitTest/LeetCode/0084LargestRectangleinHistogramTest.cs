using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0084LargestRectangleinHistogramTest
    {
        private _0084LargestRectangleinHistogram _0084LargestRectangleinHistogram;

        public _0084LargestRectangleinHistogramTest()
        {
            _0084LargestRectangleinHistogram = new _0084LargestRectangleinHistogram();
        }

        [Fact]
        public void Test1()
        {
            int result = _0084LargestRectangleinHistogram.LargestRectangleArea([2, 1, 5, 6, 2, 3]);
            Assert.Equal(10, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0084LargestRectangleinHistogram.LargestRectangleArea([2, 4]);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0084LargestRectangleinHistogram.LargestRectangleArea([2, 1, 2]);
            Assert.Equal(3, result);
        }
    }
}
