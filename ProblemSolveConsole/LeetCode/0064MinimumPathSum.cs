using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0064MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            //前提:有限制止向下或向右，能向左和向上可能性會大幅增加
            //time : O(nm)
            //space : O(nm)

            int[][] dp = new int[grid.Length][];

            for(int i  = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[i].Length];             
            }

            for(int i  = 0; i < dp.Length; i++)
            {
                for(int j = 0; j < dp[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = grid[i][j];//設置初始值
                    }
                    else if (i == 0)
                    {
                        dp[i][j] = dp[i][j - 1] + grid[i][j];//只有一個鄰近格子
                    }
                    else if (j == 0)
                    {
                        dp[i][j] = dp[i - 1][j] + grid[i][j];//只有一個鄰近格子
                    }
                    else
                    {
                        dp[i][j] = int.Min(dp[i - 1][j],dp[i][j - 1]) + grid[i][j];//Min選最短的路
                    }
                }
            }

            return dp[grid.Length - 1][grid[0].Length-1];
        }
        //https://leetcode.com/problems/minimum-path-sum/solutions/344980/java-details-from-recursion-to-dp-by-hai-r2xl/
        //這個人方法一樣，不過他直接拿grid來用所以不用額外空間，可以稍微記一下
        //https://leetcode.com/problems/minimum-path-sum/solutions/23457/c-dp-by-jianchao-li-miqe/
        //這個有點特別，我原本以為因為要比較MIN和要加grid的關係，不能用一維陣列，這位有用，不過是用column
        //1.宣告一維陣列，by row，然後C++可以預設值grid[0][0]
        //2.把column[0]都先計算好路徑值 > 這是固定的所以可以先算
        //3.開始推進column計算，其中cur[0] += grid[0][j]; 同理step2，都先計算好路徑值 > 這是固定的所以可以先算，後面第二層for就從1開始 > 這可以記起來
    }
}
