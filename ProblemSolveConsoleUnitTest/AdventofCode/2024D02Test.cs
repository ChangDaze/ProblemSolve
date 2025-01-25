using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D02Test
    {
        private _2024D02 _2024D02;

        public _2024D02Test()
        {
            _2024D02 = new _2024D02();
        }
        [Fact]
        public void GetSafeReportsTest()
        {
            var result = _2024D02.GetSafeReports(@"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9");
            Assert.Equal(2, result);
        }
        [Fact]
        public void GetSafeReportsWithDampenerTest()
        {
            var result = _2024D02.GetSafeReportsWithDampener(@"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9");
            Assert.Equal(4, result);
        }
        [Fact]
        public void GetSafeReportsWithDampenerTestIgnoreFirstSpecial()
        {
            var result = _2024D02.GetSafeReportsWithDampener(@"86 85 86 89 92 94 97");
            Assert.Equal(1, result);
        }
        [Fact]
        public void GetSafeReportsWithDampenerTestIgnoreFirstNormal()
        {
            var result = _2024D02.GetSafeReportsWithDampener(@"86 82 81 80");
            Assert.Equal(1, result);
        }
        [Fact]
        public void GetSafeReportsWithDampenerTestTemp()
        {
            var result = _2024D02.GetSafeReportsWithDampener(@"51 52 55 58 60 61 62 61
64 65 67 70 72 74 77 77");
            Assert.Equal(2, result);
        }
        [Fact]
        public void GetSafeReportsWithDampener2Test()
        {
            var result = _2024D02.GetSafeReportsWithDampener2(@"86 85 86 89 92 94 97");
            Assert.Equal(1, result);
        }
    }
}
