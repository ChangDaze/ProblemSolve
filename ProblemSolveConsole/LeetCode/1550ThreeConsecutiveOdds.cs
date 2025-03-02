using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1550ThreeConsecutiveOdds
    {
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            int consecutive = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    consecutive = 0;
                }
                else if (++consecutive >= 3)
                {
                    break;
                }
            }

            return consecutive >= 3 ? true : false;
        }

        //第3種解法有一些數學原理蠻有趣，但效能來說簡單的處理應該最快?
        //https://leetcode.com/problems/three-consecutive-odds/solutions/6480508/c-by-changdaze-ri21/
    }
}
