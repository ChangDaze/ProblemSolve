using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0696CountBinarySubstringsTest
    {
        private _0696CountBinarySubstrings _0696CountBinarySubstrings;

        public _0696CountBinarySubstringsTest()
        {
            _0696CountBinarySubstrings = new _0696CountBinarySubstrings();
        }

        [Fact]
        public void Test1()
        {
            int result = _0696CountBinarySubstrings.CountBinarySubstrings("00110011");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0696CountBinarySubstrings.CountBinarySubstrings("10101");
            Assert.Equal(4, result);
        }
    }
}
