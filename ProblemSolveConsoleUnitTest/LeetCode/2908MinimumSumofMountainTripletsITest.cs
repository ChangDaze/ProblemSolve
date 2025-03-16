using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2908MinimumSumofMountainTripletsITest
    {
        private _2908MinimumSumofMountainTripletsI _2908MinimumSumofMountainTripletsI;

        public _2908MinimumSumofMountainTripletsITest()
        {
            _2908MinimumSumofMountainTripletsI = new _2908MinimumSumofMountainTripletsI();
        }
        [Fact]
        public void Test1()
        {
            var result = _2908MinimumSumofMountainTripletsI.MinimumSum([8, 6, 1, 5, 3]);
            Assert.Equal(9, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2908MinimumSumofMountainTripletsI.MinimumSum([5, 4, 8, 7, 10, 2]);
            Assert.Equal(13, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _2908MinimumSumofMountainTripletsI.MinimumSum([6, 5, 4, 3, 4, 5]);
            Assert.Equal(-1, result);
        }
    }
}
