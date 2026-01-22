using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3507MinimumPairRemovaltoSortArrayI
    {
        public int MinimumPairRemoval(int[] nums)
        {
            //time:O(n^2)
            //space:O(n)
            //就最簡單的simulate

            List<int> temp = nums.ToList();//O(n)
            int result = 0;
            bool ordered = true;

            do
            {
                (int index, int value) min = (int.MaxValue, int.MaxValue);
                ordered = true;
                for(int i = 1; i < temp.Count; i++)//O(n)
                {
                    if(temp[i] < temp[i - 1])
                    {
                        ordered = false;
                    }

                    if(temp[i] + temp[i - 1] < min.value)
                    {
                        min = (i, temp[i] + temp[i - 1]);
                    }
                }

                if (!ordered)
                {
                    result++;
                    temp[min.index] = min.value;
                    temp.RemoveAt(min.index - 1);
                }
            }
            while (!ordered);//O(n)

            return result;
        }
    }
    //因為想不到其他解法，所以用最簡單的simulate，感覺跟排列組合的複雜度有點像，就是不可避免n^2
    //https://leetcode.com/problems/minimum-pair-removal-to-sort-array-i/solutions/7513811/step-by-step-beats-100-by-balepavleski-r2g0/
    //結果投票最高的人方法一樣耶，只是切得比較乾淨
    //https://leetcode.com/problems/minimum-pair-removal-to-sort-array-i/solutions/7513978/0ms-beats-10000-easy-approach-and-step-b-27j0/
    //看其他人tag也只是打爽的好像沒特別用不同資料結構
}
