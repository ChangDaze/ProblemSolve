using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0040CombinationSumII
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            //time : O(n log n + 2ⁿ · n) => 2代表選或不選
            //space : O(2ⁿ · n) => 所有輸出結果都是List

            //unique combinations => 重複要跳過
            Array.Sort(candidates);
            List<int> currentList = new List<int>();
            List<IList<int>> result = new List<IList<int>>();
            Recursive(candidates, target, 0, 0, currentList, result);
            return result;
        }

        private void Recursive(IList<int> candidates, int target, int currentIndex, int currentSum, List<int> currentList, List<IList<int>> result)
        {
            if(currentSum > target)
            {
                return;
            }
            else if(currentSum == target)
            {
                result.Add(new List<int>(currentList));
                return;
            }

            HashSet<int> used = new HashSet<int>(); //避免重複項目出現在BackTracing中。且要Sort過後，不然[2, 2, 1, 2]會出錯，會把2, 2, 1和2, 1, 2視作不同

            for (int i = currentIndex; i < candidates.Count; i++)
            {
                if (used.Contains(candidates[i]))
                {
                    continue;
                }
                currentList.Add(candidates[i]);                
                Recursive(candidates, target, i+1, currentSum + candidates[i], currentList, result);
                currentList.RemoveAt(currentList.Count-1);
                used.Add(candidates[i]);
            }

            return;
        }

        //https://leetcode.com/problems/combination-sum-ii/solutions/16878/combination-sum-i-ii-and-iii-java-soluti-3tm9/
        //...結果他一招if(i > start && cand[i] == cand[i-1]) continue; /** skip duplicates */就把我HashSet打趴XD，確實也符合情理
        //https://leetcode.com/problems/combination-sum-ii/solutions/6097940/video-solution-by-niits-0rtj/
        //這位方法也一樣
        //真的要好好想想除了HashSet暴力解以外的歸納方式，至少要記住除了HashSet暴力解以外判斷可行的規律
    }
}
