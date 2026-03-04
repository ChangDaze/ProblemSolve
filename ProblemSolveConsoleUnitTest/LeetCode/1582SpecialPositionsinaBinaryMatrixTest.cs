using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1582SpecialPositionsinaBinaryMatrixTest
    {
        private _1582SpecialPositionsinaBinaryMatrix _1582SpecialPositionsinaBinaryMatrix;

        public _1582SpecialPositionsinaBinaryMatrixTest()
        {
            _1582SpecialPositionsinaBinaryMatrix = new _1582SpecialPositionsinaBinaryMatrix();
        }

        [Fact]
        public void Test1()
        {
            int result = _1582SpecialPositionsinaBinaryMatrix.NumSpecial([[1, 0, 0], [0, 0, 1], [1, 0, 0]]);
            Assert.Equal(1, result);
        }



        [Fact]
        public void Test2()
        {
            int result = _1582SpecialPositionsinaBinaryMatrix.NumSpecial([[1, 0, 0], [0, 1, 0], [0, 0, 1]]);
            Assert.Equal(3, result);
        }
    }
}
