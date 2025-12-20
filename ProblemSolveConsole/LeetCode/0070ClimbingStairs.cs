using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0070ClimbingStairs
    {
#if false //space O(n)
        public int ClimbStairs(int n)
        {
            //  time : O(n)
            //  space : O(n)
            if(n < 2) //在小於2時都只有一個可能
            {
                return 1;
            }

            int[] dp = new int[n+1]; //0是起點,n是終點
            dp[0] = 1; dp[1] = 1;

            for(int i = 2; i < dp.Length; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2]; //目前的可能性就是前兩階的所有可能性相加 > dp
            }

            return dp[n];
        }
#endif
        public int ClimbStairs(int n)
        {
            if (n < 2) //在小於2時都只有一個可能
            {
                return 1;
            }

            int previous2step = 1; //前兩階
            int previous1step = 1; //前一階           

            for (int i = 2; i < n+1; i++)
            {
                int temp = previous1step + previous2step; //目前的可能性就是前兩階的所有可能性相加 > dp
                //開始移動下一階，更新前兩階資料
                previous2step = previous1step; //不需要的資料先捨棄，不能先更新previous1step
                previous1step = temp;
            }

            return previous1step;
        }

        //https://leetcode.com/problems/climbing-stairs/solutions/3708750/4-methods-beats-100-c-java-python-beginn-bvot/?page=3
        //這個人講得很細
        //1. 遞迴 > 但沒有記憶化，所以每次往下找都會全跑一輪，可能是n^2
        //2. 遞迴+記憶化，因為記憶化所以是n，但space也是n
        //3. dp = 我的法一
        //4. dp + space最佳化 = 我的法2
        //可看出遞迴和dp都有分解小問題解決的能力
    }
}
