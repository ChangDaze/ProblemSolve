using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D12Test
    {
        private _2024D12 _2024D12;
        public _2024D12Test()
        {
            _2024D12 = new _2024D12();
        }
        [Fact]
        public void GetPriceTest()
        {
            var result = _2024D12.GetPrice(@"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE");
            Assert.Equal(1930, result);
        }
        [Fact]
        public void GetPriceTest2()
        {
            var result = _2024D12.GetPrice(@"OOOOO
OXOXO
OOOOO
OXOXO
OOOOO");
            Assert.Equal(772, result);
        }
        [Fact]
        public void GetPriceTest3()
        {
            var result = _2024D12.GetPrice(@"AAAA
BBCD
BBCC
EEEC");
            Assert.Equal(140, result);
        }
        [Fact]
        public void GetDiscountPriceTest()
        {
            var result = _2024D12.GetDiscountPrice(@"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE");
            Assert.Equal(1206, result);
        }
    }
}
