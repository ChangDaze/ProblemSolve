using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0070ClimbingStairsTest
    {

        private _0070ClimbingStairs _0070ClimbingStairs;

        public _0070ClimbingStairsTest()
        {
            _0070ClimbingStairs = new _0070ClimbingStairs();
        }


        [Fact]
        public void Test1()
        {
            int result = _0070ClimbingStairs.ClimbStairs(2);
            Assert.Equal(2, result);
        }


        [Fact]
        public void Test2()
        {
            int result = _0070ClimbingStairs.ClimbStairs(3);
            Assert.Equal(3, result);
        }
    }
}
