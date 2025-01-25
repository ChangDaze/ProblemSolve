using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D10Test
    {
        private _2024D10 _202410;
        public _2024D10Test()
        {
            _202410 = new _2024D10();
        }
        [Fact]
        public void GetScoresTest()
        {
            var result = _202410.GetScores(@"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732");
            Assert.Equal(36, result);
        }
        [Fact]
        public void GetScoresEasyTest()
        {
            var result = _202410.GetScores(@"0123
1234
8765
9876");
            Assert.Equal(1, result);
        }
        [Fact]
        public void GetScores2Test()
        {
            var result = _202410.GetScores2(@"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732");
            Assert.Equal(81, result);
        }
    }
}
