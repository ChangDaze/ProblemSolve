using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2073TimeNeededtoBuyTicketsTest
    {
        private _2073TimeNeededtoBuyTickets _2073TimeNeededtoBuyTickets;

        public _2073TimeNeededtoBuyTicketsTest()
        {
            _2073TimeNeededtoBuyTickets = new _2073TimeNeededtoBuyTickets();
        }

        [Fact]
        public void Test1()
        {
            int result = _2073TimeNeededtoBuyTickets.TimeRequiredToBuy([2, 3, 2], 2);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _2073TimeNeededtoBuyTickets.TimeRequiredToBuy([5, 1, 1, 1], 0);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _2073TimeNeededtoBuyTickets.TimeRequiredToBuy([15, 66, 3, 47, 71, 27, 54, 43, 97, 34, 94, 33, 54, 26, 15, 52, 20, 71, 88, 42, 50, 6, 66, 88, 36, 99, 27, 82, 7, 72], 18);
            Assert.Equal(1457, result);
        }
    }
}
