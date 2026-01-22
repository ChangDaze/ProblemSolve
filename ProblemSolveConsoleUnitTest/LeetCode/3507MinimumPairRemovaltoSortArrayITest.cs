using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3507MinimumPairRemovaltoSortArrayITest
    {
        private _3507MinimumPairRemovaltoSortArrayI _3507MinimumPairRemovaltoSortArrayI;

        public _3507MinimumPairRemovaltoSortArrayITest()
        {
            _3507MinimumPairRemovaltoSortArrayI = new _3507MinimumPairRemovaltoSortArrayI();
        }

        [Fact]
        public void Test1()
        {
            int result = _3507MinimumPairRemovaltoSortArrayI.MinimumPairRemoval([5, 2, 3, 1]);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _3507MinimumPairRemovaltoSortArrayI.MinimumPairRemoval([1, 2, 2]);
            Assert.Equal(0, result);
        }
    }
}
