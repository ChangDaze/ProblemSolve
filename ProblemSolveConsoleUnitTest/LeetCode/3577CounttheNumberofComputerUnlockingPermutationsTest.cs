using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3577CounttheNumberofComputerUnlockingPermutationsTest
    {
        private _3577CounttheNumberofComputerUnlockingPermutations _3577CounttheNumberofComputerUnlockingPermutations;

        public _3577CounttheNumberofComputerUnlockingPermutationsTest()
        {
            _3577CounttheNumberofComputerUnlockingPermutations = new _3577CounttheNumberofComputerUnlockingPermutations();
        }

        [Fact]
        public void Test1()
        {
            int result = _3577CounttheNumberofComputerUnlockingPermutations.CountPermutations([1, 2, 3]);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _3577CounttheNumberofComputerUnlockingPermutations.CountPermutations([3, 3, 3, 4, 4, 4]);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _3577CounttheNumberofComputerUnlockingPermutations.CountPermutations([38, 223, 100, 123, 406, 234, 256, 93, 222, 259, 233, 69, 139, 245, 45, 98, 214]);
            Assert.Equal(789741546, result);
        }
    }
}
