using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0762PrimeNumberofSetBitsinBinaryRepresentationTest
    {
        private _0762PrimeNumberofSetBitsinBinaryRepresentation _0762PrimeNumberofSetBitsinBinaryRepresentation;

        public _0762PrimeNumberofSetBitsinBinaryRepresentationTest()
        {
            _0762PrimeNumberofSetBitsinBinaryRepresentation = new _0762PrimeNumberofSetBitsinBinaryRepresentation();
        }

        [Fact]
        public void Test1()
        {
            int result = _0762PrimeNumberofSetBitsinBinaryRepresentation.CountPrimeSetBits(6 , 10);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0762PrimeNumberofSetBitsinBinaryRepresentation.CountPrimeSetBits(10, 15);
            Assert.Equal(5, result);
        }
    }
}
