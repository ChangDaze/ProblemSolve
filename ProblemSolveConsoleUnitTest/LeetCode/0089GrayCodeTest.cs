using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0089GrayCodeTest
    {
        private _0089GrayCode _0089GrayCode;

        public _0089GrayCodeTest()
        {
            _0089GrayCode = new _0089GrayCode();
        }

        [Fact]
        public void Test1()
        {
            IList<int> result = _0089GrayCode.GrayCode(2);
            Assert.Equal([0, 1, 3, 2], result);
        }

        [Fact]
        public void Test2()
        {
            IList<int> result = _0089GrayCode.GrayCode(1);
            Assert.Equal([0, 1], result);
        }


        [Fact]
        public void Test3()
        {
            IList<int> result = _0089GrayCode.GrayCode(3);
            Assert.Equal([0, 1, 3, 2, 6, 7, 5, 4], result);
        }
    }
}
