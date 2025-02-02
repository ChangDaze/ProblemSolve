using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0191Numberof1BitsTest
    {
        private _0191Numberof1Bits _0191Numberof1Bits;

        public _0191Numberof1BitsTest()
        {
            _0191Numberof1Bits = new _0191Numberof1Bits();
        }
        [Fact]
        public void Test1()
        {
            var result = _0191Numberof1Bits.HammingWeight(11);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _0191Numberof1Bits.HammingWeight(128);
            Assert.Equal(1, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _0191Numberof1Bits.HammingWeight(2147483645);
            Assert.Equal(30, result);
        }
    }
}
