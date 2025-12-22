using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1470ShuffletheArray
    {
        public int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[nums.Length];

            for(int i = 0, j = 0; i < n; i++, j+=2)
            {
                result[j] = nums[i];
                result[j + 1] = nums[i+n];
            }

            return result;
        }

        //一開始糾結很久能不能不額外用記憶體，最後放棄但想到twopointer
        //https://leetcode.com/problems/shuffle-the-array/solutions/675956/in-place-on-time-o1-space-with-explanati-373y/
        //這個人很有趣的完成O(1) in place，但他是套用題目限制，他用int+bit mask (後面n個)一次存兩個數值，先loop一次存完後，array裡面的值在第二次就都能取代了
        //然後還是有用twopointer因為執行順序還是要twopointer支援
        //https://leetcode.com/problems/shuffle-the-array/solutions/674309/java-straightforward-1-loop-by-hobiter-2n0k/
        //這位方法跟我一樣
    }
}
