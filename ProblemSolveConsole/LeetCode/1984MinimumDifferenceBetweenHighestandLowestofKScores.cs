using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1984MinimumDifferenceBetweenHighestandLowestofKScores
    {
#if false //舊方法 方法跟新法法其實一樣sliding window
        public int MinimumDifference(int[] nums, int k)
        {
            Array.Sort(nums);

            if (k == 1)
                return 0;

            int min = int.MaxValue;

            for (int i = k - 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - k + 1] < min)
                    min = nums[i] - nums[i - k + 1];
            }

            return min;
        }
#endif
        public int MinimumDifference(int[] nums, int k)
        {
            //這題是要抓出K個，然後用K個中最高和最低能達成min的答案 => 要找到造成diff最小的K個數字

            Array.Sort(nums); //讓數字一定緊貼最近的數字 O(nlogn)
            int result = int.MaxValue;
            for(int i = 0, j = k - 1; j < nums.Length; i++, j++)
            {
                if (nums[j] - nums[i] < result)//感覺也能造個temp直接不用if每次temp + nums[j]- nums[i]- nums[i]之類的
                {
                    result = nums[j] - nums[i];
                }
            }
            return result;
        }
        //這題一開始一直沒看懂題目，要多練一下題目理解，後來試問AI知道是用sliding window
        //https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/solutions/1432024/sort-and-skip-by-votrubac-7tmd/
        //大家方法其實都一樣 sort + slifing window
    }
}
