using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0075SortColorsTest
    {
        private _0075SortColors _0075SortColors;

        public _0075SortColorsTest()
        {
            _0075SortColors = new _0075SortColors();
        }

        [Fact]
        public void Test1()
        {
            int[] result = [2, 0, 2, 1, 1, 0];
            _0075SortColors.SortColors(result);
            Assert.Equal([0, 0, 1, 1, 2, 2], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = [2, 0, 1];
            _0075SortColors.SortColors(result);
            Assert.Equal([0, 1, 2], result);
        }
    }
}
