using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2908MinimumSumofMountainTripletsI
    {
        public int MinimumSum(int[] nums)
        {
            int result = Int32.MaxValue;

            //O(n^3)
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] < nums[j] && nums[j] > nums[k]) // i < j > k
                        {
                            int sum = nums[i] + nums[j] + nums[k];
                            result = sum < result ? sum : result;
                        }
                    }
                }
            }

            return result == Int32.MaxValue ? -1 : result;
        }

        //單純暴力解
        //這位的方法很好，把i當作peak，另外存兩個陣列存left min 和 right min，只對min和peak做比較，總共只要O(3N)，這方法好非常多
        //https://leetcode.com/problems/minimum-sum-of-mountain-triplets-i/solutions/4194363/c-brute-force-precompute/
        //這位方法跟上一位差不多
        //https://leetcode.com/problems/minimum-sum-of-mountain-triplets-i/solutions/4195273/c-java-python-javascript-explained/
    }
}
