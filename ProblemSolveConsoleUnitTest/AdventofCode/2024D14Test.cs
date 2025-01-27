using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D14Test
    {
        private _2024D14 _2024D14;
        public _2024D14Test()
        {
            _2024D14 = new _2024D14();
        }
        [Fact]
        public void GetGetSafetyFactorTest()
        {
            var result = _2024D14.GetSafetyFactor(@"p=0,4 v=3,-3
p=6,3 v=-1,-3
p=10,3 v=-1,2
p=2,0 v=2,-1
p=0,0 v=1,3
p=3,0 v=-2,-2
p=7,6 v=-1,-3
p=3,0 v=-1,-2
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
p=9,5 v=-3,-3", 11, 7, 100);
            Assert.Equal(12, result);
        }
    }
}
