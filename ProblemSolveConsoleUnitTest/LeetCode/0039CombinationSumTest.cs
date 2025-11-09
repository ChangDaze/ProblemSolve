using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0039CombinationSumTest
    {
        private _0039CombinationSum _0039CombinationSum;

        public _0039CombinationSumTest()
        {
            _0039CombinationSum = new _0039CombinationSum();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<int>> result = _0039CombinationSum.CombinationSum([2, 3, 6, 7], 7);

            Assert.Equal(Normalize([[2, 2, 3], [7]]), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<int>> result = _0039CombinationSum.CombinationSum([2, 3, 5], 8);

            Assert.Equal(Normalize([[2, 2, 2, 2], [2, 3, 3], [3, 5]]), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            IList<IList<int>> result = _0039CombinationSum.CombinationSum([2], 1);

            Assert.Equal(Normalize([]), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
            string.Join(";", list
                .Select(inner => string.Join(",", inner.OrderBy(x => x)))
                .OrderBy(s => s));
    }
}
