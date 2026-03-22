using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3070CountSubmatriceswithTop_LeftElementandSumLessThank
    {
        public int CountSubmatrices(int[][] grid, int k)
        {
            int result = 0;
            int x = grid.Length;
            int y = grid[0].Length;

            //建立prefixSum
            int[][] map = new int[x][];
            for(int i = 0 ; i < x; i++)
            {
                map[i] = new int[y];
            }

            //loop
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int temp = 0;
                    if (i - 1 >= 0)
                    {
                        temp += map[i-1][j];
                    }

                    if(j - 1 >= 0)
                    {
                        temp += map[i][j-1];
                    }

                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        temp -= map[i - 1][j - 1];
                    }

                    temp += grid[i][j];

                    map[i][j] = temp;

                    if (temp <= k)
                    {                        
                        result++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}
