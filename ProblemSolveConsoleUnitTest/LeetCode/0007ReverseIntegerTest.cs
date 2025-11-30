using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0007ReverseIntegerTest
    {
        private _0007ReverseInteger _0007ReverseInteger;

        public _0007ReverseIntegerTest()
        {
            _0007ReverseInteger = new _0007ReverseInteger();
        }

        [Fact]
        public void Test1()
        {
            int result = _0007ReverseInteger.Reverse(123);
            Assert.Equal(321, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0007ReverseInteger.Reverse(-123);
            Assert.Equal(-321, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0007ReverseInteger.Reverse(120);
            Assert.Equal(21, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _0007ReverseInteger.Reverse(1534236469);
            Assert.Equal(0, result);
        }
    }
}
