using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0696CountBinarySubstrings
    {
#if false //舊方法，這好像是硬用simulate做出來的解法，很難看懂，但也是O(n)
            public int CountBinarySubstrings(string s)
            {
                int result = 0;
                int x = 0;//慢指標
                int y = 1;//快指標
                while (y < s.Length)
                {
                    if (s[x] == s[y])
                    {
                        if (s[y] == s[y - 1])//(1)x=y=y-1 => 一路推進y變號 => 會進入到x!=y開始計算result (3)y再度變號，不過x和y差了0個號同號了，繼續進行(1)
                            y += 1;
                        else//(3)y再度變號，x和y差了兩個號，所以要把x推進到只差一個號才能繼續計算result
                            x += 1;
                    }                        
                    else//(2)當x!=y代表x和y走在不同字上開始計算能算的result
                    {
                        result += 1;
                        x += 1;y += 1;
                    }
                }
                return result;
            }
#endif
        public int CountBinarySubstrings(string s)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            int result = 0;
            Dictionary<char, int> count = new Dictionary<char, int>() { { '0', 0 } , { '1', 0} };//當發生第一次轉換會是 min 會是 0 所以不會影響到答案
            char currrent = s[0];
            for (int i = 0; i < s.Length; i++)
            {
                if(currrent == s[i])
                {
                    count[s[i]]++;
                }
                else//當轉換時計算result並將輪到的記數轉為1
                {
                    result += Math.Min(count['0'],count['1']); //ex:1100是2，000111是3，00011是2
                    currrent = s[i];
                    if(currrent == '1')
                    {
                        count['1'] = 1;
                    }
                    else
                    {
                        count['0'] = 1;
                    }
                }
            }

            result += Math.Min(count['0'], count['1']);
            return result;
        }

        //https://leetcode.com/problems/count-binary-substrings/solutions/108625/javacpython-easy-and-concise-with-explan-li94/?envType=daily-question&envId=2026-02-19
        //這位的計算方法其實跟我一樣耶，不過他用得更精準所以不需要dictionary，他只用i、i-1、cur、pre等幾個變數組成狀態而已，值得學習
        //https://leetcode.com/problems/count-binary-substrings/solutions/108600/java-on-time-o1-space-by-compton_scatter-h232/?envType=daily-question&envId=2026-02-19
        //這個 方法也一樣
        //https://leetcode.com/problems/count-binary-substrings/solutions/127470/count-binary-substrings-by-leetcode-qutq/?envType=daily-question&envId=2026-02-19
        //這個官方的法一和法二其實一樣，只是法一多用int[]把每次變化的group記錄起來而已，也算簡單易懂

        //這樣看來我的方法會慢主要就是多用了幾個變數，然後大家解法都相同，不然概念上其實和大家方法一樣
    }
}
