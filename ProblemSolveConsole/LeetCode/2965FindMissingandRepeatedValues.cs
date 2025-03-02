using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2965FindMissingandRepeatedValues
    {
        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            int[] result = new int[2]; //[0] : repeating ; [1] : missing
            int sum = 0;
            HashSet<int> record = new HashSet<int>();
            for (int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if (record.Contains(grid[i][j]))
                    {
                        result[0] = grid[i][j];
                    }
                    else
                    {
                        record.Add(grid[i][j]);
                    }
                    sum += grid[i][j];
                }
            }

            int tail = grid.Length * grid.Length; //下底
            int perfectSum = ((1 + tail) * tail) / 2; //梯形公式
            result[1] = perfectSum - sum + result[0]; //算出missing值

            return result;
        }

        //這除了一般的iterate外還有一個數學解，但感覺沒比較好因為還是要iterate一次...
        //然後他們是把iterate所有值視作n^2，我是覺得不太對啦...
        //https://leetcode.com/problems/find-missing-and-repeated-values/editorial/
    }
}
