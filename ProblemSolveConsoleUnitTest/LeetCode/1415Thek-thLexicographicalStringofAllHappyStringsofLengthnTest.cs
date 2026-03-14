using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1415Thek_thLexicographicalStringofAllHappyStringsofLengthnTest
    {
        private _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn;

        public _1415Thek_thLexicographicalStringofAllHappyStringsofLengthnTest()
        {
            _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn = new _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn();
        }

        [Fact]
        public void Test1()
        {
            string result = _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn.GetHappyString(1,3);
            Assert.Equal("c", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn.GetHappyString(1, 4);
            Assert.Equal("", result);
        }

        [Fact]
        public void Test3()
        {
            string result = _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn.GetHappyString(3, 9);
            Assert.Equal("cab", result);
        }
    }
}
