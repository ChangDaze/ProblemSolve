using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2176CountEqualandDivisiblePairsinanArray
    {
        public int CountPairs(int[] nums, int k)
        {
            //先確認所有可被k整除的數並記錄 (M) => 這效果沒全部套用那麼好，因為 i * j後有時候反而可以被k整除
            bool[] flags = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i += k) // 0 % k ==0，所以i要從0開始!!
            {
                flags[i] = true;
            }

            int result = 0;

            //確認所有組合 (n^2) 哪些具有(1)相等(2)被k整除，的條件
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (nums[i] == nums[j] && (flags[i] || flags[j] || (i * j) % k == 0))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        //用Dictionary<int, int> records統計也要計算階層關係和(i*j)%k==0問題，又會繞回原本解法
        //下面很像統計的解法@@，但概念比較像是想辦法縮短我暴力解遍歷長度而已

        //https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array/solutions/1784521/o-n-sqrt-n/
        //chatgpr:
        //建立 m（哈希表）： 𝑂 ( 𝑛 ) O(n)
        //遍歷 m（數字的不同群組）：最多 𝑂 ( 𝑛 ) O(n)
        //內部 gcds 計算：
        //    gcd(i, k) 計算： 𝑂 (log ⁡ 𝑘 ) O(logk)
        //    遍歷 gcds：平均 𝑂 ( 1 ) O(1)（因為 GCD 可能的值不多）
        //總體時間複雜度： 大約 𝑂 ( 𝑛 log ⁡ 𝑘 ) O(nlogk)，比直接暴力 𝑂 ( 𝑛 2 ) O(n 2 ) 快很多。
        //GCD（Greatest Common Divisor，最大公因數）是指兩個整數的最大公約數，即能同時整除這兩個數的最大整數。

        //int countPairs(vector<int>& nums, int k)
        //{
        //    int res = 0;
        //    unordered_map<int, vector<int>> m;
        //    for (int i = 0; i < nums.size(); ++i)
        //        m[nums[i]].push_back(i); //這紀錄的是index!!
        //    for (auto & [n, ids] : m) //遍歷統計 n是key，ids是list
        //    {
        //        unordered_map<int, int> gcds; //用來記錄前面處理過的階層和對應數量
        //        for (auto i : ids) //遍歷 list
        //        {
        //            auto gcd_i = gcd(i, k); //這一階層的指標gcd_i
        //            for (auto & [gcd_j, cnt] : gcds)
        //檢查這一階層的指標有符合條件的 (因為ids隱含遞增關係，所以gcds都是當下的紀錄，只要其中有值能被k整除即可，所以不取gcd應該也可吧?，只是取了gcd能讓gcds變很短(讓沒被k整除的數都放在gcds[1]中)，大概)
        //                res += gcd_i * gcd_j % k ? 0 : cnt; //代表這兩個索引相乘能被 k 整除，則累加 cnt
        //            ++gcds[gcd_i]; //這個應該就能處理前面遇到的階層問題
        //        }
        //    }
        //    return res;
        //}
    }
}
