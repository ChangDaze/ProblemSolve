using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0046Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            //time : O(n·n!)
            //space: O(n·n!)


            IList<IList<int>> result = new List<IList<int>>();
            List<int> permutation = new List<int>();
            bool[] used = new bool[nums.Length];
            BackTracking(nums, permutation, used, result);
            return result;
        }

        private void BackTracking(int[] nums, List<int> permutation, bool[] used, IList<IList<int>> result)
        {
            if(permutation.Count == nums.Length)
            {
                result.Add(new List<int>(permutation));
                return;
            }

            for(int i = 0; i< nums.Length; i++)
            {
                if (used[i]) { continue; }
                permutation.Add(nums[i]);
                used[i] = true;
                BackTracking(nums, permutation, used, result);
                permutation.RemoveAt(permutation.Count - 1);
                used[i] = false;
            }
        }

        //https://leetcode.com/problems/permutations/solutions/18247/my-elegant-recursive-c-solution-with-inl-yci2/?page=3
        //這個解法很有趣，是inplace swap，簡單講就是實質意義上的permutation都做一次，但建立在array內容是distinct的，有點難想像如何證明，但這是事實

        //每一層遞迴都會把一個「位置」固定（num[0] 固定 → num[1] 固定 → …）
        //begin代表每層，且只會和後面的SWAP i >= begin
        //然後每進下層拆成更小的問題，有點dp和divide and conquer的感覺
        //理論上效率更好，可以當作一個額外知識參考
    }
}
