using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0073SetMatrixZeroesTest
    {
        private _0073SetMatrixZeroes _0073SetMatrixZeroes;

        public _0073SetMatrixZeroesTest()
        {
            _0073SetMatrixZeroes = new _0073SetMatrixZeroes();
        }

        [Fact]
        public void Test1()
        {
            int[][] matrix = [[1, 1, 1], [1, 0, 1], [1, 1, 1]];
            _0073SetMatrixZeroes.SetZeroes(matrix);
            Assert.Equal([[1, 0, 1], [0, 0, 0], [1, 0, 1]], matrix);
        }

        [Fact]
        public void Test2()
        {
            int[][] matrix = [[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]];
            _0073SetMatrixZeroes.SetZeroes(matrix);
            Assert.Equal([[0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0]], matrix);
        }

        [Fact]
        public void Test3()
        {
            int[][] matrix = [[1, 2, 3, 4], [5, 0, 7, 8], [0, 10, 11, 12], [13, 14, 15, 0]];
            _0073SetMatrixZeroes.SetZeroes(matrix);
            Assert.Equal([[0, 0, 3, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]], matrix);
        }
    }
}
