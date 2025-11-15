using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0053MaximumSubarray
    {
#if false //錯誤答案，沒考慮到中間段取值
        public int MaxSubArray(int[] nums)
        {
            //time: O(n)
            //space:O(1)
            
            //因為subarray 是連續的，取向左和向右時得到最大值的位置，代表再向左或再向右sum都不可能更大，所以這個區間就是排除會變更小可能的區間 = max subarray

            int toLeftMax = int.MinValue;
            int toRightMax = int.MinValue;
            int toLeftMaxIndex = -1;
            int toRightMaxIndex = -1;
            int toLeftSum = 0;
            int toRightSum = 0;

            //toLeft(兩個for迴圈應該是能合併，但先簡單易懂做即可)
            for (int i = nums.Length -1 ; i >= 0; i--)
            {
                toLeftSum += nums[i];
                if (toLeftSum >= toLeftMax) //要包含 =，因為max可能是負值，所以有0對負值其實算是正向結果，對正值也不會有影響 => 只取 0 的 subarray => [-2, -1, -2] 還是會GG
                {
                    toLeftMax = toLeftSum;
                    toLeftMaxIndex = i;
                }
            }

            //toRight
            for (int i = 0; i < nums.Length; i++)
            {
                toRightSum += nums[i];
                if (toRightSum >= toRightMax) 
                { 
                    toRightMax = toRightSum;
                    toRightMaxIndex = i;
                }
            }

            //有可能構不成區間 ex: [1, -9999, 1] => 那就比較toLeftMax 和 toRightMax return 即可
            if(!(toLeftMaxIndex <= toRightMaxIndex))
            {
                return toLeftMax > toRightMax ? toLeftMax : toRightMax;
            }

            return toRightMax + (toLeftMax - toLeftSum); //補上插值就不用再跑一次for迴圈
        }
#endif
#if false //O(n^2)方法會超過time limit XD
        public int MaxSubArray(int[] nums)
        {
            //time: O(n^2)
            //space:O(1)

            //1.因為subarray 是連續的，取向左和向右時得到最大值的位置，代表再向左或再向右sum都不可能更大，所以這個區間就是排除會變更小可能的區間  = max subarray
            //2.有可能構不成區間，就要檢查中間的區段總和是否有更大的可能性
            //區段總和 = totalSum - (totalSum - toRightSum) - (totalSum - toLeftSum); => 去掉左右差值的總和
            //算出每個區段總和 => 取出其中最高

            int[] toLeftSums = new int[nums.Length];
            int[] toRightSums = new int[nums.Length];
            int toLeftMax = int.MinValue;
            int toRightMax = int.MinValue;
            int toLeftMaxIndex = -1;
            int toRightMaxIndex = -1;
            int toLeftSum = 0;
            int toRightSum = 0;

            //toLeft(兩個for迴圈應該是能合併，但先簡單易懂做即可)
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                toLeftSum += nums[i];
                if (toLeftSum >= toLeftMax) //要包含 =，因為max可能是負值，所以有0對負值其實算是正向結果，對正值也不會有影響 => 只取 0 的 subarray
                {
                    toLeftMax = toLeftSum;
                    toLeftMaxIndex = i;
                }
                toLeftSums[i] = toLeftSum;
            }

            //toRight
            for (int i = 0; i < nums.Length; i++)
            {
                toRightSum += nums[i];
                if (toRightSum >= toRightMax)
                {
                    toRightMax = toRightSum;
                    toRightMaxIndex = i;
                }
                toRightSums[i] = toRightSum;
            }

            //(進入這裡前會是O(n))構不成區間 => 跑 (n^2)/2 (正方形中取上三角或下三角的程度而已) => 應該是不好
            if (!(toLeftMaxIndex <= toRightMaxIndex))
            {
                int totalSum = toLeftSum;
                int max = int.MinValue;
                for (int i = 0; i < nums.Length; i++) //leftindex
                {                    
                    for(int j =  i; j < nums.Length; j++) //rightindex
                    {
                        int tempSum = totalSum - (totalSum - toRightSums[j]) - (totalSum - toLeftSums[i]);
                        if (tempSum > max)
                        {
                            max = tempSum;
                        }
                    }
                }
                return max;
            }

            return toRightMax + (toLeftMax - toLeftSum); //補上Max差值即可
        }
#endif
        public int MaxSubArray(int[] nums)
        {
            //time: O(n)
            //space:O(n) => dp應該常見

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            int max = dp[0];

            for(int i = 1; i < nums.Length; i++) //從 0 到 nums.Length - 1 => 一步步計算到nums.Length - 1時的最佳結果
            {
                int tempMax = Math.Max(dp[i - 1] + nums[i], nums[i]); //在nums[i]這個位置上必定包含nums[i]，所以只有1.自己+包含前面最佳結果 2.自己 兩種選擇
                if(tempMax > max)
                {
                    max = tempMax;
                }
                //記錄到此的最佳結果
                dp[i] = tempMax;
            }

            return max; //返回從頭到尾的最佳結果
        }

        //https://leetcode.com/problems/maximum-subarray/solutions/20193/dp-solution-some-thoughts-by-fujiwaranos-12dx/?page=3
        //https://leetcode.com/problems/maximum-subarray/solutions/20211/accepted-on-solution-in-java-by-cbmbbz-iuh2/?page=3
        //上面兩位的答案其實原理一樣都是 DP
        //* 這邊DP 的目標是解決小問題 約等於 divide and conquer
        //第一位 使用 dp[i-1] > 0 決定 dp[i] 的計算方式
        //第二位 是將第一位 dp[i-1] > 0 和 dp[i-1] <= 0 的計算方式都檢查而已，所以本質一樣 => 第二位比較能單純理解，畢竟不用去在意為甚麼要考慮dp[i-1] > 0
        //* 最重要的是這邊dp[i-1]代表到i為止前面最佳表現的結果，把問題base on 前面結果繼續擴展，而不是去在意最佳表現的結果如何計算出來!
    }
}
