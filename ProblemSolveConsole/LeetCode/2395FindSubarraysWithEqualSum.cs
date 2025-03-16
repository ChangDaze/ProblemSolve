using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2395FindSubarraysWithEqualSum
    {
        public bool FindSubarrays(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();

            int temp = nums[0];
            int minusPointer = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                temp += nums[i];
                if (result.Contains(temp)) //確認sum有重複就結束了
                {
                    return true;
                }
                result.Add(temp);
                temp-= nums[minusPointer];
                minusPointer=i;
            }

            return false;
        }
        //因為是subarray所以基本上沒太多方法，大家比較方法都差不多
        //https://leetcode.com/problems/find-subarrays-with-equal-sum/solutions/2524729/hash-set/
    }
}
