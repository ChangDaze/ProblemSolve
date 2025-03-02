using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3432CountPartitionswithEvenSumDifference
    {
        public int CountPartitions(int[] nums)
        {
            int rightSum = nums.Sum();
            int leftSum = 0;
            int evenCount = 0;

            for (int i = 0; i<nums.Length-1;i++) //左右subarray至少要一個值
            {
                leftSum += nums[i];
                rightSum -= nums[i];

                if((leftSum - rightSum)%2==0)
                {
                    evenCount++;
                }
            }

            return evenCount;
        }
    }

    //這位方法跟我差不多
    //https://leetcode.com/problems/count-partitions-with-even-sum-difference/solutions/6329962/beats-100-java-beginner-freindly-c-c-python/

    //這位看深一點用公式，但因為要算total，所以應該也算差不多
    //https://leetcode.com/problems/count-partitions-with-even-sum-difference/solutions/6329925/python-in-really-easy-way-check-total-is-even-or-not/

}
