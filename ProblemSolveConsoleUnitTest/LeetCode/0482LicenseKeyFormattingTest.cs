using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0482LicenseKeyFormattingTest
    {
        private _0482LicenseKeyFormatting _0482LicenseKeyFormatting;

        public _0482LicenseKeyFormattingTest()
        {
            _0482LicenseKeyFormatting = new _0482LicenseKeyFormatting();
        }

        [Fact]
        public void Test1()
        {
            string result = _0482LicenseKeyFormatting.LicenseKeyFormatting("5F3Z-2e-9-w", 4);
            Assert.Equal("5F3Z-2E9W", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _0482LicenseKeyFormatting.LicenseKeyFormatting("2-5g-3-J", 2);
            Assert.Equal("2-5G-3J", result);
        }

        [Fact]
        public void Test3()
        {
            string result = _0482LicenseKeyFormatting.LicenseKeyFormatting("--a-a-a-a--", 2);
            Assert.Equal("AA-AA", result);
        }
    }
}
