using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest
{
    public class _1422MaximumScoreAfterSplittingaStringTest
    {
        private _1422MaximumScoreAfterSplittingaString _1422MaximumScoreAfterSplittingaString;

        public _1422MaximumScoreAfterSplittingaStringTest() { 
            _1422MaximumScoreAfterSplittingaString = new _1422MaximumScoreAfterSplittingaString();
        }
        [Fact]
        public void Test1()
        {
            var result = _1422MaximumScoreAfterSplittingaString.MaxScore("011101");
            Assert.Equal(5, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1422MaximumScoreAfterSplittingaString.MaxScore("00111");
            Assert.Equal(5, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _1422MaximumScoreAfterSplittingaString.MaxScore("1111");
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test4()
        {
            var result = _1422MaximumScoreAfterSplittingaString.MaxScore("00");
            Assert.Equal(1, result);
        }
    }
}
