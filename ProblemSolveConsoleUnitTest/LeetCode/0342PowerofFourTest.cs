using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0342PowerofFourTest
    {
        private _0342PowerofFour _0342PowerofFour;

        public _0342PowerofFourTest()
        {
            _0342PowerofFour = new _0342PowerofFour();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0342PowerofFour.IsPowerOfFour(16);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0342PowerofFour.IsPowerOfFour(5);
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0342PowerofFour.IsPowerOfFour(1);
            Assert.True(result);
        }
    }
}
