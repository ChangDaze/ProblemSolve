using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0693BinaryNumberwithAlternatingBitsTest
    {
        private _0693BinaryNumberwithAlternatingBits _0693BinaryNumberwithAlternatingBits;

        public _0693BinaryNumberwithAlternatingBitsTest()
        {
            _0693BinaryNumberwithAlternatingBits = new _0693BinaryNumberwithAlternatingBits();
        }
        [Fact]
        public void Test1()
        {
            var result = _0693BinaryNumberwithAlternatingBits.HasAlternatingBits(5);
            Assert.True(result);
        }
        [Fact]
        public void Test2()
        {
            var result = _0693BinaryNumberwithAlternatingBits.HasAlternatingBits(7);
            Assert.False(result);
        }
        [Fact]
        public void Test3()
        {
            var result = _0693BinaryNumberwithAlternatingBits.HasAlternatingBits(11);
            Assert.False(result);
        }
    }
}
