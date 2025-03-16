using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2395FindSubarraysWithEqualSumTest
    {
        private _2395FindSubarraysWithEqualSum _2395FindSubarraysWithEqualSum;

        public _2395FindSubarraysWithEqualSumTest()
        {
            _2395FindSubarraysWithEqualSum = new _2395FindSubarraysWithEqualSum();
        }
        [Fact]
        public void Test1()
        {
            var result = _2395FindSubarraysWithEqualSum.FindSubarrays([4, 2, 4]);
            Assert.True(result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2395FindSubarraysWithEqualSum.FindSubarrays([1, 2, 3, 4, 5]);
            Assert.False(result);
        }
        [Fact]
        public void Test3()
        {
            var result = _2395FindSubarraysWithEqualSum.FindSubarrays([0, 0, 0]);
            Assert.True(result);
        }
    }
}
