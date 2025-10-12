using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D21Test
    {
        private _2024D21 _2024D21;
        public _2024D21Test()
        {
            _2024D21 = new _2024D21();
        }
        [Fact]
        public void GetComplexityTest()
        {
            var result = _2024D21.GetComplexity(@"029A
980A
179A
456A
379A");
            Assert.Equal(126384, result);
        }
    }
}
