using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0744FindSmallestLetterGreaterThanTargetTest
    {
        private _0744FindSmallestLetterGreaterThanTarget _0744FindSmallestLetterGreaterThanTarget;

        public _0744FindSmallestLetterGreaterThanTargetTest()
        {
            _0744FindSmallestLetterGreaterThanTarget = new _0744FindSmallestLetterGreaterThanTarget();
        }

        [Fact]
        public void Test1()
        {
            char result = _0744FindSmallestLetterGreaterThanTarget.NextGreatestLetter(['c', 'f', 'j'], 'a');
            Assert.Equal('c', result);
        }

        [Fact]
        public void Test2()
        {
            char result = _0744FindSmallestLetterGreaterThanTarget.NextGreatestLetter(['c', 'f', 'j'], 'c');
            Assert.Equal('f', result);
        }

        [Fact]
        public void Test3()
        {
            char result = _0744FindSmallestLetterGreaterThanTarget.NextGreatestLetter(['x', 'x', 'y', 'y'], 'z');
            Assert.Equal('x', result);
        }
    }
}
