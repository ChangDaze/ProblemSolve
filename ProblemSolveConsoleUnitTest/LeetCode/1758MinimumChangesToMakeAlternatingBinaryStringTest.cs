using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1758MinimumChangesToMakeAlternatingBinaryStringTest
    {
        private _1758MinimumChangesToMakeAlternatingBinaryString _1758MinimumChangesToMakeAlternatingBinaryString;

        public _1758MinimumChangesToMakeAlternatingBinaryStringTest()
        {
            _1758MinimumChangesToMakeAlternatingBinaryString = new _1758MinimumChangesToMakeAlternatingBinaryString();
        }

        [Fact]
        public void Test1()
        {
            int result = _1758MinimumChangesToMakeAlternatingBinaryString.MinOperations("0100");
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1758MinimumChangesToMakeAlternatingBinaryString.MinOperations("10");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1758MinimumChangesToMakeAlternatingBinaryString.MinOperations("1111");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _1758MinimumChangesToMakeAlternatingBinaryString.MinOperations("10010100");
            Assert.Equal(3, result);
        }


        [Fact]
        public void Test5()
        {
            int result = _1758MinimumChangesToMakeAlternatingBinaryString.MinOperations("0000000000");
            Assert.Equal(5, result);
        }


        [Fact]
        public void Test6()
        {
            int result = _1758MinimumChangesToMakeAlternatingBinaryString.MinOperations("0000111");
            Assert.Equal(3, result);
        }
    }
}
