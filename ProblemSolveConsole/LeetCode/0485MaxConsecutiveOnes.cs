using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0485MaxConsecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            int max = 0;
            int streaks = 0;

            foreach (int num in nums)
            {
                if(num == 1)
                {
                    streaks++;
                    if(streaks > max)
                    {
                        max = streaks;
                    }
                }
                else
                {
                    streaks = 0;
                }
            }

            return max;
        }

        //https://leetcode.com/problems/max-consecutive-ones/solutions/96715/easy-java-solution-by-shawngao-ybr7/
        //大家解法差不多
    }
}
