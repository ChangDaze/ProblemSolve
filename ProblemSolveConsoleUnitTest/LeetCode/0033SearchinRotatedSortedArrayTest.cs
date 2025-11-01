using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0033SearchinRotatedSortedArrayTest
    {
        private _0033SearchinRotatedSortedArray _0033SearchinRotatedSortedArray;

        public _0033SearchinRotatedSortedArrayTest()
        {
            _0033SearchinRotatedSortedArray = new _0033SearchinRotatedSortedArray();
        }

        [Fact]
        public void Test1()
        {
            int result = _0033SearchinRotatedSortedArray.Search([4, 5, 6, 7, 0, 1, 2], 0);

            Assert.Equal(4, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0033SearchinRotatedSortedArray.Search([4, 5, 6, 7, 0, 1, 2], 3);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0033SearchinRotatedSortedArray.Search([1], 0);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _0033SearchinRotatedSortedArray.Search([1, 3], 2);

            Assert.Equal(-1, result);
        }
    }
}
