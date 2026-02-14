using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0263UglyNumberTest
    {
        private _0263UglyNumber _0263UglyNumber;

        public _0263UglyNumberTest()
        {
            _0263UglyNumber = new _0263UglyNumber();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0263UglyNumber.IsUgly(6);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0263UglyNumber.IsUgly(1);
            Assert.True(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0263UglyNumber.IsUgly(14);
            Assert.False(result);
        }

        [Fact]
        public void Test4()
        {
            bool result = _0263UglyNumber.IsUgly(0);
            Assert.False(result);
        }
    }
}
