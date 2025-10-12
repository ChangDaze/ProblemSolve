using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0012IntegertoRomanTest
    {
        private _0012IntegertoRoman _0012IntegertoRoman;

        public _0012IntegertoRomanTest()
        {
            _0012IntegertoRoman = new _0012IntegertoRoman();
        }

        [Fact]
        public void Test1()
        {
            var result = _0012IntegertoRoman.IntToRoman(3749);
            Assert.Equal("MMMDCCXLIX", result);
        }

        [Fact]
        public void Test2()
        {
            var result = _0012IntegertoRoman.IntToRoman(58);
            Assert.Equal("LVIII", result);
        }

        [Fact]
        public void Test3()
        {
            var result = _0012IntegertoRoman.IntToRoman(1994);
            Assert.Equal("MCMXCIV", result);
        }
    }
}
