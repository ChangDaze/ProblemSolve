using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0258AddDigitsTest
    {
        private _0258AddDigits _0258AddDigits;

        public _0258AddDigitsTest()
        {
            _0258AddDigits = new _0258AddDigits();
        }
        [Fact]
        public void Test1()
        {
            var result = _0258AddDigits.AddDigits(38);
            Assert.Equal(2, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _0258AddDigits.AddDigits(0);
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _0258AddDigits.AddDigits(10);
            Assert.Equal(1, result);
        }
    }
}
