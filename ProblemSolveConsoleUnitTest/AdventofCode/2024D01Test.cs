using ProblemSolveConsole.AdventofCode;
using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D01Test
    {
        private _2024D01 _2024D01;

        public _2024D01Test()
        {
            _2024D01 = new _2024D01();
        }
        [Fact]
        public void GetTotalDistanceTest()
        {
            var result = _2024D01.GetTotalDistance(@"3   4
4   3
2   5
1   3
3   9
3   3");
            Assert.Equal(11, result);
        }
        [Fact]
        public void GetSimilarityScoreTest()
        {
            var result = _2024D01.GetSimilarityScore(@"3   4
4   3
2   5
1   3
3   9
3   3");
            Assert.Equal(31, result);
        }
    }
}
