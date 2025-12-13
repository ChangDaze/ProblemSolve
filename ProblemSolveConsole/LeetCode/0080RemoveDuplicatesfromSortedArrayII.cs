using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0080RemoveDuplicatesfromSortedArrayII
    {
        public int RemoveDuplicates(int[] nums)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            int slow = 0;
            int fast = 0;
            int result = 0;
            int cur = Int32.MinValue;
            int curCount = 0;

            while (fast < nums.Length)
            {
                if(cur != nums[fast])
                {
                    cur = nums[fast];
                    curCount = 1;
                }
                else
                {
                    curCount++;
                }

                if(curCount <= 2) //慢指標代表要放入答案的位置，快指標代表目前檢查到的位置，當curCount > 2時慢指標就會停止更新直到快指標檢查到新的value
                {
                    nums[slow] = nums[fast];
                    result++;
                    slow++;                    
                }

                fast++;
            }

            return result;
        }

        //https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/solutions/27976/3-6-easy-lines-c-java-python-ruby-by-ste-pq39/
        //這個超精簡，硬生生把兩指標掰成一指標@@，雖然可以學，但感覺不是很能直覺聯想到
        //https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/solutions/4062386/0n-easy-to-understand-solution-by-200511-1rdf/
        //這位方法也一樣

        //看來大家都用 n > nums[i-2]直接判斷，那可能要學起來，也因此我的速度比較慢也正常，因為大家都用精簡的辦法@@
    }
}
