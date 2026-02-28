using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1680ConcatenationofConsecutiveBinaryNumbersTest
    {
        private _1680ConcatenationofConsecutiveBinaryNumbers _1680ConcatenationofConsecutiveBinaryNumbers;

        public _1680ConcatenationofConsecutiveBinaryNumbersTest()
        {
            _1680ConcatenationofConsecutiveBinaryNumbers = new _1680ConcatenationofConsecutiveBinaryNumbers();
        }

        [Fact]
        public void Test1()
        {
            int result = _1680ConcatenationofConsecutiveBinaryNumbers.ConcatenatedBinary(1);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1680ConcatenationofConsecutiveBinaryNumbers.ConcatenatedBinary(3);
            Assert.Equal(27, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1680ConcatenationofConsecutiveBinaryNumbers.ConcatenatedBinary(12);
            Assert.Equal(505379714, result);
        }
    }
}
