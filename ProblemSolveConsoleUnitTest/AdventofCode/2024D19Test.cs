using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D19Test
    {
        private _2024D19 _2024D19;
        public _2024D19Test()
        {
            _2024D19 = new _2024D19();
        }
        [Fact]
        public void CountDesignsTest()
        {
            var result = _2024D19.CountDesigns(@"r, wr, b, g, bwu, rb, gb, br

brwrr
bggr
gbbr
rrbgbr
ubwu
bwurrg
brgr
bbrgwb");
            Assert.Equal(6, result);
        }
        [Fact]
        public void CountWaysTest()
        {
            var result = _2024D19.CountWays(@"r, wr, b, g, bwu, rb, gb, br

brwrr
bggr
gbbr
rrbgbr
ubwu
bwurrg
brgr
bbrgwb");
            Assert.Equal(16, result);
        }
    }
}
