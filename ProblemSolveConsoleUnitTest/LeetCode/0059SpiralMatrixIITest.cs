using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0059SpiralMatrixIITest
    {
        private _0059SpiralMatrixII _0059SpiralMatrixII;

        public _0059SpiralMatrixIITest()
        {
            _0059SpiralMatrixII = new _0059SpiralMatrixII();
        }

        [Fact]
        public void Test1()
        {
            int[][] result = _0059SpiralMatrixII.GenerateMatrix(3);
            Assert.Equal([[1, 2, 3], [8, 9, 4], [7, 6, 5]], result);
        }


        [Fact]
        public void Test2()
        {
            int[][] result = _0059SpiralMatrixII.GenerateMatrix(1);
            Assert.Equal([[1]], result);
        }
    }
}
