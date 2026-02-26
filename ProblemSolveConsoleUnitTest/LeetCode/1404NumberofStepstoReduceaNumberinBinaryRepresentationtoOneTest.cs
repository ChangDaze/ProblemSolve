using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOneTest
    {
        private _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne;

        public _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOneTest()
        {
            _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne = new _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne();
        }

        [Fact]
        public void Test1()
        {
            int result = _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne.NumSteps("11000");
            Assert.Equal(6, result);
        }
    }
}
