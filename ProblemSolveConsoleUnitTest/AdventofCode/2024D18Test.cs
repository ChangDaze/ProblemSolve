using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D18Test
    {
        private _2024D18 _2024D18;
        public _2024D18Test()
        {
            _2024D18 = new _2024D18();
        }
        [Fact]
        public void GetStepsTest()
        {
            var result = _2024D18.GetSteps(@"5,4
4,2
4,5
3,0
2,1
6,3
2,4
1,5
0,6
3,3
2,6
5,1
1,2
5,5
2,5
6,5
1,4
0,4
6,4
1,1
6,1
1,0
0,5
1,6
2,0", 12, 7);
            Assert.Equal(22, result);
        }
        [Fact]
        public void GetByteTest()
        {
            var result = _2024D18.GetByte(@"5,4
4,2
4,5
3,0
2,1
6,3
2,4
1,5
0,6
3,3
2,6
5,1
1,2
5,5
2,5
6,5
1,4
0,4
6,4
1,1
6,1
1,0
0,5
1,6
2,0", 12, 7);
            Assert.Equal("6,1", result);
        }
    }
}
