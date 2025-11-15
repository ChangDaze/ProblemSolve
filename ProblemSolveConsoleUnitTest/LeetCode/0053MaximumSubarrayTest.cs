using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0053MaximumSubarrayTest
    {
        private _0053MaximumSubarray _0053MaximumSubarray;

        public _0053MaximumSubarrayTest()
        {
            _0053MaximumSubarray = new _0053MaximumSubarray();
        }

        [Fact]
        public void Test1()
        {
            int result = _0053MaximumSubarray.MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0053MaximumSubarray.MaxSubArray([1]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0053MaximumSubarray.MaxSubArray([5, 4, -1, 7, 8]);
            Assert.Equal(23, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _0053MaximumSubarray.MaxSubArray([-1, 0, -2]);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test5()
        {
            int result = _0053MaximumSubarray.MaxSubArray([-2, -1, -2]);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Test6()
        {
            int result = _0053MaximumSubarray.MaxSubArray([0, -3, 1, 1]);
            Assert.Equal(2, result);
        }
    }
}
