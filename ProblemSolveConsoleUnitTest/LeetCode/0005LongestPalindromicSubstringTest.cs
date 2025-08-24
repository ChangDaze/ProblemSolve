using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0005LongestPalindromicSubstringTest
    {
        private _0005LongestPalindromicSubstring _0005LongestPalindromicSubstring;

        public _0005LongestPalindromicSubstringTest()
        {
            _0005LongestPalindromicSubstring = new _0005LongestPalindromicSubstring();
        }

        [Fact]
        public void Test1()
        {

            var result = _0005LongestPalindromicSubstring.LongestPalindrome("cbbd");
            Assert.Equal("bb", result);
        }

        [Fact]
        public void Test2()
        {

            var result = _0005LongestPalindromicSubstring.LongestPalindrome("a");
            Assert.Equal("a", result);
        }
    }
}
