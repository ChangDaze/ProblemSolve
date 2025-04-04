using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D17Test
    {
        private _2024D17 _2024D17;
        public _2024D17Test()
        {
            _2024D17 = new _2024D17();
        }
        [Fact]
        public void GetProgramOutputTest()
        {
            var result = _2024D17.GetProgramOutput(@"Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0");
            Assert.Equal("4,6,3,5,6,3,5,2,1,0", result);
        }
    }
}
