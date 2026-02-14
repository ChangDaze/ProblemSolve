using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2974MinimumNumberGameTest
    {
        private _2974MinimumNumberGame _2974MinimumNumberGame;

        public _2974MinimumNumberGameTest()
        {
            _2974MinimumNumberGame = new _2974MinimumNumberGame();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _2974MinimumNumberGame.NumberGame([5, 4, 2, 3]);
            Assert.Equal([3, 2, 5, 4], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _2974MinimumNumberGame.NumberGame([2, 5]);
            Assert.Equal([5, 2], result);
        }
    }
}
