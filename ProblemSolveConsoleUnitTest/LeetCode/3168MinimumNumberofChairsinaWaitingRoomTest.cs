using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3168MinimumNumberofChairsinaWaitingRoomTest
    {
        private _3168MinimumNumberofChairsinaWaitingRoom _3168MinimumNumberofChairsinaWaitingRoom;

        public _3168MinimumNumberofChairsinaWaitingRoomTest()
        {
            _3168MinimumNumberofChairsinaWaitingRoom = new _3168MinimumNumberofChairsinaWaitingRoom();
        }
        [Fact]
        public void Test1()
        {
            var result = _3168MinimumNumberofChairsinaWaitingRoom.MinimumChairs("EEEEEEE");
            Assert.Equal(7, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3168MinimumNumberofChairsinaWaitingRoom.MinimumChairs("ELELEEL");
            Assert.Equal(2, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _3168MinimumNumberofChairsinaWaitingRoom.MinimumChairs("ELEELEELLL");
            Assert.Equal(3, result);
        }
    }
}
