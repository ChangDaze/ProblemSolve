using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0459RepeatedSubstringPatternTest
    {
        private _0459RepeatedSubstringPattern _0459RepeatedSubstringPattern;

        public _0459RepeatedSubstringPatternTest()
        {
            _0459RepeatedSubstringPattern = new _0459RepeatedSubstringPattern();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0459RepeatedSubstringPattern.RepeatedSubstringPattern("abab");
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0459RepeatedSubstringPattern.RepeatedSubstringPattern("aba");
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0459RepeatedSubstringPattern.RepeatedSubstringPattern("abcabcabcabc");
            Assert.True(result);
        }

        [Fact]
        public void Test4()
        {
            bool result = _0459RepeatedSubstringPattern.RepeatedSubstringPattern("ababab");
            Assert.True(result);
        }
    }
}
