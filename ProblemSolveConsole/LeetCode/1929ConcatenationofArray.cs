using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1929ConcatenationofArray
    {
        public int[] GetConcatenation(int[] nums)
        {
            //time:O(n)
            //space:O(n)
            int len = nums.Length + nums.Length;
            int[] result = new int[len];

            for(int i = 0; i < len; i++)
            {
                if (i >= nums.Length) //擴展到n倍可能用%nums.Length比較簡潔
                {
                    result[i] = nums[i - nums.Length];
                }
                else
                {
                    result[i] = nums[i];
                }
            }

            return result;
        }

        //https://leetcode.com/problems/concatenation-of-array/solutions/1330265/java-4-lines-by-vikrant_pc-ysea/?envType=problem-list-v2&envId=dsa-linear-shoal-array-i
        //...我還在對題目的簡單沾沾自喜，這個result[i + nums.length] = result[i] = nums[i];直接跑O(n)我還在O(2n)直接被打趴在地上XD
    }
}
