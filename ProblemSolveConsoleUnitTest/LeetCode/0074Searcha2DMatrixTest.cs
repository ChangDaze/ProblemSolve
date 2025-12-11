using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0074Searcha2DMatrixTest
    {
        private _0074Searcha2DMatrix _0074Searcha2DMatrix;

        public _0074Searcha2DMatrixTest()
        {
            _0074Searcha2DMatrix = new _0074Searcha2DMatrix();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0074Searcha2DMatrix.SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 3);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0074Searcha2DMatrix.SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 13);
            Assert.False(result);
        }
    }
}
