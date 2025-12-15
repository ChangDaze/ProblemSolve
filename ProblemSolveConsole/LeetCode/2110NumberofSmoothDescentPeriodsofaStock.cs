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
                    result += (streaks + 1) * streaks / 2;
                    streaks = 1;
                }
            }

            result += (streaks + 1) * streaks / 2;

            return result;
        }
    }
}
