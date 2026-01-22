using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0448FindAllNumbersDisappearedinanArrayTest
    {
        private _0448FindAllNumbersDisappearedinanArray _0448FindAllNumbersDisappearedinanArray;

        public _0448FindAllNumbersDisappearedinanArrayTest()
        {
            _0448FindAllNumbersDisappearedinanArray = new _0448FindAllNumbersDisappearedinanArray();
        }

        [Fact]
        public void Test1()
        {
            IList<int> result = _0448FindAllNumbersDisappearedinanArray.FindDisappearedNumbers([4, 3, 2, 7, 8, 2, 3, 1]);
            Assert.Equal([5, 6], result);
        }

        [Fact]
        public void Test2()
        {
            IList<int> result = _0448FindAllNumbersDisappearedinanArray.FindDisappearedNumbers([1, 1]);
            Assert.Equal([2], result);
        }
    }
}
