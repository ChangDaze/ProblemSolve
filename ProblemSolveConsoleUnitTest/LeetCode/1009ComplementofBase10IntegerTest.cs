using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1009ComplementofBase10IntegerTest
    {
        private _1009ComplementofBase10Integer _1009ComplementofBase10Integer;

        public _1009ComplementofBase10IntegerTest()
        {
            _1009ComplementofBase10Integer = new _1009ComplementofBase10Integer();
        }

        [Fact]
        public void Test1()
        {
            int result = _1009ComplementofBase10Integer.BitwiseComplement(5);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1009ComplementofBase10Integer.BitwiseComplement(7);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1009ComplementofBase10Integer.BitwiseComplement(10);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _1009ComplementofBase10Integer.BitwiseComplement(0);
            Assert.Equal(1, result);
        }
    }
}
