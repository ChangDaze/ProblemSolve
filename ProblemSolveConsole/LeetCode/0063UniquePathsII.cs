using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0063UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            //time : O(n)
            //space : O(n)

            int[][] dp = new int[obstacleGrid.Length][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[obstacleGrid[i].Length];
            }

            for (int i = 0;i < dp.Length; i++)
            {
                for(int j = 0; j < dp[i].Length; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i][j] = 0; //阻礙物歸零後續所有路
                    }
                    else if( i == 0 && j == 0)
                    {
                        dp[i][j] = 1;//設置初始值 => 剩下全用dp更新，右下格子的所有path是鄰近格子所有可能相加
                    }
                    else if(i == 0)
                    {
                        dp[i][j] = dp[i][j - 1];//只有一個鄰近格子
                    }
                    else if(j == 0)
                    {
                        dp[i][j] = dp[i-1][j];//只有一個鄰近格子
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }
            }

            return dp[dp.Length - 1][dp[0].Length - 1];
        }

        //https://leetcode.com/problems/unique-paths-ii/solutions/23250/short-java-solution-by-tusizi-xvfm/
        //這個人dp用一維的，算是我這方法的延伸，因為是從上往下的累積，仔細看是dp[j] += dp[j - 1];用+=所以她的dp[j]是row累積的
        //https://leetcode.com/problems/unique-paths-ii/solutions/23248/my-c-dp-solution-very-simple-by-kingmacr-8par/
        //這個人是用多宣告1 row 和 column的方式減少判斷，算是我這方法的延伸

        //上面兩個人的方法都有效減少判斷用的語法，要記住
    }
}
