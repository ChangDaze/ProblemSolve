using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0955DeleteColumnstoMakeSortedIITest
    {

        private _0955DeleteColumnstoMakeSortedII _0955DeleteColumnstoMakeSortedII;

        public _0955DeleteColumnstoMakeSortedIITest()
        {
            _0955DeleteColumnstoMakeSortedII = new _0955DeleteColumnstoMakeSortedII();
        }

        [Fact]
        public void Test1()
        {
            int result = _0955DeleteColumnstoMakeSortedII.MinDeletionSize(["ca", "bb", "ac"]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _0955DeleteColumnstoMakeSortedII.MinDeletionSize(["xc", "yb", "za"]);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _0955DeleteColumnstoMakeSortedII.MinDeletionSize(["zyx", "wvu", "tsr"]);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _0955DeleteColumnstoMakeSortedII.MinDeletionSize(["xga", "xfb", "yfa"]);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test5()
        {
            int result = _0955DeleteColumnstoMakeSortedII.MinDeletionSize(["vdy", "vei", "zvc", "zld"]);
            Assert.Equal(2, result);
        }
    }
}
