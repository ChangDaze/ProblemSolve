using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1354ConstructTargetArrayWithMultipleSumsTest
    {
        private _1354ConstructTargetArrayWithMultipleSums _1354ConstructTargetArrayWithMultipleSums;

        public _1354ConstructTargetArrayWithMultipleSumsTest()
        {
            _1354ConstructTargetArrayWithMultipleSums = new _1354ConstructTargetArrayWithMultipleSums();
        }

        [Fact]
        public void Test1()
        {
            bool result = _1354ConstructTargetArrayWithMultipleSums.IsPossible([9, 3, 5]);
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _1354ConstructTargetArrayWithMultipleSums.IsPossible([1, 1, 1, 2]);
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _1354ConstructTargetArrayWithMultipleSums.IsPossible([8, 5]);
            Assert.True(result);
        }

        //[Fact]
        //public void Test4()
        //{
        //    bool result = _1354ConstructTargetArrayWithMultipleSums.IsPossible([1, 1000000000]);
        //    Assert.True(result);
        //}
    }
}
