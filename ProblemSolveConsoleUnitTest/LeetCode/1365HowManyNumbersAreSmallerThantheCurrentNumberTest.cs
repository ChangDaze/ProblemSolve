using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1365HowManyNumbersAreSmallerThantheCurrentNumberTest
    {


        private _1365HowManyNumbersAreSmallerThantheCurrentNumber _1365HowManyNumbersAreSmallerThantheCurrentNumber;

        public _1365HowManyNumbersAreSmallerThantheCurrentNumberTest()
        {
            _1365HowManyNumbersAreSmallerThantheCurrentNumber = new _1365HowManyNumbersAreSmallerThantheCurrentNumber();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _1365HowManyNumbersAreSmallerThantheCurrentNumber.SmallerNumbersThanCurrent([8, 1, 2, 2, 3]);
            Assert.Equal([4, 0, 1, 1, 3], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _1365HowManyNumbersAreSmallerThantheCurrentNumber.SmallerNumbersThanCurrent([6, 5, 4, 8]);
            Assert.Equal([2, 1, 0, 3], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _1365HowManyNumbersAreSmallerThantheCurrentNumber.SmallerNumbersThanCurrent([7, 7, 7, 7]);
            Assert.Equal([0, 0, 0, 0], result);
        }
    }
}
