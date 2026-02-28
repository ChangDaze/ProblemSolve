using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0868BinaryGapTest
    {
        private _0868BinaryGap _0868BinaryGap;

        public _0868BinaryGapTest()
        {
            _0868BinaryGap = new _0868BinaryGap();
        }

        [Fact]
        public void Test1()
        {
            int result = _0868BinaryGap.BinaryGap(22);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0868BinaryGap.BinaryGap(8);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0868BinaryGap.BinaryGap(5);
            Assert.Equal(2, result);
        }
    }
}
