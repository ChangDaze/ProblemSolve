using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0048RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            //用觀察到的來permutation > 旋轉90度後 column1(反序) = 新row1(正序) => column2,3 ...同理
            //轉180 270 360 都只是多做幾次
            //in place 用 int temp來幫忙 => 因為要inplace所以就不能用上面的方法
            //=> 改用 transpose + 垂直鏡射 =>如果是先垂直鏡射再transpose其實就是anticlock rotate

            //time : O(n)
            //space:O(1)

            //transpose
            for (int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j <= i ; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            //垂直鏡射
            int line = (matrix.Length - 1) / 2;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j <= line; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][matrix[i].Length-1-j];
                    matrix[i][matrix[i].Length - 1 - j] = temp;
                }
            }
        }

        //https://leetcode.com/problems/rotate-image/solutions/18879/ac-java-in-place-solution-with-explanati-r6mh/
        //基本上看這位的
        //https://leetcode.com/problems/rotate-image/solutions/18872/a-common-method-to-rotate-the-image-by-s-tygg/
        //這位有提供反向的
    }
}
