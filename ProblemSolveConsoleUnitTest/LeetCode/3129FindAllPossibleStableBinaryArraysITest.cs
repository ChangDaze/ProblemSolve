using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3129FindAllPossibleStableBinaryArraysITest
    {
        private _3129FindAllPossibleStableBinaryArraysI _3129FindAllPossibleStableBinaryArraysI;

        public _3129FindAllPossibleStableBinaryArraysITest()
        {
            _3129FindAllPossibleStableBinaryArraysI = new _3129FindAllPossibleStableBinaryArraysI();
        }

        [Fact]
        public void Test1()
        {
            int result = _3129FindAllPossibleStableBinaryArraysI.NumberOfStableArrays(1, 1, 2);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _3129FindAllPossibleStableBinaryArraysI.NumberOfStableArrays(1, 2, 1);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _3129FindAllPossibleStableBinaryArraysI.NumberOfStableArrays(3, 3, 2);
            Assert.Equal(14, result);
        }
    }
}
