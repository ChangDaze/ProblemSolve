using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3120CounttheNumberofSpecialCharactersITest
    {
        private _3120CounttheNumberofSpecialCharactersI _3120CounttheNumberofSpecialCharactersI;

        public _3120CounttheNumberofSpecialCharactersITest()
        {
            _3120CounttheNumberofSpecialCharactersI = new _3120CounttheNumberofSpecialCharactersI();
        }
        [Fact]
        public void Test1()
        {
            var result = _3120CounttheNumberofSpecialCharactersI.NumberOfSpecialChars("aaAbcBC");
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3120CounttheNumberofSpecialCharactersI.NumberOfSpecialChars("abc");
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _3120CounttheNumberofSpecialCharactersI.NumberOfSpecialChars("abBCab");
            Assert.Equal(1, result);
        }
    }
}
