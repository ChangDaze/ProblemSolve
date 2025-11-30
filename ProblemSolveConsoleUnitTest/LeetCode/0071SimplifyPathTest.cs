using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0071SimplifyPathTest
    {

        private _0071SimplifyPath _0071SimplifyPath;

        public _0071SimplifyPathTest()
        {
            _0071SimplifyPath = new _0071SimplifyPath();
        }

        [Fact]
        public void Test1()
        {
            string result = _0071SimplifyPath.SimplifyPath("/home/");
            Assert.Equal("/home", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _0071SimplifyPath.SimplifyPath("/home//foo/");
            Assert.Equal("/home/foo", result);
        }

        [Fact]
        public void Test3()
        {
            string result = _0071SimplifyPath.SimplifyPath("/home/user/Documents/../Pictures");
            Assert.Equal("/home/user/Pictures", result);
        }

        [Fact]
        public void Test4()
        {
            string result = _0071SimplifyPath.SimplifyPath("/../");
            Assert.Equal("/", result);
        }

        [Fact]
        public void Test5()
        {
            string result = _0071SimplifyPath.SimplifyPath("/.../a/../b/c/../d/./");
            Assert.Equal("/.../b/d", result);
        }
    }
}
