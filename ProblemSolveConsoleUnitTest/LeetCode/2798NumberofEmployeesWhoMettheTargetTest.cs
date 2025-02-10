using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2798NumberofEmployeesWhoMettheTargetTest
    {
        private _2798NumberofEmployeesWhoMettheTarget _2798NumberofEmployeesWhoMettheTarget;

        public _2798NumberofEmployeesWhoMettheTargetTest()
        {
            _2798NumberofEmployeesWhoMettheTarget = new _2798NumberofEmployeesWhoMettheTarget();
        }
        [Fact]
        public void Test1()
        {
            var result = _2798NumberofEmployeesWhoMettheTarget.NumberOfEmployeesWhoMetTarget([0, 1, 2, 3, 4],2);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2798NumberofEmployeesWhoMettheTarget.NumberOfEmployeesWhoMetTarget([5, 1, 4, 2, 2],6);
            Assert.Equal(0, result);
        }
    }
}
