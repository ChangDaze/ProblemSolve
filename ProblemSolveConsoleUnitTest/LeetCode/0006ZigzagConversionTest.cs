using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0006ZigzagConversionTest
    {
        private _0006ZigzagConversion _0006ZigzagConversion;

        public _0006ZigzagConversionTest()
        {
            _0006ZigzagConversion = new _0006ZigzagConversion();
        }

        [Fact]
        public void Test1()
        {
            var result = _0006ZigzagConversion.Convert("PAYPALISHIRING", 3);
            Assert.Equal("PAHNAPLSIIGYIR", result);
        }

        [Fact]
        public void Test2()
        {
            var result = _0006ZigzagConversion.Convert("PAYPALISHIRING", 4);
            Assert.Equal("PINALSIGYAHRPI", result);
        }

        [Fact]
        public void Test3()
        {
            var result = _0006ZigzagConversion.Convert("A", 1);
            Assert.Equal("A", result);
        }
    }
}
