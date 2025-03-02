using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1550ThreeConsecutiveOddsTest
    {
        private readonly _1550ThreeConsecutiveOdds _1550ThreeConsecutiveOdds;

        public _1550ThreeConsecutiveOddsTest()
        {
            _1550ThreeConsecutiveOdds = new _1550ThreeConsecutiveOdds();
        }
        [Fact]
        public void Test1()
        {
            var result = _1550ThreeConsecutiveOdds.ThreeConsecutiveOdds([2, 6, 4, 1]);
            Assert.False(result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1550ThreeConsecutiveOdds.ThreeConsecutiveOdds([1, 2, 34, 3, 4, 5, 7, 23, 12]);
            Assert.True(result);
        }
    }
}
