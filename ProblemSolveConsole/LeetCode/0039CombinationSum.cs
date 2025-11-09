using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0039CombinationSum
    {
#if false //原本的暴力解
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            //time : O(n²) => (sum 的 n + new List n) * 遞迴的 n => 所以約n^2
            //1. 改掉sum
            //2. 你可以考慮 不複製 List，而是使用回溯法 (backtracking)
            //實作1和2後應該能變n而已

            //1
            //多個sum 參數放到recusive
            //2
            //temp.Add(candidates[i]);
            //Recurive(...);
            //temp.RemoveAt(temp.Count - 1);
            //space : O(n)
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);

            for (int i = candidates.Length - 1; i >= 0; i--)
            {
                List<int> temp = new List<int>() { candidates[i] };
                //比較 => 進入下個recursive前都要比一下，不然其他階段比會重複比
                if (temp.Sum() == target)
                {
                    result.Add(temp);
                }
                Recurive(candidates, target, temp, result, i);
            }

            return result;
        }

        private void Recurive(int[] candidates, int target, List<int> temp, IList<IList<int>> result, int index)
        {            
            if (index < 0)
            {
                return;
            }

            while (temp.Sum() < target) //題目有給2 <= candidates[i] <= 40 不用防 candidates[i] == 0 @@
            {
                //加入更小的
                Recurive(candidates, target, new List<int>(temp), result, index - 1);

                //加入目前的
                temp.Add(candidates[index]);

                //比較 => 進入下個recursive前都要比一下，不然其他階段比會重複比
                if (temp.Sum() == target)
                {
                    result.Add(temp);
                }
            }
        }
#endif

        //backtracking（回溯法）的真正意思
        //Backtracking 並不是「從後往前找」的意思，
        //而是指一種「試探 → 撤回」的遞迴策略。
        //核心概念是：
        //🔹 嘗試某個選擇（往前探索）
        //🔹 如果發現這條路走不通，就回到上一層（backtrack），撤銷那個選擇
        //🔹 然後再嘗試別的可能
        //所以它的重點是 「回退」到之前的狀態，不是「由後往前搜尋」

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            //time : O(2ⁿ) => 每個candidates都有true和 false兩種可選
            //space : O(n)
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates); 
            Backtrack(candidates, target, new List<int>(), 0, result);
            return result;
        }

        private void Backtrack(int[] candidates, int remain, List<int> temp, int index, IList<IList<int>> result)
        {
            if (remain < 0) //sort協助提早確認
            {
                return;
            }
            else if (remain == 0) //題目限定candidates[i] > 0 協助提早確認
            {
                result.Add(new List<int>(temp));
            }
            else
            {
                for(int i = index; i < candidates.Length; i++) //Backtracking 並不是「從後往前找」的意思
                {
                    //Backtrack 嘗試新條件
                    temp.Add(candidates[i]);
                    Backtrack(candidates, remain - candidates[i], temp, i, result); //傳入index還是i喔，因為可以嘗試自己，然後for迴圈會幫忙遍歷其他可能
                    //Backtrack 消除嘗試後條件
                    temp.RemoveAt(temp.Count-1); 
                }
            }
        }

        //https://leetcode.com/problems/combination-sum/solutions/16502/a-general-approach-to-backtracking-quest-dexx/
        //基本是看這位的，他把多題解法放在一起，看Combination Sum就好
    }
}
