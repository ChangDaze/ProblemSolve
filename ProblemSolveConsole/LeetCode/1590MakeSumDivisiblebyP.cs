using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1590MakeSumDivisiblebyP
    {
        public int MinSubarray(int[] nums, int p)
        {
#if false //明顯最後是超時
            int result = int.MaxValue;

            long sum = nums.Sum( x => (long)x);
            if(sum % p == 0)
            {
                return 0;
            }
            else if(sum < p)
            {
                return -1;
            }

            for(int i  = 0; i < nums.Length; i++) //理論上可以有很多重複，所以要能去重複
            {
                long tempSum = sum - nums[i];
                if (tempSum % p == 0)
                {
                    return 1;
                }

                for (int j = i + 1; j < nums.Length && j - i + 1 < result; j++) //這就2sum n^2 兩層迴圈的那個方法
                {
                    tempSum -= nums[j];
                    if (tempSum > 0 && tempSum % p == 0) //tempSum > 0是因為要確保不會全部被移除了
                    {
                        result = j - i + 1;
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;
#endif
            //Time complexity:O(n)
            //Space complexity:O(n)

            long sum = nums.Sum(x => (long)x); //這裡每一步都%p就可以把方法中的long都改成int了
            if (sum % p == 0)
            {
                return 0;
            }
            //else if (sum < p) //AI說後面能檢查，自己加上這段不好 => 在這一題裡，它屬於「沒有工程價值的提前優化」，而且會降低演算法的可證明性。 對他們來說多跑一次O(n)不算高成本，除非真的必要
            //{
            //    return -1;
            //}

            long result = nums.LongLength; //結果預設是全扣掉才能整除
            long need = sum % p; //目前需要扣除的部分
            long curApply = 0; //prefixsum
            Dictionary<long, int> previousApply = new Dictionary<long, int>(); //key: apply, value:indx
            previousApply[0] = -1; //整個curApply扣去才滿足，長度是i+1，所以0要先設-1

            for (int i = 0; i < nums.Length;i++)
            {
                curApply = (curApply + nums[i]) % p; //算出移除這部分，可以扣除的部分
                previousApply[curApply] = i;//如果有相同的會一直用最近來蓋掉
                long currentNeed = (curApply - need + p) % p;//+p是為了不產生負數，因為%p沒存負數，都用正數處理

                //整個公式會是
                //全部 - curIndex以前 + previousIndex以前 => 所以是扣去 previousIndex以前 +1 ~ curIndex
                //need - (curApply - previousApply) = 0 > 移項
                //previousApply = curApply - need => currentNeed = curApply - need

                //更新是否有最短選擇
                if (previousApply.TryGetValue(currentNeed, out int prefixI))
                {
                    result = Math.Min(result, i - prefixI);//扣去 previousIndex以前 +1 ~ curIndex所以不用補+1。 註:off-by-one 錯誤，「差一個」的索引或長度錯誤，單純看到補充
                }
            }

            return result == nums.LongLength ? -1 : (int)result;
        }

        //https://leetcode.com/problems/make-sum-divisible-by-p/solutions/854197/javacpython-prefix-sum-by-lee215-fi77/
        //者要是抄這位的，不過想要自己想到這解法，經驗值好像還差蠻多的
        //其他人解法其實都差不多，看來要刻在腦中
    }
}
