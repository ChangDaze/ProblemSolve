using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1470ShuffletheArrayTest
    {
        private _1470ShuffletheArray _1470ShuffletheArray;

        public _1470ShuffletheArrayTest()
        {
            _1470ShuffletheArray = new _1470ShuffletheArray();
        }

        [Fact]
        public void Test1()
        {
            int[] result = _1470ShuffletheArray.Shuffle([2, 5, 1, 3, 4, 7], 3);
            Assert.Equal([2, 3, 5, 4, 1, 7], result);
        }

        [Fact]
        public void Test2()
        {
            int[] result = _1470ShuffletheArray.Shuffle([1, 2, 3, 4, 4, 3, 2, 1], 4);
            Assert.Equal([1, 4, 2, 3, 3, 2, 4, 1], result);
        }

        [Fact]
        public void Test3()
        {
            int[] result = _1470ShuffletheArray.Shuffle([1, 1, 2, 2], 2);
            Assert.Equal([1, 2, 1, 2], result);
        }
    }
}
