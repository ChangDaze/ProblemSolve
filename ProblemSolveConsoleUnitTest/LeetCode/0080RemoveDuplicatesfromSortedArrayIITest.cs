using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0080RemoveDuplicatesfromSortedArrayIITest
    {

        private _0080RemoveDuplicatesfromSortedArrayII _0080RemoveDuplicatesfromSortedArrayII;

        public _0080RemoveDuplicatesfromSortedArrayIITest()
        {
            _0080RemoveDuplicatesfromSortedArrayII = new _0080RemoveDuplicatesfromSortedArrayII();
        }

        [Fact]
        public void Test1()
        {
            int[] array = [1, 1, 1, 2, 2, 3];
            int result = _0080RemoveDuplicatesfromSortedArrayII.RemoveDuplicates(array);
            Assert.Equal(5,result);
            Assert.Equal([1, 1, 2, 2, 3, 3], array);
        }

        [Fact]
        public void Test2()
        {
            int[] array = [0, 0, 1, 1, 1, 1, 2, 3, 3];
            int result = _0080RemoveDuplicatesfromSortedArrayII.RemoveDuplicates(array);
            Assert.Equal(7, result);
            Assert.Equal([0, 0, 1, 1, 2, 3, 3, 3, 3], array);
        }
    }
}
