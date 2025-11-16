using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0047PermutationsII
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            //time : O(n·n!)
            //space: O(n·n!)

            //Permutation（排列）問題本質上就一定是 O(n · n!)，不是你的程式差，是題目的本質如此。
            //O(n·n!) 完全不是 O(n³)，而是遠遠大於 n³。 => n!是乘階
            //因為輸出本身就 n! 個，所以已經是最優解了 => ai安慰

            IList<IList<int>> result = new List<IList<int>>();
            List<int> permutation = new List<int>();
            HashSet<int> usedIndex = new HashSet<int>();
            BackTracking(nums, permutation, usedIndex, result);
            return result;
        }

        private void BackTracking(int[] nums, List<int> permutation, HashSet<int> usedIndex, IList<IList<int>> result)
        {
            if(permutation.Count == nums.Length) 
            { 
                result.Add(new List<int>(permutation)); //記得紀錄新物件
                return;
            }

            HashSet<int> usedValue = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (usedIndex.Contains(i)) continue; //用過的index不能再用
                if (usedValue.Contains(nums[i])) continue; //同層用過的value不再用 => 使用完不取消

                //使用
                permutation.Add(nums[i]);
                usedIndex.Add(i);
                usedValue.Add(nums[i]);
                BackTracking(nums, permutation, usedIndex, result);

                //取消
                permutation.RemoveAt(permutation.Count - 1);
                usedIndex.Remove(i);
            }
        }

        //https://leetcode.com/problems/permutations-ii/solutions/18594/really-easy-java-solution-much-easier-th-lpev/?page=3
        //這位使用bool[] 取代我的usedIndex
        //Arrays.sort + if(i>0 &&nums[i-1]==nums[i] && !used[i-1]) continue; 取代我一直new usedValue => 長度很長時效果就有差

        //但感覺nums[i] == nums[i - 1]就足夠，為甚麼還需要!used[i - 1]
        //不用 !used[i - 1] ， 那會直接把「第二個 重複」永遠擋掉 => !used[i - 1] 的作用 只阻擋同一層的重複，而不阻擋下一層的重複合法使用
        //=>簡單講nums[i] == nums[i - 1]時 used[i - 1] = true 代表重複不同層，used[i - 1] = false  代表重複同層

        // ★ 重點：避免同層重複（經典寫法）
        // nums[i] == nums[i-1] 且前一個沒用過 → 代表本層已生成過同樣值
        //if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
        //    continue;
        // => 所以應該一眼就看出，要背起來
    }
}
