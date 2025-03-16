using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3014MinimumNumberofPushestoTypeWordITest
    {
        private _3014MinimumNumberofPushestoTypeWordI _3014MinimumNumberofPushestoTypeWordI;

        public _3014MinimumNumberofPushestoTypeWordITest()
        {
            _3014MinimumNumberofPushestoTypeWordI = new _3014MinimumNumberofPushestoTypeWordI();
        }
        [Fact]
        public void Test1()
        {
            var result = _3014MinimumNumberofPushestoTypeWordI.MinimumPushes("abcde");
            Assert.Equal(5, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3014MinimumNumberofPushestoTypeWordI.MinimumPushes("xycdefghij");
            Assert.Equal(12, result);
        }
    }
}
