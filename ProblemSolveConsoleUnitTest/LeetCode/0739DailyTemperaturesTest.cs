using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0739DailyTemperaturesTest
    {
        private _0739DailyTemperatures _0739DailyTemperatures;

        public _0739DailyTemperaturesTest()
        {
            _0739DailyTemperatures = new _0739DailyTemperatures();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _0739DailyTemperatures.DailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]);
            Assert.Equal([1, 1, 4, 2, 1, 1, 0, 0], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _0739DailyTemperatures.DailyTemperatures([30, 40, 50, 60]);
            Assert.Equal([1, 1, 1, 0], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _0739DailyTemperatures.DailyTemperatures([30, 60, 90]);
            Assert.Equal([1, 1, 0], result);
        }
    }
}
