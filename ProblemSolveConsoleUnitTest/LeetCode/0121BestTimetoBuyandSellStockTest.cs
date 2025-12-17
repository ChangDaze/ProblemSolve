using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._0589N_aryTreePreorderTraversal;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0121BestTimetoBuyandSellStockTest
    {

        private _0121BestTimetoBuyandSellStock _0121BestTimetoBuyandSellStock;

        public _0121BestTimetoBuyandSellStockTest()
        {
            _0121BestTimetoBuyandSellStock = new _0121BestTimetoBuyandSellStock();
        }

        [Fact]
        public void Test1()
        {
            int result = _0121BestTimetoBuyandSellStock.MaxProfit([7, 1, 5, 3, 6, 4]);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0121BestTimetoBuyandSellStock.MaxProfit([7, 6, 4, 3, 1]);
            Assert.Equal(0, result);
        }
    }
}
