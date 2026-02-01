using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3010DivideanArrayIntoSubarraysWithMinimumCostITest
    {

        private _3010DivideanArrayIntoSubarraysWithMinimumCostI _3010DivideanArrayIntoSubarraysWithMinimumCostI;

        public _3010DivideanArrayIntoSubarraysWithMinimumCostITest()
        {
            _3010DivideanArrayIntoSubarraysWithMinimumCostI = new _3010DivideanArrayIntoSubarraysWithMinimumCostI();
        }

        [Fact]
        public void Test1()
        {
            int result = _3010DivideanArrayIntoSubarraysWithMinimumCostI.MinimumCost([1, 2, 3, 12]);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _3010DivideanArrayIntoSubarraysWithMinimumCostI.MinimumCost([5, 4, 3]);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _3010DivideanArrayIntoSubarraysWithMinimumCostI.MinimumCost([10, 3, 1, 1]);
            Assert.Equal(12, result);
        }
    }
}
