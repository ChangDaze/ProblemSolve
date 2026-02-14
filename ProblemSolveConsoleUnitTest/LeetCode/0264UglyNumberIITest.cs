using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0264UglyNumberIITest
    {
        private _0264UglyNumberII _0264UglyNumberII;

        public _0264UglyNumberIITest()
        {
            _0264UglyNumberII = new _0264UglyNumberII();
        }

        [Fact]
        public void Test1()
        {
            int result = _0264UglyNumberII.NthUglyNumber(10);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0264UglyNumberII.NthUglyNumber(1);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0264UglyNumberII.NthUglyNumber(1407);
            Assert.Equal(536870912, result);
        }
    }
}
