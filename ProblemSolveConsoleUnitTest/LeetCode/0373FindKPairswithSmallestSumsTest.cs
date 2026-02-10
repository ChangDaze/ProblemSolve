using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0373FindKPairswithSmallestSumsTest
    {
        private _0373FindKPairswithSmallestSums _0373FindKPairswithSmallestSums;

        public _0373FindKPairswithSmallestSumsTest()
        {
            _0373FindKPairswithSmallestSums = new _0373FindKPairswithSmallestSums();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<int>> result = _0373FindKPairswithSmallestSums.KSmallestPairs([1, 7, 11], [2, 4, 6], 3);
            Assert.Equal(Normalize([[1, 2], [1, 4], [1, 6]]), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<int>> result = _0373FindKPairswithSmallestSums.KSmallestPairs([1, 1, 2], [1, 2, 3], 2);
            Assert.Equal(Normalize([[1, 1], [1, 1]]), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            IList<IList<int>> result = _0373FindKPairswithSmallestSums.KSmallestPairs([1, 2, 4, 5, 6], [3, 5, 7, 9], 20);
            Assert.Equal(Normalize([[1, 3], [2, 3], [1, 5], [2, 5], [4, 3], [1, 7], [5, 3], [2, 7], [4, 5], [6, 3], [1, 9], [5, 5], [2, 9], [4, 7], [6, 5], [5, 7], [4, 9], [6, 7], [5, 9], [6, 9]]), Normalize(result));
        }

        [Fact]
        public void Test4()
        {
            IList<IList<int>> result = _0373FindKPairswithSmallestSums.KSmallestPairs([1, 2, 4, 5, 6], [3, 5, 7, 9], 3);
            Assert.Equal(Normalize([[1, 3], [2, 3], [1, 5]]), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
        string.Join(";", list
            .Select(inner => string.Join(",", inner.OrderBy(x => x)))
            .OrderBy(s => s));
    }
}
