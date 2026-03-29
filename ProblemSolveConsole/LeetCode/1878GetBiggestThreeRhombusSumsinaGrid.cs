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
            //這就暴力解所以複雜度也好複雜
            //time: O(m*n* m*n * k * logs) => m*n for loop cells ; m*n for rhombus最大k是 m*n/2 ; k for loop 走 rhombus的邊 ; logs for SortedSet
            //space: O(m*n) => 因為set會去重，然後m*n是假設 every position yields a unique sum
            //grid可能不是正方形
            int m = grid.Length;
            int n = grid[0].Length;

            SortedSet<int> st = new SortedSet<int>(); //會由小排到大，理論上用LIST一直跟LAST比，超過才ADD，並控制LIST數量在三應該也可以

            //k為point跟中心的距離
            //top point (i,j) => 每個cell作為top全檢查一遍
            //right point (i + k, j + k)
            //left point (i + k, j - k)
            //bottom point (i + 2k, j)

            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    st.Add(grid[i][j]); // k = 0 的 rhombus

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
                            sum += grid[x+t][y+t]; //sum是計算經過grid的value
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

            return st.Reverse().Take(3).ToArray(); //Take不足3個不會報錯，取最大三個
        }

        //可以優化的部分 1.控制 3個 max 減少sort ; 2.loop從最大開始算，沒超過list就break可以少loop非常多次 ; 3.base on 1 和 2最後可以不用LINQ也會變快
        //https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/solutions/7650942/brute-force-rhombus-enumeration-border-t-8pyi/?envType=daily-question&envId=2026-03-16
        //解題抄這位的，這方法簡單易了但也是暴力解
        //https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/solutions/7641097/get-biggest-three-rhombus-sums-in-a-grid-05ia/
        //官方看來也是暴力解，但不知道為啥寫得有點看不懂 => 應該相比我的方法是有優化但看不懂下次再研究
    }
}
