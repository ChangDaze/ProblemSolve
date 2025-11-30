using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0045JumpGameIITest
    {
        private _0045JumpGameII _0045JumpGameII;

        public _0045JumpGameIITest()
        {
            _0045JumpGameII = new _0045JumpGameII();
        }

        [Fact]
        public void Test1()
        {
            int result = _0045JumpGameII.Jump([2, 3, 1, 1, 4]);
            Assert.Equal(2, result);
        }


        [Fact]
        public void Test2()
        {
            int result = _0045JumpGameII.Jump([2, 3, 0, 1, 4]);
            Assert.Equal(2, result);
        }
    }
}
