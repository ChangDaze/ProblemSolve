﻿using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D3Test
    {
        private _2024D3 _2024D3;
        public _2024D3Test()
        {
            _2024D3 = new _2024D3();
        }
        [Fact]
        public void GetSumTest()
        {
            var result = _2024D3.GetSum(@"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");
            Assert.Equal(161, result);
        }
        [Fact]
        public void GetSumWithInstructionsTest()
        {
            var result = _2024D3.GetSumWithInstructions(@"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
            Assert.Equal(48, result);
        }

    }
}
