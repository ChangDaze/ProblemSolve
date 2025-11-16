using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0054SpiralMatrixTest
    {
        private _0054SpiralMatrix _0054SpiralMatrix;

        public _0054SpiralMatrixTest()
        {
            _0054SpiralMatrix = new _0054SpiralMatrix();
        }

        [Fact]
        public void Test1()
        {
            IList<int> result = _0054SpiralMatrix.SpiralOrder([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
            Assert.Equal([1, 2, 3, 6, 9, 8, 7, 4, 5], result);
        }

        [Fact]
        public void Test2()
        {
            IList<int> result = _0054SpiralMatrix.SpiralOrder([[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]);
            Assert.Equal([1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7], result);
        }
    }
}
