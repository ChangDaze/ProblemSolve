using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D9Test
    {
        private _2024D9 _2024D9;
        public _2024D9Test()
        {
            _2024D9 = new _2024D9();
        }
        [Fact]
        public void GetChecksumTest()
        {
            var result = _2024D9.GetChecksum(@"2333133121414131402");
            Assert.Equal(1928, result);
        }
        [Fact]
        public void GetChecksumWithFragmentationTest()
        {
            var result = _2024D9.GetChecksumWithFragmentation(@"2333133121414131402");
            Assert.Equal(2858, result);
        }
        [Fact]
        public void GetChecksumWithFragmentationTest2() //檢查freeSpace[j].StartPoint += usedBlocks[i].Len;
        {
            var result = _2024D9.GetChecksumWithFragmentation(@"233313312");
            Assert.Equal(127, result);
        }
    }
}
