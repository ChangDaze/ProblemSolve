using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0055JumpGame
    {
        public bool CanJump(int[] nums)
        {
            //time: O(n^2) => 兩個迴圈，用了dp跑了不像dp的內容...
            //space: O(n)

            bool[] dp = new bool[nums.Length];
            dp[0] = true;

            for (int i = 0; i < nums.Length; i++)
            {
                if (dp[i])
                {
                    for(int j = 1; j <= nums[i]; j++)
                    {
                        int next = i + j;
                        if(next < nums.Length && !dp[next]) //next < nums.Length可以不用判斷，因為超過 = 到達...
                        {
                            dp[next] = true;
                        }
                    }
                }
            }

            return dp[nums.Length - 1] ;
        }

        //https://leetcode.com/problems/jump-game/solutions/5130181/video-move-goal-position-by-niits-fnen/?page=3
        //看完這個才大概有感覺為啥這題是greedy + dp的組合
        //1.他用backward loop，用結果看 => greedy
        //2.他用前次結果檢查下次 => dp
        //3.goal = dp = 目前最佳的子問題結論
        //https://leetcode.com/problems/jump-game/solutions/2375320/interview-scenariorecursion-memoization-k28d7/?page=3
        //這個人最後的解法有提供順向的loop，比較像我的解法應該達到的效果
        //1.順向的loop，每格都走，更新最遠能到達距離(greedy) => 只要 最遠能到達距離 > 目前位置，那中間的格就等於全部能走 => 中間的格可能可以取出更遠距離
        //2.if(reach < idx) return false;  最遠能到達距離 < 目前位置 就要終止
        //3.reach(最遠能到達距離) = dp = 目前最佳的子問題結論
    }
}
