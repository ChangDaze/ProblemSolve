using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0485MaxConsecutiveOnesTest
    {
        private _0485MaxConsecutiveOnes _0485MaxConsecutiveOnes;

        public _0485MaxConsecutiveOnesTest()
        {
            _0485MaxConsecutiveOnes = new _0485MaxConsecutiveOnes();
        }

        [Fact]
        public void Test1()
        {
            int result = _0485MaxConsecutiveOnes.FindMaxConsecutiveOnes([1, 1, 0, 1, 1, 1]);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0485MaxConsecutiveOnes.FindMaxConsecutiveOnes([1, 1, 0, 1, 1, 1]);
            Assert.Equal(3, result);
        }
    }
}
