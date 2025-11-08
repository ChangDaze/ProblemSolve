using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0038CountandSay
    {
        public string CountAndSay(int n)
        {
            //Conway 常數 => 這是被發現的增長規律最終趨近約1.3
            //time : O(1.3ⁿ)
            //space : O(1.3ⁿ)
            //兩者基本上就是全遍歷

            string result = "1";

            for (int i = 2; i <= n; i++)
            {
                string tempResult = "";
                int count = 1;
                char current = result[0];
                for(int j = 1; j<result.Length; j++)
                {
                    if (result[j] == current)
                    {
                        count++;
                    }
                    else
                    {
                        tempResult += (count.ToString() + current.ToString());
                        count = 1;
                        current = result[j];
                    }
                }

                tempResult += (count.ToString() + current.ToString());
                result = tempResult;
            }

            return result;
        }

        //https://leetcode.com/problems/count-and-say/solutions/16040/straightforward-java-solution-by-zhibzha-s886/
        //意外的大家好像就單純用暴力解 => gpt也這樣說，甚至說dp也沒用XD
        //當然隨著長度會增長 tempResult 用 string builder應該比較好
    }
}
