using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0055JumpGameTest
    {
        private _0055JumpGame _0055JumpGame;

        public _0055JumpGameTest()
        {
            _0055JumpGame = new _0055JumpGame();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0055JumpGame.CanJump([2, 3, 1, 1, 4]);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0055JumpGame.CanJump([3, 2, 1, 0, 4]);
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0055JumpGame.CanJump([2, 0, 0]);
            Assert.True(result);
        }
    }
}
