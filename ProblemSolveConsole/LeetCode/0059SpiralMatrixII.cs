using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0059SpiralMatrixII
    {
        public int[][] GenerateMatrix(int n)
        {
            //抄0054SpiralMatrix就好
            //time : O(n)
            //space : O(n)

            int[][] result = new int[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            int count = 0;
            int colStart = 0;
            int colEnd = n - 1;
            int rowStart = 0;
            int rowEnd = n-1;
            

            while (colStart <= colEnd && rowStart <= rowEnd) //因為有規律，所以最後歸於一點時4個迴圈只會有其中一個進入，後面都會因為規律而無法滿足進入條件 => 所以不會多寫
            {
                //右
                for(int i = colStart; i <= colEnd; i++)
                {
                    count++;
                    result[rowStart][i] = count;
                }
                rowStart++; //因為這個rowStart寫完了，所以rowStart++

                //下
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    count++;
                    result[i][colEnd] = count;
                }
                colEnd--;

                //左
                for (int i = colEnd; i >= colStart; i--)
                {
                    count++;
                    result[rowEnd][i] = count;
                }
                rowEnd--;

                //上
                for (int i = rowEnd; i >= rowStart; i--)
                {
                    count++;
                    result[i][colStart] = count;
                }
                colStart++;
            }

            return result;
        }
        //https://leetcode.com/problems/spiral-matrix-ii/solutions/22289/my-super-simple-solution-can-be-used-for-vwv5/
        //大家方法其實基本一樣
    }
}
