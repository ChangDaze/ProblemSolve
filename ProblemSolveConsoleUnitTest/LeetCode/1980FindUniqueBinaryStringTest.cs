using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1980FindUniqueBinaryStringTest
    {
        private _1980FindUniqueBinaryString _1980FindUniqueBinaryString;

        public _1980FindUniqueBinaryStringTest()
        {
            _1980FindUniqueBinaryString = new _1980FindUniqueBinaryString();
        }

        [Fact]
        public void Test1()
        {
            string result = _1980FindUniqueBinaryString.FindDifferentBinaryString(["01", "10"]);
            Assert.Contains(result, ["11", "00"]);
        }

        [Fact]
        public void Test2()
        {
            string result = _1980FindUniqueBinaryString.FindDifferentBinaryString(["00", "01"]);
            Assert.Contains(result, ["11", "10"]);
        }

        [Fact]
        public void Test3()
        {
            string result = _1980FindUniqueBinaryString.FindDifferentBinaryString(["111", "011", "001"]);
            Assert.Contains(result, ["101", "000", "010", "100", "110"]);
        }
    }
}
