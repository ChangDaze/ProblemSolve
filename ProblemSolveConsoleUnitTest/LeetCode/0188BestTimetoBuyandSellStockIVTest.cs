using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0188BestTimetoBuyandSellStockIVTest
    {

        private _0188BestTimetoBuyandSellStockIV _0188BestTimetoBuyandSellStockIV;

        public _0188BestTimetoBuyandSellStockIVTest()
        {
            _0188BestTimetoBuyandSellStockIV = new _0188BestTimetoBuyandSellStockIV();
        }

        [Fact]
        public void Test1()
        {
            int result = _0188BestTimetoBuyandSellStockIV.MaxProfit(2, [2, 4, 1]);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0188BestTimetoBuyandSellStockIV.MaxProfit(2, [3, 2, 6, 5, 0, 3]);
            Assert.Equal(7, result);
        }
    }
}
