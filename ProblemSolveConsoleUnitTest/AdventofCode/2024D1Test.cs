using ProblemSolveConsole.AdventofCode;
using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D1Test
    {
        private _2024D1 _2024D1;

        public _2024D1Test()
        {
            _2024D1 = new _2024D1();
        }
        [Fact]
        public void TestQ1_1()
        {
            var result = _2024D1.GetTotalDistance(@"3   4
4   3
2   5
1   3
3   9
3   3");
            Assert.Equal(11, result);
        }
        [Fact]
        public void TestQ1_2()
        {
            var result = _2024D1.GetSimilarityScore(@"3   4
4   3
2   5
1   3
3   9
3   3");
            Assert.Equal(31, result);
        }
    }
}
