using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0686RepeatedStringMatchTest
    {
        private _0686RepeatedStringMatch _0686RepeatedStringMatch;

        public _0686RepeatedStringMatchTest()
        {
            _0686RepeatedStringMatch = new _0686RepeatedStringMatch();
        }

        [Fact]
        public void Test1()
        {
            int result = _0686RepeatedStringMatch.RepeatedStringMatch("abcd", "cdabcdab");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0686RepeatedStringMatch.RepeatedStringMatch("a", "aa");
            Assert.Equal(2, result);
        }
    }
}
