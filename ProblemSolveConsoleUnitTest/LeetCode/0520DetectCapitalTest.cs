using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0520DetectCapitalTest
    {
        private _0520DetectCapital _0520DetectCapital;

        public _0520DetectCapitalTest()
        {
            _0520DetectCapital = new _0520DetectCapital();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0520DetectCapital.DetectCapitalUse("USA");
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0520DetectCapital.DetectCapitalUse("FlaG");
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0520DetectCapital.DetectCapitalUse("ggg");
            Assert.True(result);
        }
    }
}
