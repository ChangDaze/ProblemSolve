using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1046LastStoneWeightTest
    {
        private _1046LastStoneWeight _1046LastStoneWeight;

        public _1046LastStoneWeightTest()
        {
            _1046LastStoneWeight = new _1046LastStoneWeight();
        }

        [Fact]
        public void Test1()
        {
            int result = _1046LastStoneWeight.LastStoneWeight([2, 7, 4, 1, 8, 1]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1046LastStoneWeight.LastStoneWeight([1]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1046LastStoneWeight.LastStoneWeight([2, 2]);
            Assert.Equal(0, result);
        }
    }
}
