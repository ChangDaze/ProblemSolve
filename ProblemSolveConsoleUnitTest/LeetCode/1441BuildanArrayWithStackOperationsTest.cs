using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1441BuildanArrayWithStackOperationsTest
    {
        private _1441BuildanArrayWithStackOperations _1441BuildanArrayWithStackOperations;

        public _1441BuildanArrayWithStackOperationsTest()
        {
            _1441BuildanArrayWithStackOperations = new _1441BuildanArrayWithStackOperations();
        }

        [Fact]
        public void Test1()
        {
            IList<string> result = _1441BuildanArrayWithStackOperations.BuildArray([1, 3], 3);
            Assert.Equal(["Push", "Push", "Pop", "Push"], result);
        }


        [Fact]
        public void Test2()
        {
            IList<string> result = _1441BuildanArrayWithStackOperations.BuildArray([1, 2, 3], 3);
            Assert.Equal(["Push", "Push", "Push"], result);
        }


        [Fact]
        public void Test3()
        {
            IList<string> result = _1441BuildanArrayWithStackOperations.BuildArray([1, 2], 4);
            Assert.Equal(["Push", "Push"], result);
        }
    }
}
