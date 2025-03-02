using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2960CountTestedDevicesAfterTestOperationsTest
    {
        private _2960CountTestedDevicesAfterTestOperations _2960CountTestedDevicesAfterTestOperations;

        public _2960CountTestedDevicesAfterTestOperationsTest()
        {
            _2960CountTestedDevicesAfterTestOperations = new _2960CountTestedDevicesAfterTestOperations();
        }
        [Fact]
        public void Test1()
        {
            var result = _2960CountTestedDevicesAfterTestOperations.CountTestedDevices([1, 1, 2, 1, 3]);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2960CountTestedDevicesAfterTestOperations.CountTestedDevices([0, 1, 2]);
            Assert.Equal(2, result);
        }
    }
}
