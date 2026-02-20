using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0231PowerofTwoTest
    {
        private _0231PowerofTwo _0231PowerofTwo;

        public _0231PowerofTwoTest()
        {
            _0231PowerofTwo = new _0231PowerofTwo();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0231PowerofTwo.IsPowerOfTwo(1);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0231PowerofTwo.IsPowerOfTwo(16);
            Assert.True(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0231PowerofTwo.IsPowerOfTwo(3);
            Assert.False(result);
        }

        [Fact]
        public void Test4()
        {
            bool result = _0231PowerofTwo.IsPowerOfTwo(-16);
            Assert.False(result);
        }
    }
}
