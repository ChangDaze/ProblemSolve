using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._0232ImplementQueueusingStacks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0232ImplementQueueusingStacksTest
    {
        [Fact]
        public void Test1()
        {
            MyQueue myQueue = new MyQueue();
            myQueue.Push(1); // queue is: [1]
            myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
            int peek = myQueue.Peek(); // return 1
            Assert.Equal(1, peek);
            int pop = myQueue.Pop(); // return 1, queue is [2]
            Assert.Equal(1, pop);
            bool empty = myQueue.Empty(); // return false
            Assert.False(empty);
        }
    }
}
