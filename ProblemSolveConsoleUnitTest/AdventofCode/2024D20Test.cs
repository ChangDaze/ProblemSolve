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
        [Fact]
        public void CountValidCheatsExtensionTest()
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
###############", 40, 2);
            Assert.Equal(2, result);
        }
        [Fact]
        public void CountValidCheatsExtensionTest2()
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
###############", 0, 2);
            Assert.Equal(44, result);
        }
        [Fact]
        public void CountValidCheatsExtensionTest3()
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
###############", 50, 20);
            Assert.Equal(285, result);
        }
    }
}
