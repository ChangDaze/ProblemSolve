using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1668MaximumRepeatingSubstring
    {
        public int MaxRepeating(string sequence, string word)
        {
            //Time complexity:O(kn)
            //Space complexity:O(n)
            if (sequence.Length < word.Length) return 0;

            int max = 0;
            int[] dp = new int[sequence.Length];
            int beforeContain = word.Length - 1;

            //因為i- word.Length在i=0會outofrange，所以第一個長度比較先主動做完
            dp[beforeContain] = 1;
            max = 1;
            for (int j = 0; j < word.Length; j++)//因為這個match比較所以會變k*n但還是有dp效果，所以比k*n^2好
            {
                if (word[j] != sequence[j])
                {
                    dp[beforeContain] = 0;
                    max = 0;
                    break;
                }
            }            

            
            for (int i = word.Length; i < sequence.Length; i++)//注意開頭是word.Length不是beforeContain，前一步比過了，所以可以多往後一格
            {
                bool match = true; //預設有match
                int start = i - beforeContain;
                for (int j = 0; j < word.Length; j++)//因為這個match比較所以會變k*n但還是有dp效果，所以比k*n^2好
                {
                    if(word[j] != sequence[start + j])
                    {
                        match = false;//發現沒match剪枝
                        break;
                    }
                }

                if (match) //只有match才有資格繼續dp
                {
                    dp[i] = dp[i- word.Length] + 1; //dp效果，要注意這裡不是i- start是i- word.Length，因為連續字串不能重疊!
                    if (dp[i] > max)
                    {
                        max = dp[i]; //只取過往最大值
                    }
                }
            }

            return max;
        }

        //題目本質跟0070ClimbingStairs一模一樣，只是
        //1.從往前階數取值變成往前match比較
        //2.注意是取dp[i- word.Length]，所以沒有重疊
        //3.因為沒有重疊所以要注意outofrange
        //4.最大值不是dp[n]

        //https://leetcode.com/problems/maximum-repeating-substring/solutions/952026/javapython-3-bruteforce-4-liners-w-analy-kbzz/?page=3
        //這個其實蠻有趣的，雖然是bruteforce但其實有很強的剪枝能力，但如果重複很多就比較容易烙賽，簡單講就是從重複少到重複多疊加，每疊加一次用sequence去contains一次，但這應該是n^3? => 可能contain有優化成n，所以實際是n^2 XD
        //我發現很多人用耶，意外
        //https://leetcode.com/problems/maximum-repeating-substring/solutions/5642811/java-dp-solution-by-lexiestudyversion-8d4z/?page=3
        //這位的方法就跟我一樣了，不過他用substring(start, not contain end) + int[] dp = new int[n + 1];，所以語法比我優雅多了

        //還有看到用KMP的，不過還沒常用到還沒記起來所以先跳過
    }
}
