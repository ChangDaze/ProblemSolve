using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1700NumberofStudentsUnabletoEatLunchTest
    {
        private _1700NumberofStudentsUnabletoEatLunch _1700NumberofStudentsUnabletoEatLunch;

        public _1700NumberofStudentsUnabletoEatLunchTest()
        {
            _1700NumberofStudentsUnabletoEatLunch = new _1700NumberofStudentsUnabletoEatLunch();
        }

        [Fact]
        public void Test1()
        {
            int result = _1700NumberofStudentsUnabletoEatLunch.CountStudents([1, 1, 0, 0], [0, 1, 0, 1]);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1700NumberofStudentsUnabletoEatLunch.CountStudents([1, 1, 1, 0, 0, 1], [1, 0, 0, 0, 1, 1]);
            Assert.Equal(3, result);
        }
    }
}
