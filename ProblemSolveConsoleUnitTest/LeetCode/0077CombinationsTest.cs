using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0077CombinationsTest
    {
        private _0077Combinations _0077Combinations;

        public _0077CombinationsTest()
        {
            _0077Combinations = new _0077Combinations();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<int>> result = _0077Combinations.Combine(4, 2);
            Assert.Equal(Normalize([[1, 2], [1, 3], [1, 4], [2, 3], [2, 4], [3, 4]]), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<int>> result = _0077Combinations.Combine(1, 1);
            Assert.Equal(Normalize([[1]]), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
        string.Join(";", list
            .Select(inner => string.Join(",", inner.OrderBy(x => x)))
            .OrderBy(s => s));
    }
}
