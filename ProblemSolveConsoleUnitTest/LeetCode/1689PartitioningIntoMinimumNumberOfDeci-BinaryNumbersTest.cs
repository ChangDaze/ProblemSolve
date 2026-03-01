using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbersTest
    {
        private _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers;

        public _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbersTest()
        {
            _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers = new _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers();
        }

        [Fact]
        public void Test1()
        {
            int result = _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers.MinPartitions("32");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers.MinPartitions("82734");
            Assert.Equal(8, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers.MinPartitions("27346209830709182346");
            Assert.Equal(9, result);
        }
    }
}
