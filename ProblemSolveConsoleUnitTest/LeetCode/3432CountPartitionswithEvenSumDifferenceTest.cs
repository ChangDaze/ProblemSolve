using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3432CountPartitionswithEvenSumDifferenceTest
    {
        private _3432CountPartitionswithEvenSumDifference _3432CountPartitionswithEvenSumDifference;

        public _3432CountPartitionswithEvenSumDifferenceTest()
        {
            _3432CountPartitionswithEvenSumDifference = new _3432CountPartitionswithEvenSumDifference();
        }
        [Fact]
        public void Test1()
        {
            var result = _3432CountPartitionswithEvenSumDifference.CountPartitions([10, 10, 3, 7, 6]);
            Assert.Equal(4, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3432CountPartitionswithEvenSumDifference.CountPartitions([1, 2, 2]);
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _3432CountPartitionswithEvenSumDifference.CountPartitions([2, 4, 6, 8]);
            Assert.Equal(3, result);
        }
    }
}
