using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._0589N_aryTreePreorderTraversal;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0122BestTimetoBuyandSellStockIITest
    {

        private _0122BestTimetoBuyandSellStockII _0122BestTimetoBuyandSellStockII;

        public _0122BestTimetoBuyandSellStockIITest()
        {
            _0122BestTimetoBuyandSellStockII = new _0122BestTimetoBuyandSellStockII();
        }

        [Fact]
        public void Test1()
        {
            int result = _0122BestTimetoBuyandSellStockII.MaxProfit([7, 1, 5, 3, 6, 4]);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0122BestTimetoBuyandSellStockII.MaxProfit([1, 2, 3, 4, 5]);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0122BestTimetoBuyandSellStockII.MaxProfit([7, 6, 4, 3, 1]);
            Assert.Equal(0, result);
        }
    }
}
