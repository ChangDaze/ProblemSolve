using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0150EvaluateReversePolishNotationTest
    {
        private _0150EvaluateReversePolishNotation _0150EvaluateReversePolishNotation;

        public _0150EvaluateReversePolishNotationTest()
        {
            _0150EvaluateReversePolishNotation = new _0150EvaluateReversePolishNotation();
        }

        [Fact]
        public void Test1()
        {
            int result = _0150EvaluateReversePolishNotation.EvalRPN(["2", "1", "+", "3", "*"]);
            Assert.Equal(9, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0150EvaluateReversePolishNotation.EvalRPN(["4", "13", "5", "/", "+"]);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0150EvaluateReversePolishNotation.EvalRPN(["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]);
            Assert.Equal(22, result);
        }
    }
}
