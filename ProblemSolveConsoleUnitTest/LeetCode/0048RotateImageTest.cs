using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0048RotateImageTest
    {
        private _0048RotateImage _0048RotateImage;

        public _0048RotateImageTest()
        {
            _0048RotateImage = new _0048RotateImage();
        }

        [Fact]
        public void Test1()
        {
            int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            _0048RotateImage.Rotate(matrix);
            Assert.Equal([[7, 4, 1], [8, 5, 2], [9, 6, 3]], matrix);
        }

        [Fact]
        public void Test2()
        {
            int[][] matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
            _0048RotateImage.Rotate(matrix);
            Assert.Equal([[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]], matrix);
        }
    }
}
