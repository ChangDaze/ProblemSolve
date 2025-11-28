using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0063UniquePathsIITest
    {
        private _0063UniquePathsII _0063UniquePathsII;

        public _0063UniquePathsIITest()
        {
            _0063UniquePathsII = new _0063UniquePathsII();
        }

        [Fact]
        public void Test1()
        {
            int result = _0063UniquePathsII.UniquePathsWithObstacles([[0, 0, 0], [0, 1, 0], [0, 0, 0]]);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0063UniquePathsII.UniquePathsWithObstacles([[0, 1], [0, 0]]);
            Assert.Equal(1, result);
        }
    }
}
