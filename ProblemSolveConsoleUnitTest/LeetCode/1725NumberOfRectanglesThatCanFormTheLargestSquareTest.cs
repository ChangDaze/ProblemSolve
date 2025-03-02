using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1725NumberOfRectanglesThatCanFormTheLargestSquareTest
    {
        private _1725NumberOfRectanglesThatCanFormTheLargestSquare _1725NumberOfRectanglesThatCanFormTheLargestSquare;

        public _1725NumberOfRectanglesThatCanFormTheLargestSquareTest()
        {
            _1725NumberOfRectanglesThatCanFormTheLargestSquare = new _1725NumberOfRectanglesThatCanFormTheLargestSquare();
        }
        [Fact]
        public void Test1()
        {
            var result = _1725NumberOfRectanglesThatCanFormTheLargestSquare.CountGoodRectangles([[5, 8], [3, 9], [5, 12], [16, 5]]);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1725NumberOfRectanglesThatCanFormTheLargestSquare.CountGoodRectangles([[2, 3], [3, 7], [4, 3], [3, 7]]);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _1725NumberOfRectanglesThatCanFormTheLargestSquare.CountGoodRectangles([[5, 8], [3, 9], [3, 12]]);
            Assert.Equal(1, result);
        }
    }
}
