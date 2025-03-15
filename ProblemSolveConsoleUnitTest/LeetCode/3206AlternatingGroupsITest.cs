using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3206AlternatingGroupsITest
    {
        private _3206AlternatingGroupsI _3206AlternatingGroupsI;

        public _3206AlternatingGroupsITest()
        {
            _3206AlternatingGroupsI = new _3206AlternatingGroupsI();
        }
        [Fact]
        public void Test1()
        {
            var result = _3206AlternatingGroupsI.NumberOfAlternatingGroups([1, 1, 1]);
            Assert.Equal(0, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3206AlternatingGroupsI.NumberOfAlternatingGroups([0, 1, 0, 0, 1]);
            Assert.Equal(3, result);
        }
    }
}
