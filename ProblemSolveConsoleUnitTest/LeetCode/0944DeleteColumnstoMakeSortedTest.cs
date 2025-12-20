using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0944DeleteColumnstoMakeSortedTest
    {
        private _0944DeleteColumnstoMakeSorted _0944DeleteColumnstoMakeSorted;

        public _0944DeleteColumnstoMakeSortedTest()
        {
            _0944DeleteColumnstoMakeSorted = new _0944DeleteColumnstoMakeSorted();
        }

        [Fact]
        public void Test1()
        {
            int result = _0944DeleteColumnstoMakeSorted.MinDeletionSize(["cba", "daf", "ghi"]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0944DeleteColumnstoMakeSorted.MinDeletionSize(["a", "b"]);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0944DeleteColumnstoMakeSorted.MinDeletionSize(["zyx", "wvu", "tsr"]);
            Assert.Equal(3, result);
        }
    }
}
