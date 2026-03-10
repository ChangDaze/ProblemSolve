using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0796RotateStringTest
    {
        private _0796RotateString _0796RotateString;

        public _0796RotateStringTest()
        {
            _0796RotateString = new _0796RotateString();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0796RotateString.RotateString("abcde", "cdeab");
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0796RotateString.RotateString("abcde", "abced");
            Assert.False(result);
        }


        [Fact]
        public void Test3()
        {
            bool result = _0796RotateString.RotateString("aa", "a");
            Assert.False(result);
        }
    }
}
