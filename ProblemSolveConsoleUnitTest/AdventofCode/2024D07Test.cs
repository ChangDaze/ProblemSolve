using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D07Test
    {
        private _2024D07 _2024D07;
        public _2024D07Test()
        {
            _2024D07 = new _2024D07();
        }
        [Fact]
        public void GetValidSumTest()
        {
            var result = _2024D07.GetValidSum(@"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20");
            Assert.Equal(3749, result);
        }
        [Fact]
        public void GetValidSum2Test()
        {
            var result = _2024D07.GetValidSum2(@"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20");
            Assert.Equal(11387, result);
        }
    }
}
