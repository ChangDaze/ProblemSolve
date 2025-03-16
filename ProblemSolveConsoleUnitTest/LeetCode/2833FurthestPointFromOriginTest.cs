using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2833FurthestPointFromOriginTest
    {
        private _2833FurthestPointFromOrigin _2833FurthestPointFromOrigin;

        public _2833FurthestPointFromOriginTest()
        {
            _2833FurthestPointFromOrigin = new _2833FurthestPointFromOrigin();
        }
        [Fact]
        public void Test1()
        {
            var result = _2833FurthestPointFromOrigin.FurthestDistanceFromOrigin("L_RL__R");
            Assert.Equal(3, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _2833FurthestPointFromOrigin.FurthestDistanceFromOrigin("_R__LL_");
            Assert.Equal(5, result);
        }
        [Fact]
        public void Test3()
        {
            var result = _2833FurthestPointFromOrigin.FurthestDistanceFromOrigin("_______");
            Assert.Equal(7, result);
        }
    }
}
