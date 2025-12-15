using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2110NumberofSmoothDescentPeriodsofaStockTest
    {

        private _2110NumberofSmoothDescentPeriodsofaStock _2110NumberofSmoothDescentPeriodsofaStock;

        public _2110NumberofSmoothDescentPeriodsofaStockTest()
        {
            _2110NumberofSmoothDescentPeriodsofaStock = new _2110NumberofSmoothDescentPeriodsofaStock();
        }

        [Fact]
        public void Test1()
        {
            long result = _2110NumberofSmoothDescentPeriodsofaStock.GetDescentPeriods([3, 2, 1, 4]);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Test2()
        {
            long result = _2110NumberofSmoothDescentPeriodsofaStock.GetDescentPeriods([8, 6, 7, 7]);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test3()
        {
            long result = _2110NumberofSmoothDescentPeriodsofaStock.GetDescentPeriods([1]);
            Assert.Equal(1, result);
        }
    }
}
