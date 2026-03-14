using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
#if false
    public class Solution
    {
        int k = 0;
        string result = "";
        List<char> happyChars = new List<char>() { 'a', 'b', 'c' };
        public string GetHappyString(int n, int k)
        {
            this.k = k;
            Recursive("", ' ', n);
            return result;
        }

        private void Recursive(string str, char preChar, int n)
        {
            if (str.Length == n)
            {
                k--;
                if (k == 0) result = str;
                return;
            }

            foreach (char c in happyChars)
            {
                if (c == preChar) continue;
                Recursive(str + c, c, n);
            }
        }
    }
#endif
    public class _1415Thek_thLexicographicalStringofAllHappyStringsofLengthn
    {
        public string GetHappyString(int n, int k)
        {
            char[] chars = ['a', 'b', 'c'];
            List<char> result = new List<char>();
            int count = 0;
            Recursive(chars, 0, result, k, n,ref count);
            return String.Concat(result);
        }

        private void Recursive(char[] chars, int layer, List<char> result, int k, int n, ref int count)
        {
            if(result.Count == n)
            {
                count++;
                return;
            }

            foreach (char c in chars)
            {
                if(layer != 0 && result[layer - 1] == c)
                {
                    continue;                    
                }

                result.Add(c);
                Recursive(chars, layer + 1, result, k, n, ref count);
                if (count == k)
                {
                    break;
                }
                result.RemoveAt(layer);

                
            }
        }
    }
}
