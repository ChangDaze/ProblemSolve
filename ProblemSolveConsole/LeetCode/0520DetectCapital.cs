using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0520DetectCapital
    {
#if false //舊方法，其實以前的方法更好耶，只是要馬上想到要有點靈光，除了word[i] - 'A' < 26處理可能有點粗糙，其實方法很好
    public bool DetectCapitalUse(string word) 
    {
        if (word.Length < 2) return true;
        bool firstIsCapital = word[0] - 'A' < 26;
        bool secondIsCapital = word[1] - 'A' < 26;
        if (!firstIsCapital && secondIsCapital) return false;
        for (int i = 2; i < word.Length; i++)
        {
            bool isCapital = word[i] - 'A' < 26;
            if ((secondIsCapital && !isCapital) || (!secondIsCapital && isCapital)) return false;
        }
        return true;
    }
#endif
        public bool DetectCapitalUse(string word)
        {
            bool result = true;
            bool hasSmall = false;
            bool hasBig = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] > 'Z' && !hasSmall )//如果有small出現，後面就不能有big出現
                {
                    hasSmall = true;
                }
                else if(word[i] < 'a' && !hasBig &&  i > 0) //首個字母是大是小不影響
                {
                    hasBig = true;
                }

                if(hasSmall && hasBig)
                {
                    result = false;
                    break;//可以直接return 不用再break了
                }
            }

            return result;
        }

        //https://leetcode.com/problems/detect-capital/solutions/99249/python-has-useful-methods-by-stefanpochm-h7ii/
        //這直接用python提供的api，說不定C#也有，只是複雜度上效果可能比較不好，因為要走3次
        //https://leetcode.com/problems/detect-capital/solutions/2982608/easiest-c-solution-on-0ms-by-ayushsenapa-fkgx/
        //這個判斷其實也不錯，他直接列舉true的結果然後用count當flag，不過我的方法也只多一個flag，會影響的差異可能主要是for內的if，但我覺得差異應該還是很小
        //https://leetcode.com/problems/detect-capital/solutions/99298/java-1-liner-by-lixx2100-5iyd/
        //這位用正則XDD

        //因為是string所以解法非常多，就沒有說標準解法，不用硬記
    }
}
