using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3606CouponCodeValidatorTest
    {
        private _3606CouponCodeValidator _3606CouponCodeValidator;

        public _3606CouponCodeValidatorTest()
        {
            _3606CouponCodeValidator = new _3606CouponCodeValidator();
        }

        [Fact]
        public void Test1()
        {
            IList<string> result = _3606CouponCodeValidator.ValidateCoupons(["SAVE20", "", "PHARMA5", "SAVE@20"], ["restaurant", "grocery", "pharmacy", "restaurant"], [true, true, true, true]);
            Assert.Equal(["PHARMA5", "SAVE20"], result);
        }

        [Fact]
        public void Test2()
        {
            IList<string> result = _3606CouponCodeValidator.ValidateCoupons(["GROCERY15", "ELECTRONICS_50", "DISCOUNT10"], ["grocery", "electronics", "invalid"], [false, true, true]);
            Assert.Equal(["ELECTRONICS_50"], result);
        }

        [Fact]
        public void Test3()
        {
            IList<string> result = _3606CouponCodeValidator.ValidateCoupons(["MI", "b_"], ["pharmacy", "pharmacy"], [true, true]);
            Assert.Equal(["MI", "b_"], result);
        }
    }
}
