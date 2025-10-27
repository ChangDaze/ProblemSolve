using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _00184SumTest
    {
        private _00184Sum _00184Sum;

        public _00184SumTest()
        {
            _00184Sum = new _00184Sum();
        }

        [Fact]
        public void Test1()
        {
            var result = _00184Sum.FourSum([1, 0, -1, 0, -2, 2], 0);
            var expected = new List<IList<int>>
            {
                new List<int>(){ -2, -1, 1, 2},
                new List<int>(){ -2, 0, 0, 2},
                new List<int>(){ -1, 0, 0, 1}
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            var result = _00184Sum.FourSum([2, 2, 2, 2, 2], 8);
            var expected = new List<IList<int>>
            {
                new List<int>(){ 2, 2, 2, 2 }
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            var result = _00184Sum.FourSum([0, 0, 0, 1000000000, 1000000000, 1000000000, 1000000000], 1000000000);
            var expected = new List<IList<int>>
            {
                new List<int>(){ 0, 0, 0, 1000000000 }
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Fact]
        public void Test4()
        {
            var result = _00184Sum.FourSum([-1000000000, -1000000000, 1000000000, -1000000000, -1000000000], 294967296);
            var expected = new List<IList<int>>
            {
            };
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        private string Normalize(IList<IList<int>> list) =>
        string.Join(";", list
            .Select(inner => string.Join(",", inner.OrderBy(x => x)))
            .OrderBy(s => s));
    }
}
