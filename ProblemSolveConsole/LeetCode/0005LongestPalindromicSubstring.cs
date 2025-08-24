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
            //中心擴展法 (Expand Around Center)
            //palindromic有兩種形式 1.奇數的中心點 2.偶數的中心點 ex: 131, 1221
            //最簡單的方法是走過每一點當中心點檢查是否palindromic
            //time : O(n^2) 因為for : n , expand : n
            //space : O(1)

            string max = "";
            for (int i = 0; i < s.Length; i++)
            {
                string oddMiddle = GetPalindromeFromIndexOdd(s, i);
                if (oddMiddle.Length > max.Length)
                {
                    max = oddMiddle;
                }

                if(i < s.Length - 1) //避免out of range
                {
                    string evenMiddle = GetPalindromeFromIndexEven(s, i);
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
        }
    }
}
