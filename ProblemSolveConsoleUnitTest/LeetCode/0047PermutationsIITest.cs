using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0047PermutationsIITest
    {
        private _0047PermutationsII _0047PermutationsII;

        public _0047PermutationsIITest()
        {
            _0047PermutationsII = new _0047PermutationsII();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<int>> result = _0047PermutationsII.PermuteUnique([1, 1, 2]);
            IList<IList<int>> expect = [[1,1,2],
 [1,2,1],
 [2,1,1]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<int>> result = _0047PermutationsII.PermuteUnique([1, 2, 3]);
            IList<IList<int>> expect = [[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
string.Join(";", list
    .Select(inner => string.Join(",", inner.OrderBy(x => x)))
    .OrderBy(s => s));
    }
}
