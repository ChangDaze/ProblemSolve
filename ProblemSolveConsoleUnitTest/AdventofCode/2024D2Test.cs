using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D2Test
    {
        private _2024D2 _2024D2;

        public _2024D2Test()
        {
            _2024D2 = new _2024D2();
        }
        [Fact]
        public void GetSafeReportsTest()
        {
            var result = _2024D2.GetSafeReports(@"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9");
            Assert.Equal(2, result);
        }
    }
}
