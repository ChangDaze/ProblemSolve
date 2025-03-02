using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2176CountEqualandDivisiblePairsinanArrayTest
    {
        private _2176CountEqualandDivisiblePairsinanArray _2176CountEqualandDivisiblePairsinanArray;

        public _2176CountEqualandDivisiblePairsinanArrayTest()
        {
            _2176CountEqualandDivisiblePairsinanArray = new _2176CountEqualandDivisiblePairsinanArray();
        }
        [Fact]
        public void Test1()
        {
            var result = _2176CountEqualandDivisiblePairsinanArray.CountPairs([3, 1, 2, 2, 2, 1, 3],2);
            Assert.Equal(4, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2176CountEqualandDivisiblePairsinanArray.CountPairs([1, 2, 3, 4], 1);
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _2176CountEqualandDivisiblePairsinanArray.CountPairs([5, 5, 9, 2, 5, 5, 9, 2, 2, 5, 5, 6, 2, 2, 5, 2, 5, 4, 3], 7);
            Assert.Equal(18, result);
        }
        [Fact]
        public void Test4()
        {
            var result = _2176CountEqualandDivisiblePairsinanArray.CountPairs([10, 2, 3, 4, 9, 6, 3, 10, 3, 6, 3, 9, 1], 4);
            Assert.Equal(8, result);
        }
    }
}
