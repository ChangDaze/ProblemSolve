using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D6Test
    {
        private _2024D6 _2024D6;
        public _2024D6Test()
        {
            _2024D6 = new _2024D6();
        }
        [Fact]
        public void GetOrderSumTest()
        {
            var result = _2024D6.GetVisitSum(@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...");
            Assert.Equal(41, result);
        }
        [Fact]
        public void GetLoopSumTest()
        {
            var result = _2024D6.GetLoopSum(@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...");
            Assert.Equal(6, result);
        }
    }
}
