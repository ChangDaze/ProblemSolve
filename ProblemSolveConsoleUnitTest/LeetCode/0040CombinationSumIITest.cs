using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0040CombinationSumIITest
    {
        private _0040CombinationSumII _0040CombinationSumII;

        public _0040CombinationSumIITest()
        {
            _0040CombinationSumII = new _0040CombinationSumII();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<int>> result = _0040CombinationSumII.CombinationSum2([10, 1, 2, 7, 6, 1, 5], 8);

            Assert.Equal(Normalize([
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<int>> result = _0040CombinationSumII.CombinationSum2([2, 5, 2, 1, 2], 5);

            Assert.Equal(Normalize([
[1,2,2],
[5]
]), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
            string.Join(";", list
                .Select(inner => string.Join(",", inner.OrderBy(x => x)))
                .OrderBy(s => s));
    }
}
