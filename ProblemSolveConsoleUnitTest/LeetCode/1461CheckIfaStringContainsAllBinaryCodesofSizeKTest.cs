using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1461CheckIfaStringContainsAllBinaryCodesofSizeKTest
    {
        private _1461CheckIfaStringContainsAllBinaryCodesofSizeK _1461CheckIfaStringContainsAllBinaryCodesofSizeK;

        public _1461CheckIfaStringContainsAllBinaryCodesofSizeKTest()
        {
            _1461CheckIfaStringContainsAllBinaryCodesofSizeK = new _1461CheckIfaStringContainsAllBinaryCodesofSizeK();
        }

        [Fact]
        public void Test1()
        {
            bool result = _1461CheckIfaStringContainsAllBinaryCodesofSizeK.HasAllCodes("00110110", 2);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _1461CheckIfaStringContainsAllBinaryCodesofSizeK.HasAllCodes("0110", 1);
            Assert.True(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _1461CheckIfaStringContainsAllBinaryCodesofSizeK.HasAllCodes("0110", 2);
            Assert.False(result);
        }
    }
}
