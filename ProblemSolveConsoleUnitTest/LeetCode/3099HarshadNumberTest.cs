using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3099HarshadNumberTest
    {
        private _3099HarshadNumber _3099HarshadNumber;

        public _3099HarshadNumberTest()
        {
            _3099HarshadNumber = new _3099HarshadNumber();
        }
        [Fact]
        public void Test1()
        {
            var result = _3099HarshadNumber.SumOfTheDigitsOfHarshadNumber(18);
            Assert.Equal(9, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3099HarshadNumber.SumOfTheDigitsOfHarshadNumber(23);
            Assert.Equal(-1, result);
        }
    }
}
