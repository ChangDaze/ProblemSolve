using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1450NumberofStudentsDoingHomeworkataGivenTimeTest
    {
        private _1450NumberofStudentsDoingHomeworkataGivenTime _1450NumberofStudentsDoingHomeworkataGivenTime;

        public _1450NumberofStudentsDoingHomeworkataGivenTimeTest()
        {
            _1450NumberofStudentsDoingHomeworkataGivenTime = new _1450NumberofStudentsDoingHomeworkataGivenTime();
        }
        [Fact]
        public void Test1()
        {
            var result = _1450NumberofStudentsDoingHomeworkataGivenTime.BusyStudent([1, 2, 3], [3, 2, 7], 4);
            Assert.Equal(1, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1450NumberofStudentsDoingHomeworkataGivenTime.BusyStudent([4], [4], 4);
            Assert.Equal(1, result);
        }
    }
}
