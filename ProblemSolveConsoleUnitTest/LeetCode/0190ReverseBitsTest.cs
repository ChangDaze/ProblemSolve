using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0190ReverseBitsTest
    {
        private _0190ReverseBits _0190ReverseBits;

        public _0190ReverseBitsTest()
        {
            _0190ReverseBits = new _0190ReverseBits();
        }

        [Fact]
        public void Test1()
        {
            int result = _0190ReverseBits.ReverseBits(43261596);
            Assert.Equal(964176192, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0190ReverseBits.ReverseBits(2147483644);
            Assert.Equal(1073741822, result);
        }
    }
}
