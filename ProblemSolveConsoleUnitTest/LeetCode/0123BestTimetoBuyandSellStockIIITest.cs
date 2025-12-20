using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0123BestTimetoBuyandSellStockIIITest
    {

        private _0123BestTimetoBuyandSellStockIII _0123BestTimetoBuyandSellStockIII;

        public _0123BestTimetoBuyandSellStockIIITest()
        {
            _0123BestTimetoBuyandSellStockIII = new _0123BestTimetoBuyandSellStockIII();
        }

        [Fact]
        public void Test1()
        {
            int result = _0123BestTimetoBuyandSellStockIII.MaxProfit([3, 3, 5, 0, 0, 3, 1, 4]);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0123BestTimetoBuyandSellStockIII.MaxProfit([1, 2, 3, 4, 5]);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0123BestTimetoBuyandSellStockIII.MaxProfit([7, 6, 4, 3, 1]);
            Assert.Equal(0, result);
        }
    }
}
