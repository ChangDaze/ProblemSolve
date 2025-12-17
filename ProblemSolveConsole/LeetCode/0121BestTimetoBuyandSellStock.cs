using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0121BestTimetoBuyandSellStock
    {
        public int MaxProfit(int[] prices)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)

            //因為只能買(最大-最小)，且只有一次交易，唯一限制就只有買進和賣出時間
            int smallest = int.MaxValue; //賣出當下，過往買進能得到的最小成本
            int maxProfit = 0; //唯一一次交易能達到的最高獲利

            foreach (int p in prices)
            {
                int profit = p - smallest; //賣出當下-過往買進能得到的最小成本 = 當下能獲得的最大獲利
                if (profit > maxProfit)
                {
                    maxProfit = profit;//比較是否更新唯一一次交易能達到的最高獲利
                }

                if (p < smallest) //為未來賣出更新最小成本
                {
                    smallest = p;
                }
            }

            return maxProfit;
        }

        //我的比較像simulation耶..

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/solutions/39038/kadanes-algorithm-since-no-one-has-menti-1wai/
        //這位用的解法很有依據，Kadane's Algorithm (卡丹演算法) > https://zh.wikipedia.org/zh-tw/%E6%9C%80%E5%A4%A7%E5%AD%90%E6%95%B0%E5%88%97%E9%97%AE%E9%A2%98
        //基本上就是最大子數列問題0053MaximumSubarray解法
        //理論上跟我的解法本質差蠻多的@@，簡單來說就是 cur = Max(前面子集的最的最佳解 + 目前, 目前) & Max(max, cur)的過程
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/solutions/1735550/python-javascript-easy-solution-with-ver-rbhm/
        //這位用two pointer蠻有趣的，但本質跟我的很像，好像直接用我的方法比較易懂@@
    }
}
