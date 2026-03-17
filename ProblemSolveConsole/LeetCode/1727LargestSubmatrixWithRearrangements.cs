using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1727LargestSubmatrixWithRearrangements
    {
        public int LargestSubmatrix(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int ans = 0;

            for(int row = 0; row < m; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    if(matrix[row][col] != 0 && row > 0)//防止超出邊界
                    {
                        matrix[row][col] += matrix[row - 1][col];
                    }
                }

                int[] currRow = new int[n];
                Array.Copy(matrix[row], currRow, n);
                Array.Sort(currRow);
                for(int i = 0; i< n; i++)
                {
                    ans = Math.Max(ans, currRow[i] * (n-i));
                }
            }

            return ans;
        }

        //抄這位
        //https://leetcode.com/problems/largest-submatrix-with-rearrangements/solutions/4187914/largest-submatrix-with-rearrangements-by-cmhr/?envType=daily-question&envId=2026-03-17
    }
}
