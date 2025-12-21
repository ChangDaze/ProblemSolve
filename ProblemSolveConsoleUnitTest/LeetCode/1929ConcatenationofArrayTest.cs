using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1929ConcatenationofArrayTest
    {

        private _1929ConcatenationofArray _1929ConcatenationofArray;

        public _1929ConcatenationofArrayTest()
        {
            _1929ConcatenationofArray = new _1929ConcatenationofArray();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _1929ConcatenationofArray.GetConcatenation([1, 2, 1]);
            Assert.Equal([1, 2, 1, 1, 2, 1], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _1929ConcatenationofArray.GetConcatenation([1, 3, 2, 1]);
            Assert.Equal([1, 3, 2, 1, 1, 3, 2, 1], result);
        }
    }
}
