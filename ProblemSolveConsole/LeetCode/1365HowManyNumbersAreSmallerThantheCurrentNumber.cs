using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1365HowManyNumbersAreSmallerThantheCurrentNumber
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {            
            int[] result = new int[nums.Length];
            Array.Copy(nums, result, nums.Length);//O(n)，因為結果要follow原本題目的排序，所以要另外copy            
            Dictionary<int, int> record = new Dictionary<int, int>();

            Array.Sort(result);//O(nlogn)
            //O(n)
            for (int i = result.Length - 1, j = result.Length - 2; j >= 0; j--) //j會主動前進而已，i負責追上j，用排序好的result找
            {
                while (j >= 0 && result[i] == result[j])
                {
                    j--;
                }

                if( j == -1) //剩下的都相同，沒比任何數字大
                {
                    break;
                }

                record[result[i]] = j + 1;
                i = j;
            }

            //O(n)
            for(int i = 0; i<nums.Length; i++)//用原排序的nums更新
            {
                if (record.ContainsKey(nums[i]))
                {
                    result[i] = record[nums[i]];
                }
                else
                {
                    result[i] = 0;
                }
            }

            return result;
        }

        //https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/solutions/524996/java-beats-100-on-by-equ1n0x-gsla/
        //這位直接用0 <= nums[i] <= 100的限制使用int[101]來計數，然後直接 count[i] += count[i-1];來讓福砸度的上下限變化限制住，所以也不用sort，下次可以先想想
        //https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/solutions/535421/java-clean-hashmap-solution-with-explana-sgq0/
        //這個人方法跟我一樣，不過他做得比我好，我還呆呆用two pointer，他直接ascending其實index就是要的答案@@
        //https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/solutions/819148/python-3-9111-faster-52ms-time-explanati-oj0m/
        //這位方法跟第二位一樣
    }
}
