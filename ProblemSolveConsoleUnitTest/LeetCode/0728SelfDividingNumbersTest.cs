using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0728SelfDividingNumbersTest
    {
        private _0728SelfDividingNumbers _0728SelfDividingNumbers;

        public _0728SelfDividingNumbersTest()
        {
            _0728SelfDividingNumbers = new _0728SelfDividingNumbers();
        }
        [Fact]
        public void Test1()
        {
            var result = _0728SelfDividingNumbers.SelfDividingNumbers(1, 22);
            Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22], result);
        }
        [Fact]
        public void Test2()
        {
            var result = _0728SelfDividingNumbers.SelfDividingNumbers(47, 85);
            Assert.Equal([48, 55, 66, 77], result);
        }
    }
}
