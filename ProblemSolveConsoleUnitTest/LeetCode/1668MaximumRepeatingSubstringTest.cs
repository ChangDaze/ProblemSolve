using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1668MaximumRepeatingSubstringTest
    {


        private _1668MaximumRepeatingSubstring _1668MaximumRepeatingSubstring;

        public _1668MaximumRepeatingSubstringTest()
        {
            _1668MaximumRepeatingSubstring = new _1668MaximumRepeatingSubstring();
        }

        [Fact]
        public void Test1()
        {
            int result = _1668MaximumRepeatingSubstring.MaxRepeating("ababc", "ab");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1668MaximumRepeatingSubstring.MaxRepeating("ababc", "ba");
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1668MaximumRepeatingSubstring.MaxRepeating("ababc", "ac");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _1668MaximumRepeatingSubstring.MaxRepeating("aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba");
            Assert.Equal(5, result);
        }
    }
}
