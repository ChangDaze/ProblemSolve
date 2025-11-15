using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0049_GroupAnagramsTest
    {
        private _0049_GroupAnagrams _0049_GroupAnagrams;

        public _0049_GroupAnagramsTest()
        {
            _0049_GroupAnagrams = new _0049_GroupAnagrams();
        }

        [Fact]
        public void Test1()
        {
            IList<IList<string>>  result = _0049_GroupAnagrams.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);
            IList<IList<string>> expect = [["bat"],["nat","tan"],["ate","eat","tea"]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        [Fact]
        public void Test2()
        {
            IList<IList<string>> result = _0049_GroupAnagrams.GroupAnagrams([""]);
            IList<IList<string>> expect = [[""]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        [Fact]
        public void Test3()
        {
            IList<IList<string>> result = _0049_GroupAnagrams.GroupAnagrams(["a"]);
            IList<IList<string>> expect = [["a"]];
            Assert.Equal(Normalize(expect), Normalize(result));
        }

        private string Normalize(IList<IList<string>> list) =>
        string.Join(";", list
            .Select(inner => string.Join(",", inner.OrderBy(x => x)))
            .OrderBy(s => s));
    }
}
