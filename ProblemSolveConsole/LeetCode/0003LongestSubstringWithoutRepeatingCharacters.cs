using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0003LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            //有出現第二次的字就能中斷了
            //需要連續
            //可以用hash和two pointer來遞增遞減
            //也不用紀錄原字串，所以算長度即可

            //https://leetcode.com/problems/longest-substring-without-repeating-characters/solutions/3649636/3-method-s-c-java-python-beginner-friendly/
            //第一種方法一樣
            //第二種用記錄index方式優化讓window縮減時不用一一檢查，也不用重複新增移除set
            //第三種方式是用储存方式優化第二種方法

            HashSet<char> result = new HashSet<char>();
            int leftPointer = 0;
            int strike = 0;
            int maxStrike = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (result.Contains(s[i]))
                {
                    if (strike > maxStrike)
                    {
                        maxStrike = strike;
                    }

                    do
                    {
                        result.Remove(s[leftPointer]);
                        strike--;
                        leftPointer++;                        
                    }
                    while (result.Contains(s[i]));
                }

                result.Add(s[i]);
                strike++;
            }

            if (strike > maxStrike)
            {
                maxStrike = strike;
            }

            return maxStrike;
        }
    }
}
