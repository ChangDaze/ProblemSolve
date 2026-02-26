using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1356SortIntegersbyTheNumberof1BitsTest
    {
        private _1356SortIntegersbyTheNumberof1Bits _1356SortIntegersbyTheNumberof1Bits;

        public _1356SortIntegersbyTheNumberof1BitsTest()
        {
            _1356SortIntegersbyTheNumberof1Bits = new _1356SortIntegersbyTheNumberof1Bits();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _1356SortIntegersbyTheNumberof1Bits.SortByBits([0, 1, 2, 3, 4, 5, 6, 7, 8]);
            Assert.Equal([0, 1, 2, 4, 8, 3, 5, 6, 7], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _1356SortIntegersbyTheNumberof1Bits.SortByBits([1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1]);
            Assert.Equal([1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024], result);
        }
    }
}
