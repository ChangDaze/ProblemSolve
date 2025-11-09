using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0043MultiplyStringsTest
    {
        private _0043MultiplyStrings _0043MultiplyStrings;

        public _0043MultiplyStringsTest()
        {
            _0043MultiplyStrings = new _0043MultiplyStrings();
        }

        [Fact]
        public void Test1()
        {
            string result = _0043MultiplyStrings.Multiply("2", "3");
            Assert.Equal("6", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _0043MultiplyStrings.Multiply("123", "456");
            Assert.Equal("56088", result);
        }

        [Fact]
        public void Test3()
        {
            string result = _0043MultiplyStrings.Multiply("123456789", "987654321");
            Assert.Equal("121932631112635269", result);
        }

        [Fact]
        public void Test4()
        {
            string result = _0043MultiplyStrings.Multiply("9133", "0");
            Assert.Equal("0", result);
        }
    }
}
