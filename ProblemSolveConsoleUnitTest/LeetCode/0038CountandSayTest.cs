using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0038CountandSayTest
    {
        private _0038CountandSay _0038CountandSay;

        public _0038CountandSayTest()
        {
            _0038CountandSay = new _0038CountandSay();
        }

        [Fact]
        public void Test1()
        {
            string result = _0038CountandSay.CountAndSay(4);

            Assert.Equal("1211", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _0038CountandSay.CountAndSay(1);

            Assert.Equal("1", result);
        }
    }
}
