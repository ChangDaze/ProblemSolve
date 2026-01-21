using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0645SetMismatch
    {
#if false
        public int[] FindErrorNums(int[] nums)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            long sum = 0;
            int[] result = new int[2];
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    result[0] = nums[i];
                }
                else
                {
                    set.Add(nums[i]);
                }

                sum += nums[i];
            }

            result[1] = (int)((1 + nums.Length) * nums.Length / 2 - sum + result[0]);

            return result;
        }
#endif

        public int[] FindErrorNums(int[] nums)
        {
            //1. XOR 2. in place marking -- index
            //Time complexity:O(n)
            //Space complexity:O(1)
            int[] result = new int[2];
            for (int i = 0, j = 1; i < nums.Length; i++, j++)
            {
                int val = Math.Abs(nums[i]);
                result[1] ^= j ^ val;
                if(nums[val - 1] < 0) //確認"index"是否被marking
                {
                    result[0] = val; //存下重複的"index"
                }
                else
                {
                    nums[val - 1] *= -1; //"index" marking，用正負和index來判斷哪個value用過了
                }
            }

            // ex: [1, 1]
            // 0   ^ 1 ^ 1      ^ 1 ^ 2      ^ 1         = 2
            // 0   j     nums[i]  j   nums[i]  result[0]   result[1]
            result[1] ^= result[0];

            return result;
        }

        //雖然這個方法不是很好理解，但能印象深刻的練習XOR ^ 和 in place marking
        //上面方法主要抄這位的
        //https://leetcode.com/problems/set-mismatch/solutions/105513/xor-one-pass-by-tyuan73-zbi9/
        //其他人方法其實就都差不多了
        //https://leetcode.com/problems/set-mismatch/solutions/387231/python-9880-super-easy-math-by-denyscode-bb7j/
    }
}
