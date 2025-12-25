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
            Array.Copy(nums, result, nums.Length);//O(n)            
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
    }
}
