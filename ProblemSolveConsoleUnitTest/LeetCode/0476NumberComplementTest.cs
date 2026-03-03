using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0476NumberComplementTest
    {
        private _0476NumberComplement _0476NumberComplement;

        public _0476NumberComplementTest()
        {
            _0476NumberComplement = new _0476NumberComplement();
        }

        [Fact]
        public void Test1()
        {
            int result = _0476NumberComplement.FindComplement(5);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0476NumberComplement.FindComplement(1);
            Assert.Equal(0, result);
        }
    }
}
