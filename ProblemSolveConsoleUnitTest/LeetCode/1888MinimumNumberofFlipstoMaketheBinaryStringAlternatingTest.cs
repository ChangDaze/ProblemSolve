using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1888MinimumNumberofFlipstoMaketheBinaryStringAlternatingTest
    {
        private _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating;

        public _1888MinimumNumberofFlipstoMaketheBinaryStringAlternatingTest()
        {
            _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating = new _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating();
        }

        [Fact]
        public void Test1()
        {
            int result = _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating.MinFlips("111000");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating.MinFlips("010");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating.MinFlips("1110");
            Assert.Equal(1, result);
        }
    }
}
