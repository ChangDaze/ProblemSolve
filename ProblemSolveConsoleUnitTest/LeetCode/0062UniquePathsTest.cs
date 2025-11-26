using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0062UniquePathsTest
    {
        private _0062UniquePaths _0062UniquePaths;

        public _0062UniquePathsTest()
        {
            _0062UniquePaths = new _0062UniquePaths();
        }

        [Fact]
        public void Test1()
        {
            int result = _0062UniquePaths.UniquePaths(3, 7);
            Assert.Equal(28, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0062UniquePaths.UniquePaths(3, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0062UniquePaths.UniquePaths(51, 9);
            Assert.Equal(1916797311, result);
        }
    }
}
