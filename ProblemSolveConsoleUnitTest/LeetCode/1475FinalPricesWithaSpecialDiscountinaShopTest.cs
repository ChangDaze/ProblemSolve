using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1475FinalPricesWithaSpecialDiscountinaShopTest
    {
        private _1475FinalPricesWithaSpecialDiscountinaShop _1475FinalPricesWithaSpecialDiscountinaShop;

        public _1475FinalPricesWithaSpecialDiscountinaShopTest()
        {
            _1475FinalPricesWithaSpecialDiscountinaShop = new _1475FinalPricesWithaSpecialDiscountinaShop();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _1475FinalPricesWithaSpecialDiscountinaShop.FinalPrices([8, 4, 6, 2, 3]);
            Assert.Equal([4, 2, 4, 2, 3], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _1475FinalPricesWithaSpecialDiscountinaShop.FinalPrices([1, 2, 3, 4, 5]);
            Assert.Equal([1, 2, 3, 4, 5], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _1475FinalPricesWithaSpecialDiscountinaShop.FinalPrices([10, 1, 1, 6]);
            Assert.Equal([9, 0, 1, 6], result);
        }
    }
}
