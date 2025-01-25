using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D11Test
    {
        private _2024D11 _202411;
        public _2024D11Test()
        {
            _202411 = new _2024D11();
        }
        [Fact]
        public void GetScoresResursiveTest()
        {
            var result = _202411.GetStonesCountResursive(@"125 17");
            Assert.Equal(55312, result);
        }
        [Fact]
        public void GetScoresIterativeTest()
        {
            var result = _202411.GetScoresIterative(@"125 17");
            Assert.Equal(55312, result);
        }
        [Fact]
        public void GetScoresTest()
        {
            var result = _202411.GetScores(@"125 17", 25);
            Assert.Equal(55312, result);
        }
    }
}
