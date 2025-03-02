using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1295FindNumberswithEvenNumberofDigitsTest
    {
        private _1295FindNumberswithEvenNumberofDigits _1295FindNumberswithEvenNumberofDigits;

        public _1295FindNumberswithEvenNumberofDigitsTest()
        {
            _1295FindNumberswithEvenNumberofDigits = new _1295FindNumberswithEvenNumberofDigits();
        }
        [Fact]
        public void Test1()
        {
            var result = _1295FindNumberswithEvenNumberofDigits.FindNumbers([12, 345, 2, 6, 7896]);
            Assert.Equal(2, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1295FindNumberswithEvenNumberofDigits.FindNumbers([555, 901, 482, 1771]);
            Assert.Equal(1, result);
        }
    }
}
