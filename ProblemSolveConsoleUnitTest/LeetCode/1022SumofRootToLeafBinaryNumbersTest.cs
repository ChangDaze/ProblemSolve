using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._1022SumofRootToLeafBinaryNumbers;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1022SumofRootToLeafBinaryNumbersTest
    {
        private _1022SumofRootToLeafBinaryNumbers _1022SumofRootToLeafBinaryNumbers;

        public _1022SumofRootToLeafBinaryNumbersTest()
        {
            _1022SumofRootToLeafBinaryNumbers = new _1022SumofRootToLeafBinaryNumbers();
        }

        [Fact]
        public void Test1()
        {
            int result = _1022SumofRootToLeafBinaryNumbers.SumRootToLeaf(
                new TreeNode(1,
                    new TreeNode(0,
                        new TreeNode(0),
                        new TreeNode(1)),
                    new TreeNode(1,
                        new TreeNode(0),
                        new TreeNode(1))
                )
            );
            Assert.Equal(22, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1022SumofRootToLeafBinaryNumbers.SumRootToLeaf(
                new TreeNode(0)
            );
            Assert.Equal(0, result);
        }
    }
}
