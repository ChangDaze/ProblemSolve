using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3129FindAllPossibleStableBinaryArraysI
    {
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            int mod = 1000000007;

            long[][][] dp = new long[zero + 1][][];
            //long[zero + 1][one + 1][2];
            //index 1 0 ~ zero
            //index 2 0 ~ one 
            //index 3 最後是 append 0 還是 1
            //ex : bp[i][j][0] => 最後是0的情況下有i個0,j個1的所有組合

            for (int i = 0; i <= zero; i++)
            {
                dp[i] = new long[one + 1][];
                for(int j = 0; j <= one; j++)
                {
                    dp[i][j] = new long[2];
                }
            }

            for(int i = 1; i <= Math.Min(zero, limit); i++)
            {
                dp[i][0][0] = 1;
            }

            for (int j = 1; j <= Math.Min(one, limit); j++)
            {
                dp[0][j][1] = 1;
            }

            for (int z = 1; z <= zero; z++)
            {
                for (int o = 1; o <= one; o++)
                {
                    dp[z][o][0] = (dp[z-1][o][0] + dp[z - 1][o][1]) % mod;

                    if(z-limit-1 >= 0)
                    {
                        dp[z][o][0] = (dp[z][o][0] - dp[z - limit - 1][o][1] + mod) % mod;
                    }

                    dp[z][o][1] = (dp[z][o-1][0] + dp[z][o-1][1]) % mod;

                    if (o - limit - 1 >= 0)
                    {
                        dp[z][o][1] = (dp[z][o][1] - dp[z][o - limit - 1][0] + mod) % mod;
                    }
                }
            }

            return (int)((dp[zero][one][0] + dp[zero][one][1] + mod) % mod);
        }

        //https://leetcode.com/problems/find-all-possible-stable-binary-arrays-i/solutions/7635866/dynamic-programming-approach-to-count-st-wkw9/?envType=daily-question&envId=2026-03-09
    }
}
