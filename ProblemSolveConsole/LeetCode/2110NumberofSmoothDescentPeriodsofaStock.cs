using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2110NumberofSmoothDescentPeriodsofaStock
    {
        public long GetDescentPeriods(int[] prices)
        {
            //time:O(n)
            //space:O(n)
            //這題用streaks+梯形公式算出所有組合就好，跟算金字塔三角形是一樣的道理

            long result = 0;

            long streaks = 1;

            for (int i = prices.Length-2; i >= 0; i--)
            {
                if(prices[i] - prices[i+1] == 1)
                {
                    streaks++;
                }
                else
                {
                    result += (streaks + 1) * streaks / 2;//計算前面的streaks
                    streaks = 1;
                }
            }

            result += (streaks + 1) * streaks / 2; //for中都是算前面的streaks，所以要補算最後的streaks

            return result;
        }

        //https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock/solutions/1635010/simple-aggregation-by-votrubac-7aod/?envType=daily-question&envId=2025-12-15&page=3
        //...這更簡單，直接不用梯形公式，也確實只要每格res += streaks 過程就是梯形公式QQ，重點是他最後不用補做一次
        //其他方法其實都差不多，更不一樣的方法也只是花式，不用太在意
    }
}
