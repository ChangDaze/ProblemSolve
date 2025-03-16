using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2068CheckWhetherTwoStringsareAlmostEquivalent
    {
        public bool CheckAlmostEquivalent(string word1, string word2)
        {
            Dictionary<char, int> record = new Dictionary<char, int>();
            //word1用正，word2用負
            for(int i = 0; i < word1.Length; i++)
            {
                if (record.ContainsKey(word1[i]))
                {
                    record[word1[i]]++;
                }
                else
                {
                    record[word1[i]]=1;
                }

                if (record.ContainsKey(word2[i]))
                {
                    record[word2[i]]--;
                }
                else
                {
                    record[word2[i]] = -1;
                }
            }

            foreach(int value in record.Values)
            {
                if(Math.Abs(value) > 3) //絕對值大於三就代表兩字差異過多
                {
                    return false;
                }
            }

            return true;
        }

        //我有看到其他人用int[26]的，確實成本可能比dictionary低
        //這位用int[26]
        //https://leetcode.com/problems/check-whether-two-strings-are-almost-equivalent/solutions/1575960/c-straightforward/
        //這位不用abs直接用+3、-3同時比可能也不錯
        //https://leetcode.com/problems/check-whether-two-strings-are-almost-equivalent/solutions/1586119/java-easy-solution-using-hashmap/
    }
}
