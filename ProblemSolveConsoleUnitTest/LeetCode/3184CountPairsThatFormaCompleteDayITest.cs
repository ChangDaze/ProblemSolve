using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3184CountPairsThatFormaCompleteDayITest
    {
        private _3184CountPairsThatFormaCompleteDayI _3184CountPairsThatFormaCompleteDayI;

        public _3184CountPairsThatFormaCompleteDayITest()
        {
            _3184CountPairsThatFormaCompleteDayI = new _3184CountPairsThatFormaCompleteDayI();
        }
        [Fact]
        public void Test1()
        {
            var result = _3184CountPairsThatFormaCompleteDayI.CountCompleteDayPairs([12, 12, 30, 24, 24]);
            Assert.Equal(2, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3184CountPairsThatFormaCompleteDayI.CountCompleteDayPairs([72, 48, 24, 3]);
            Assert.Equal(3, result);
        }
    }
}
