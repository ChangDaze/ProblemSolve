using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1878GetBiggestThreeRhombusSumsinaGridTest
    {
        private _1878GetBiggestThreeRhombusSumsinaGrid _1878GetBiggestThreeRhombusSumsinaGrid;

        public _1878GetBiggestThreeRhombusSumsinaGridTest()
        {
            _1878GetBiggestThreeRhombusSumsinaGrid = new _1878GetBiggestThreeRhombusSumsinaGrid();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _1878GetBiggestThreeRhombusSumsinaGrid.GetBiggestThree([[3, 4, 5, 1, 3], [3, 3, 4, 2, 3], [20, 30, 200, 40, 10], [1, 5, 5, 4, 1], [4, 3, 2, 2, 5]]);
            Assert.Equal([0, 1, 3, 2], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _1878GetBiggestThreeRhombusSumsinaGrid.GetBiggestThree([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
            Assert.Equal([20, 9, 8], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _1878GetBiggestThreeRhombusSumsinaGrid.GetBiggestThree([[7, 7, 7]]);
            Assert.Equal([7], result);
        }
    }
}
