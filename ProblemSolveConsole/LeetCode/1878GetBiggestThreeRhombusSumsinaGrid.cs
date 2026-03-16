using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1878GetBiggestThreeRhombusSumsinaGrid
    {
        public int[] GetBiggestThree(int[][] grid)
        {
            //grid可能不是正方形
            int m = grid.Length;
            int n = grid[0].Length;

            SortedSet<int> st = new SortedSet<int>();

            //k為point跟中心的距離
            //top point (i,j) => 每個cell作為top全檢查一遍
            //right point (i + k, j + k)
            //left point (i + k, j - k)
            //bottom point (i + 2k, j)

            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    st.Add(grid[i][j]); // k = 0 rhombus

                    for(int k = 1; ; k++) //k沒限制上限，但當超出邊界就break換檢查下個cell
                    {
                        int down = i + 2 * k;
                        int left = j - k;
                        int right = j + k;

                        if (down >= m || left < 0 || right >= n) break;

                        int sum = 0; //rhombus總和

                        int x = i, y = j;

                        //top -> right (不含right)
                        for(int t = 0; t < k; t++) 
                        {
                            sum += grid[x+t][y+t];
                        }

                        //right -> bottom (不含bottom)
                        for (int t = 0; t < k; t++)
                        {
                            sum += grid[x + k + t][y + k - t];
                        }

                        //bottom -> left (不含left)
                        for (int t = 0; t < k; t++)
                        {
                            sum += grid[x + 2 * k - t][y - t];
                        }

                        //left -> top (不含top)
                        for (int t = 0; t < k; t++)
                        {
                            sum += grid[x + k - t][y - k + t];
                        }

                        st.Add(sum);
                    }
                }
            }

            return st.Reverse().Take(3).ToArray(); //不足3個不會報錯
        }

        //抄這位的
        //https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/solutions/7650942/brute-force-rhombus-enumeration-border-t-8pyi/?envType=daily-question&envId=2026-03-16
    }
}
