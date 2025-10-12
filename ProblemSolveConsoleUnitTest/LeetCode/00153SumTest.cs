using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _00153SumTest
    {
        private _00153Sum _00153Sum;

        public _00153SumTest()
        {
            _00153Sum = new _00153Sum();
        }

        [Fact]
        public void Test1()
        {
            var result = _00153Sum.ThreeSum([-1, 0, 1, 2, -1, -4]);
            var expected = new List<IList<int>>
            {
                new List<int>(){ -1, -1, 2 },
                new List<int>(){ -1, 0, 1 }
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            var result = _00153Sum.ThreeSum([0, 1, 1]);
            var expected = new List<IList<int>>
            {
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            var result = _00153Sum.ThreeSum([0, 0, 0]);
            var expected = new List<IList<int>>
            {
                new List<int>(){ 0, 0, 0 },
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
                string.Join(";", list
                    .Select(inner => string.Join(",", inner.OrderBy(x => x)))
                    .OrderBy(s => s));
    }
}
