using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2651CalculateDelayedArrivalTimeTest
    {
        private _2651CalculateDelayedArrivalTime _2651CalculateDelayedArrivalTime;

        public _2651CalculateDelayedArrivalTimeTest()
        {
            _2651CalculateDelayedArrivalTime = new _2651CalculateDelayedArrivalTime();
        }
        [Fact]
        public void Test1()
        {
            var result = _2651CalculateDelayedArrivalTime.FindDelayedArrivalTime(15, 5);
            Assert.Equal(20, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2651CalculateDelayedArrivalTime.FindDelayedArrivalTime(13, 11);
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _2651CalculateDelayedArrivalTime.FindDelayedArrivalTime(0, 0);
            Assert.Equal(0, result);
        }
    }
}
