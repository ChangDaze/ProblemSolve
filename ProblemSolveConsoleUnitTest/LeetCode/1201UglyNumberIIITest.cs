using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1201UglyNumberIIITest
    {
        private _1201UglyNumberIII _1201UglyNumberIII;

        public _1201UglyNumberIIITest()
        {
            _1201UglyNumberIII = new _1201UglyNumberIII();
        }

        [Fact]
        public void Test1()
        {
            int result = _1201UglyNumberIII.NthUglyNumber(3, 2, 3, 5);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1201UglyNumberIII.NthUglyNumber(4, 2, 3, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1201UglyNumberIII.NthUglyNumber(5, 2, 11, 13);
            Assert.Equal(10, result);
        }
    }
}
