using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0459RepeatedSubstringPattern
    {
#if false //舊方法，跟新方法差不多O(N sqrt(N))，不過難讀一點
        public bool RepeatedSubstringPattern(string str)
        {
            for (int i = 0; i < str.Length / 2; ++i)
            {
                int patternLength = i + 1;//+1好像沒有特別必要耶?不確定
                if ((str.Length / (double)patternLength) % 1 != 0)
                {
                    continue;
                }
                for (int j = i + 1; j < str.Length; ++j) //這裡應該就是暴力檢查每個字元
                {
                    if (str[j] != str[(j - (patternLength)) % patternLength])
                    {
                        break;
                    }
                    if (j == str.Length - 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
#endif
        public bool RepeatedSubstringPattern(string s)
        {
            //Time complexity:O(N sqrt(N))
            //Space complexity:O(n)
            int startLen = s.Length / 2;

            for(int curLen = startLen; curLen > 0; curLen--)
            {
                if(s.Length % curLen != 0) //剪枝，但應該避免不了這個方法應該是O(n^2) => 意外是 O(N sqrt(N))
                {
                    continue;
                }

                //也可以用string.Concat(Enumerable.Repeat("abc", 3));
                //這裡insert 0 因為sb是空的，不會有複製問題，字串在末尾 貼上 startLen 次
                if (new StringBuilder(s.Length).Insert(0, s.Substring(0, curLen), s.Length / curLen).ToString() == s) 
                {
                    return true;
                }
            }

            return false;
        }

        //在數學上，一個數字 N 的因數數量（我們稱之為 d(N)）增長得非常非常慢。
        //假設 N = 100：因數只有 9 個。假設 N = 10,000（LeetCode 常見上限）：因數最多只有 64 個！
        //結論：最差時間複雜度不是 O(N^2)，而是 O(N * d(N))。在演算法漸近分析中，因數數量上限約為 O(sqrt(N))，所以這個演算法的嚴格上限是 O(N sqrt(N))。

        //https://leetcode.com/problems/repeated-substring-pattern/solutions/94352/java-simple-solution-with-explanation-by-pi85/
        //這位方法跟我一樣耶
        //https://leetcode.com/problems/repeated-substring-pattern/solutions/94334/easy-python-solution-with-explaination-b-ys8p/
        //https://leetcode.com/problems/repeated-substring-pattern/solutions/94344/simple-java-solution-2-lines-by-fhqplzj-5lmp/
        //這兩位都應該算O(N)，簡單講是 讓 ss = s + s，然後ss[1:-1].contain(s)就算true，但不確定怎麼證明，但基本上如果對應該就是最佳解
        //因為它是重複的，所以它能平移重疊 => 這是100%確定的，但我不會證明...

        //https://leetcode.com/problems/repeated-substring-pattern/solutions/94397/c-on-using-kmp-32ms-8-lines-of-code-with-zerj/
        //好像還有KMP解法是最佳解...，但我腦容量不夠，交給下個自己在專門練習吧...
    }
}
