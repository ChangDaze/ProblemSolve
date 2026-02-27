using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3666MinimumOperationstoEqualizeBinaryStringTest
    {
        private _3666MinimumOperationstoEqualizeBinaryString _3666MinimumOperationstoEqualizeBinaryString;

        public _3666MinimumOperationstoEqualizeBinaryStringTest()
        {
            _3666MinimumOperationstoEqualizeBinaryString = new _3666MinimumOperationstoEqualizeBinaryString();
        }

        [Fact]
        public void Test1()
        {
            int result = _3666MinimumOperationstoEqualizeBinaryString.MinOperations("110", 1);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _3666MinimumOperationstoEqualizeBinaryString.MinOperations("0101", 3);
            Assert.Equal(2, result);
        }
    }
}
