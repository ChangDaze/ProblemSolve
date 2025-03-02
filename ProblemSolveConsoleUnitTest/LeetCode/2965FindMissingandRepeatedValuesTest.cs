using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2965FindMissingandRepeatedValuesTest
    {
        private _2965FindMissingandRepeatedValues _2965FindMissingandRepeatedValues;

        public _2965FindMissingandRepeatedValuesTest()
        {
            _2965FindMissingandRepeatedValues = new _2965FindMissingandRepeatedValues();
        }
        [Fact]
        public void Test1()
        {
            var result = _2965FindMissingandRepeatedValues.FindMissingAndRepeatedValues([[1, 3], [2, 2]]);
            Assert.Equal([2, 4], result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2965FindMissingandRepeatedValues.FindMissingAndRepeatedValues([[9, 1, 7], [8, 9, 2], [3, 4, 6]]);
            Assert.Equal([9, 5], result);
        }
    }
}
