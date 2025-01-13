using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D4Test
    {
        private _2024D4 _2024D4;
        public _2024D4Test()
        {
            _2024D4 = new _2024D4();
        }
        [Fact]
        public void GetXMASTest()
        {
            var result = _2024D4.GetXMAS(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX");
            Assert.Equal(18, result);
        }
        [Fact]
        public void GetX_MASTest()
        {
            var result = _2024D4.GetX_MAS(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX");
            Assert.Equal(9, result);
        }
    }
}
