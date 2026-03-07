using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0504Base7Test
    {
        private _0504Base7 _0504Base7;

        public _0504Base7Test()
        {
            _0504Base7 = new _0504Base7();
        }

        [Fact]
        public void Test1()
        {
            string result = _0504Base7.ConvertToBase7(100);
            Assert.Equal("202", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _0504Base7.ConvertToBase7(-7);
            Assert.Equal("-10", result);
        }

        [Fact]
        public void Test3()
        {
            string result = _0504Base7.ConvertToBase7(0);
            Assert.Equal("0", result);
        }
    }
}
