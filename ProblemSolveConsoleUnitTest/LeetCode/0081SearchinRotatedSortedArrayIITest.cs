using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0081SearchinRotatedSortedArrayIITest
    {
        private _0081SearchinRotatedSortedArrayII _0081SearchinRotatedSortedArrayII;

        public _0081SearchinRotatedSortedArrayIITest()
        {
            _0081SearchinRotatedSortedArrayII = new _0081SearchinRotatedSortedArrayII();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0081SearchinRotatedSortedArrayII.Search([2, 5, 6, 0, 0, 1, 2], 0);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0081SearchinRotatedSortedArrayII.Search([2, 5, 6, 0, 0, 1, 2], 3);
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0081SearchinRotatedSortedArrayII.Search([2, 2, 2, 3, 2, 2, 2], 3);
            Assert.True(result);
        }

        [Fact]
        public void Test4()
        {
            bool result = _0081SearchinRotatedSortedArrayII.Search([1], 0);
            Assert.False(result);
        }
    }
}
