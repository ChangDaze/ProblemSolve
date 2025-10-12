using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _00163SumClosestTest
    {
        private _00163SumClosest _00163SumClosest;

        public _00163SumClosestTest()
        {
            _00163SumClosest = new _00163SumClosest();
        }

        [Fact]
        public void Test1()
        {
            var result = _00163SumClosest.ThreeSumClosest([-1, 2, 1, -4], 1);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            var result = _00163SumClosest.ThreeSumClosest([0, 0, 0], 1);
            Assert.Equal(0, result);
        }
    }
}
