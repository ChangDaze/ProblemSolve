using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D17Test
    {
        private _2024D17 _2024D17;
        public _2024D17Test()
        {
            _2024D17 = new _2024D17();
        }
        [Fact]
        public void GetProgramOutputTest()
        {
            var result = _2024D17.GetProgramOutput(@"Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0");
            Assert.Equal("4,6,3,5,6,3,5,2,1,0", result);
        }
        [Fact]
        public void GetProgramOutputTest2()
        {
            var result = _2024D17.GetProgramOutput(@"Register A: 117440
Register B: 0
Register C: 0

Program: 0,3,5,4,3,0");
            Assert.Equal("0,3,5,4,3,0", result);
        }        
        [Fact]
        public void GetSameOutputRegisterATest()
        {
            var result = _2024D17.GetSameOutputRegisterA(@"Register A: 117440
Register B: 0
Register C: 0

Program: 0,3,5,4,3,0");
            Assert.Equal(117440, result);
        }
//        [Fact]
//        public void GetProgramOutputTest4() //因為溢位不能跑
//        {
//            var result = _2024D17.GetProgramOutput(@"Register A: 190384615275535
//Register B: 0
//Register C: 0

//Program: 2,4,1,2,7,5,4,5,0,3,1,7,5,5,3,0");
//            Assert.Equal("2,4,1,2,7,5,4,5,0,3,1,7,5,5,3,0", result);
//        }
    }
}
