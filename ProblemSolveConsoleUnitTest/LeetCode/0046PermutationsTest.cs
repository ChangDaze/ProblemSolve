using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0046PermutationsTest
    {
        private _0046Permutations _0046Permutations;

        public _0046PermutationsTest()
        {
            _0046Permutations = new _0046Permutations();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<int>> result = _0046Permutations.Permute([1, 2, 3]);
            IList<IList<int>> expect = [[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<int>> result = _0046Permutations.Permute([0, 1]);
            IList<IList<int>> expect = [[0, 1], [1, 0]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            IList<IList<int>> result = _0046Permutations.Permute([1]);
            IList<IList<int>> expect = [[1]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
string.Join(";", list
    .Select(inner => string.Join(",", inner.OrderBy(x => x)))
    .OrderBy(s => s));
    }
}
