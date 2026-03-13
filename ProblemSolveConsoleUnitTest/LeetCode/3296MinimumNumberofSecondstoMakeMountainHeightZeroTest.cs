using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3296MinimumNumberofSecondstoMakeMountainHeightZeroTest
    {
        private _3296MinimumNumberofSecondstoMakeMountainHeightZero _3296MinimumNumberofSecondstoMakeMountainHeightZero;

        public _3296MinimumNumberofSecondstoMakeMountainHeightZeroTest()
        {
            _3296MinimumNumberofSecondstoMakeMountainHeightZero = new _3296MinimumNumberofSecondstoMakeMountainHeightZero();
        }

        [Fact]
        public void Test1()
        {
            long result = _3296MinimumNumberofSecondstoMakeMountainHeightZero.MinNumberOfSeconds(4, [2, 1, 1]);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            long result = _3296MinimumNumberofSecondstoMakeMountainHeightZero.MinNumberOfSeconds(10, [3, 2, 2, 4]);
            Assert.Equal(12, result);
        }
    }
}
