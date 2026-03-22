using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3070CountSubmatriceswithTop_LeftElementandSumLessThankTest
    {
        private _3070CountSubmatriceswithTop_LeftElementandSumLessThank _3070CountSubmatriceswithTop_LeftElementandSumLessThank;

        public _3070CountSubmatriceswithTop_LeftElementandSumLessThankTest()
        {
            _3070CountSubmatriceswithTop_LeftElementandSumLessThank = new _3070CountSubmatriceswithTop_LeftElementandSumLessThank();
        }

        [Fact]
        public void Test1()
        {
            int result = _3070CountSubmatriceswithTop_LeftElementandSumLessThank.CountSubmatrices([[7, 6, 3], [6, 6, 1]], 18);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _3070CountSubmatriceswithTop_LeftElementandSumLessThank.CountSubmatrices([[7, 2, 9], [1, 5, 0], [2, 6, 6]], 20);
            Assert.Equal(6, result);
        }
    }
}
