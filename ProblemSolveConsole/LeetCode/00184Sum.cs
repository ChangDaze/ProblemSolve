using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _00184Sum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            //time : O(n^3) => 兩層 + two pinter 的 O(n)
            //space : O(n^4) => 每層O(n)，但其實有target + 去重複 + early return 實際上會大幅縮小結果集
            List<IList<int>> results = new List<IList<int>>();
            Array.Sort(nums); //沒排序就不能用2Sum和early return = 就不能用了
            FindNSum(0, nums.Length - 1, target, 4, nums, new List<int>(), results);
            return results;
        }

        private void FindNSum(int left, int right, long target, int N, int[] nums, List<int> current, List<IList<int>> results)
        {
            //參考這位的
            //https://leetcode.com/problems/4sum/solutions/8545/python-140ms-beats-100-and-works-for-n-sum-n-2/
            //(1) 初版
            //(2) 跟(1)比只有語法寫得更清楚和稍微移動判斷的位置
            //(3) 跟(1)(2)比，避免了用python slice一直產生新list，做資源上的節省
            // NSum之後都是每層拆解+two sum, 問gpt這已經是最快的解法之一了
            // 但畢竟是每層拆解，所以時間複雜度就是指數成長 => N = 5就 O(n^4), N = 6就 O(n^5) ......

            //因為 -10^9 <= nums[i] <= 10^9 和 -10^9 <= target <= 10^9，所以有+-乘除的數都要注意溢位，包含target在遞迴過程會被+-，所以也要是long

            //early return condition
            if ( 
                right - left + 1 < N || //數字不夠
                N < 2 || 
                target < (long)nums[left] * N || //比最小組合還小
                target > (long)nums[right] * N //比最大組合還大
            )
            {
                return;
            }

            //最底層的2Sum
            if (N == 2)
            {
                while(left < right)
                {
                    long sum = (long)nums[left] + nums[right];
                    if (sum == target)
                    {
                        results.Add(current.Concat(new List<int>() { nums[left], nums[right] }).ToList()); //用concat就不會影響到current

                        
                        left++; //這裡沒特別寫right--內縮是因為結果等價，在後面迴圈中一樣會被排除，因為target固定，所以一邊先內縮完成即可
                        while (left < right && nums[left] == nums[left - 1])
                        {
                            left++;
                        }
                    }
                    else if( sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            //遞迴用N-1剝開直到2Sum
            else
            {
                for(int i = left; i < right + 1; i++) //沒特別控制right -N +1因為early return 有控制了
                {
                    if ( i == left || //確保第一個要做
                        (i > left && nums[i] != nums[i-1]) //重複的不用做
                    )
                    {
                        FindNSum(i + 1, right, target - nums[i], N - 1, nums, current.Concat(new List<int>() { nums[i]}).ToList(), results);
                    }
                }
            }
        }
    }
}
