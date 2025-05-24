using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D20Test
    {
        private _2024D20 _2024D20;
        public _2024D20Test()
        {
            _2024D20 = new _2024D20();
        }
        [Fact]
        public void CountValidCheatsTest()
        {
            var result = _2024D20.CountValidCheats(@"###############
#...#...#.....#
#.#.#.#.#.###.#
#S#...#.#.#...#
#######.#.#.###
#######.#.#...#
#######.#.###.#
###..E#...#...#
###.#######.###
#...###...#...#
#.#####.#.###.#
#.#...#.#.#...#
#.#.#.#.#.#.###
#...#...#...###
###############", 40);
            Assert.Equal(2, result);
        }
    }
}
