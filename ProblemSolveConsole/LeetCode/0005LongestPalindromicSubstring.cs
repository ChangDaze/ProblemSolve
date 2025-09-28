using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0005LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            //https://leetcode.com/problems/longest-palindromic-substring/solutions/4212564/beats-96-49-5-different-approaches-brute-force-eac-dp-ma-recursion/

#if false //中心擴展法

            //中心擴展法 (Expand Around Center)
            //palindromic有兩種形式 1.奇數的中心點 2.偶數的中心點 ex: 131, 1221
            //最簡單的方法是走過每一點當中心點檢查是否palindromic
            //time : O(n^2) 因為for : n , expand : n
            //space : O(1)

            string max = "";
            for (int i = 0; i < s.Length; i++)
            {
                string oddMiddle = GetPalindromeFromIndexOdd(s, i);//已目前index為中心，用奇數的中心點左右擴展比對
                if (oddMiddle.Length > max.Length)
                {
                    max = oddMiddle;
                }

                if(i < s.Length - 1) //避免out of range
                {
                    string evenMiddle = GetPalindromeFromIndexEven(s, i);////已目前index為中心，用偶數的中心點左右擴展比對
                    if (evenMiddle.Length > max.Length)
                    {
                        max = evenMiddle;
                    }
                }
                
                int remainMaxPossible = 1 + (s.Length - (i + 1)) * 2;
                if(max.Length >= remainMaxPossible)
                {
                    break;
                }
            }

            return max;
                        
            string GetPalindromeFromIndexOdd(string input, int index)
            {
                return GetPalindrome(input, index - 1, index + 1, input.Substring(index, 1));
            }

            string GetPalindromeFromIndexEven(string input, int index)
            {
                if (input[index] != input[index + 1])
                {
                    return "";
                }
                return GetPalindrome(input, index - 1, index + 2, input.Substring(index, 2));
            }

            string GetPalindrome(string input, int left, int right, string middle)
            {
                string result = middle;

                while (left >= 0 && right < input.Length)
                {
                    if (input[left] != input[right])
                    {
                        break;
                    }

                    result = input[left] + result + input[right];
                    left--;
                    right++;
                }

                return result;
            }
#endif

#if true //動態規劃
            //動態規劃 (Dynamic Programming)
            //time : O(n^2) 因為雙層迴圈
            //space : O(n^2) 因為二元陣列
            //複雜度沒明顯改善但程式碼比起中心擴展有非常大幅的減少!

            if (s.Length <= 1) //長度為1的時候必定是自己
            {
                return s;
            }

            int maxLen = 1;
            int start = 0; //左端點
            int end = 0; //右端點
            bool[][] dp = new bool[s.Length][]; //[i][j] true 代表 j ~ i 字串有回文 => 為了dp 所以要從最小開始檢查到最大可能性
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = new bool[s.Length];
            }

            for (int i = 0; i < s.Length; i++) //一次固定一個右端點來檢查這個右端點底下所有的回文可能
            {
                dp[i][i] = true; //[i][i] 代表單一字串必定回文
                for (int j = 0; j < i; j++)
                {
                    //j = start, i = end
                    //i - j = 1 > 代表中間要是 奇數的中心點
                    //i - j = 2 > 代表中間要是 偶數的中心點
                    //其他靠過往dp紀錄
                    //dp[j + 1][i - 1] > 代表前一個動態紀錄是否回文 如果 true 然後 (j + 1) - 1 = j; (i - 1) + 1 且 s[i] == s[j]> 代表左右擴展回文成功
                    if (s[j] == s[i] && (i - j <= 2 || dp[i - 1][j + 1]))
                    {
                        dp[i][j] = true; //dp記錄此處有回文
                        if(i -j + 1 > maxLen)//算字串長度
                        {
                            maxLen = i - j + 1; 
                            start = j;
                            end = i;
                        }
                    }
                }
            }

            return s.Substring(start, end - start + 1);//從sstart取字串長度
#endif
        }
    }
}
