using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2068CheckWhetherTwoStringsareAlmostEquivalentTest
    {
        private _2068CheckWhetherTwoStringsareAlmostEquivalent _2068CheckWhetherTwoStringsareAlmostEquivalent;

        public _2068CheckWhetherTwoStringsareAlmostEquivalentTest()
        {
            _2068CheckWhetherTwoStringsareAlmostEquivalent = new _2068CheckWhetherTwoStringsareAlmostEquivalent();
        }
        [Fact]
        public void Test1()
        {
            var result = _2068CheckWhetherTwoStringsareAlmostEquivalent.CheckAlmostEquivalent("aaaa", "bccb");
            Assert.False(result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2068CheckWhetherTwoStringsareAlmostEquivalent.CheckAlmostEquivalent("abcdeef", "abaaacc");
            Assert.True(result);
        }
        [Fact]
        public void Test3()
        {
            var result = _2068CheckWhetherTwoStringsareAlmostEquivalent.CheckAlmostEquivalent("cccddabba", "babababab");
            Assert.True(result);
        }
    }
}
