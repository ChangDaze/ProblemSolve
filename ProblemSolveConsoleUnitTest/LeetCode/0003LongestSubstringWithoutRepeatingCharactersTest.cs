using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0003LongestSubstringWithoutRepeatingCharactersTest
    {
        private _0003LongestSubstringWithoutRepeatingCharacters _0003LongestSubstringWithoutRepeatingCharacters;

        public _0003LongestSubstringWithoutRepeatingCharactersTest()
        {
            _0003LongestSubstringWithoutRepeatingCharacters = new _0003LongestSubstringWithoutRepeatingCharacters();
        }

        [Fact]
        public void Test1()
        {

            var result = _0003LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("abcabcbb");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {

            var result = _0003LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("bbbbb");
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {

            var result = _0003LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("pwwkew");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test4()
        {

            var result = _0003LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("ababab");
            Assert.Equal(2, result);
        }
    }
}
