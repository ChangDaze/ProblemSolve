using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0034FindFirstandLastPositionofElementinSortedArrayTest
    {
        private _0034FindFirstandLastPositionofElementinSortedArray _0034FindFirstandLastPositionofElementinSortedArray;

        public _0034FindFirstandLastPositionofElementinSortedArrayTest()
        {
            _0034FindFirstandLastPositionofElementinSortedArray = new _0034FindFirstandLastPositionofElementinSortedArray();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _0034FindFirstandLastPositionofElementinSortedArray.SearchRange(
                [5, 7, 7, 8, 8, 10], 8
            );

            Assert.Equal([3, 4], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _0034FindFirstandLastPositionofElementinSortedArray.SearchRange(
                [5, 7, 7, 8, 8, 10], 6
            );

            Assert.Equal([-1, -1], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _0034FindFirstandLastPositionofElementinSortedArray.SearchRange(
                [], 0
            );

            Assert.Equal([-1, -1], result);
        }

        [Fact]
        public void Test4()
        {
            int[] result = _0034FindFirstandLastPositionofElementinSortedArray.SearchRange(
                [1], 1
            );

            Assert.Equal([0, 0], result);
        }

        [Fact]
        public void Test5()
        {
            int[] result = _0034FindFirstandLastPositionofElementinSortedArray.SearchRange(
                [2, 2], 2
            );

            Assert.Equal([0, 1], result);
        }

        [Fact]
        public void Test6()
        {
            int[] result = _0034FindFirstandLastPositionofElementinSortedArray.SearchRange(
                [1, 1, 2], 1
            );

            Assert.Equal([0, 1], result);
        }
    }
}
