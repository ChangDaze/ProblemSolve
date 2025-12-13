using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0079WordSearchTest
    {
        private _0079WordSearch _0079WordSearch;

        public _0079WordSearchTest()
        {
            _0079WordSearch = new _0079WordSearch();
        }

        [Fact]
        public void Test1()
        {
            bool result = _0079WordSearch.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCCED");
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            bool result = _0079WordSearch.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "SEE");
            Assert.True(result);
        }

        [Fact]
        public void Test3()
        {
            bool result = _0079WordSearch.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCB");
            Assert.False(result);
        }

        [Fact]
        public void Test4()
        {
            bool result = _0079WordSearch.Exist([['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A']], "AAAAAAAAAAAAAAa");
            Assert.False(result);
        }

        [Fact]
        public void Test5()
        {
            bool result = _0079WordSearch.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'E', 'S'], ['A', 'D', 'E', 'E']]  , "ABCESEEEFS");
            Assert.True(result);
        }
    }
}
