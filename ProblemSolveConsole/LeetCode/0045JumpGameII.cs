using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0045JumpGameII
    {
        public int Jump(int[] nums)
        {
            //time:O(n)
            //space:O(n)

            int[] dp = new int[nums.Length];
            int pointer = 0;

            for(int i  = 0; i < nums.Length; i++)
            {
                int temp = i + nums[i];

                if(temp >  pointer)//只在最初就能碰到時紀錄步數 (前提是一定會到，不然dp[i]會是0)，避免重複比較
                {
                    for(int j = pointer + 1; j <= temp && j < nums.Length; j++)//注意是pointer + 1不是i
                    {
                        dp[j] = dp[i] + 1; 
                    }
                    pointer = temp;
                }
            }

            return dp[dp.Length-1];
        }
        //https://leetcode.com/problems/jump-game-ii/solutions/18014/concise-on-one-loop-java-solution-based-p8i3n/
        //這位的底層概念其實跟我一樣，就是只更新pointer + 1之後的步數，不過他用greedy，所以都只在最後關頭更新步數，也不用dp[]，可以記住
        //https://leetcode.com/problems/jump-game-ii/solutions/5292559/video-keep-near-and-far-position-and-get-a780/
        //這位的也蠻有趣的，他是用像是pointer的方式在移動，用far丈量下一步最遠到哪，用near更新起始點，值得記住
        //https://leetcode.com/problems/jump-game-ii/solutions/18028/on-bfs-solution-by-enriquewang-krq4/
        //這個人BFS應該是指只要到達就return答案，但她解的方式本質上還是像第二位那樣far(currentMax), near(i), farest(nextMax)的架構，他的while只是防止會有不會到達的情況(可以應該可以不用看自己定義就好)

        //仔細想想我也只有要在增加步數時更新dp，確實寫成O(1)比較好，要記住
    }
}
