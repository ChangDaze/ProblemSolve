using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1886DetermineWhetherMatrixCanBeObtainedByRotationTest
    {
        private _1886DetermineWhetherMatrixCanBeObtainedByRotation _1886DetermineWhetherMatrixCanBeObtainedByRotation;

        public _1886DetermineWhetherMatrixCanBeObtainedByRotationTest()
        {
            _1886DetermineWhetherMatrixCanBeObtainedByRotation = new _1886DetermineWhetherMatrixCanBeObtainedByRotation();
        }

        [Fact]
        public void Test1()
        {
            bool result = _1886DetermineWhetherMatrixCanBeObtainedByRotation.FindRotation([[0, 1], [1, 0]], [[1, 0], [0, 1]]);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _1886DetermineWhetherMatrixCanBeObtainedByRotation.FindRotation([[0, 1], [1, 1]], [[1, 0], [0, 1]]);
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _1886DetermineWhetherMatrixCanBeObtainedByRotation.FindRotation([[0, 0, 0], [0, 1, 0], [1, 1, 1]], [[1, 1, 1], [0, 1, 0], [0, 0, 0]]);
            Assert.True(result);
        }
    }
}
