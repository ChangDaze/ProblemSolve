using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1984MinimumDifferenceBetweenHighestandLowestofKScoresTest
    {
        private _1984MinimumDifferenceBetweenHighestandLowestofKScores _1984MinimumDifferenceBetweenHighestandLowestofKScores;

        public _1984MinimumDifferenceBetweenHighestandLowestofKScoresTest()
        {
            _1984MinimumDifferenceBetweenHighestandLowestofKScores = new _1984MinimumDifferenceBetweenHighestandLowestofKScores();
        }

        [Fact]
        public void Test1()
        {
            int result = _1984MinimumDifferenceBetweenHighestandLowestofKScores.MinimumDifference([90], 1);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1984MinimumDifferenceBetweenHighestandLowestofKScores.MinimumDifference([9, 4, 1, 7], 2);
            Assert.Equal(2, result);
        }
    }
}
