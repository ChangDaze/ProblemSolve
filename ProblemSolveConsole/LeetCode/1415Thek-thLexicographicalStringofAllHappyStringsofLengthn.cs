using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
#if false //其實這個舊方法某方面比我新方法簡潔耶，也是backtracking不過用純字串，如果不是長字串，資源消耗應該還好
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
            //Time complexity:O(3 * 2^(n−1)) =>原本是3^n，但因為不能連續一樣的所以變2^(n−1)
            //Space complexity:O(n) => 長度n
            char[] chars = ['a', 'b', 'c']; //這個限制不管幾個差異都不大，因為abab也算符合條件，所以限制的只有不要跟上一個字元相同而已
            List<char> result = new List<char>();
            int count = 0;
            Recursive(chars, 0, result, k, n,ref count);            
            return String.Concat(result);//組合結果
        }

        private void Recursive(char[] chars, int layer, List<char> result, int k, int n, ref int count)
        {
            //chars => 照順序backtracing用，才可以符合lexicographical
            //layer => 其實就是index，用來跟上一個字元比對用
            //result => 用來储存backtracing目前的字串結果
            //k => 題目要求的要第k個字串，和count呼應
            //n => 題目要求的字串符合長度
            //count => 目前第幾個，和k呼應

            if (result.Count == n)//字串符合長度
            {
                count++;//計算目前第幾個
                return;
            }

            foreach (char c in chars)
            {
                if(layer != 0 && result[layer - 1] == c) //跟上一個字元比對
                {
                    continue;                    
                }

                result.Add(c);//backtracing開始
                Recursive(chars, layer + 1, result, k, n, ref count);
                if (count == k)//找到，第k個字串，將result完整送回去，不Remove了
                {
                    break;
                }
                result.RemoveAt(layer);//backtracing結束


            }
        }
    }

    //https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/solutions/6401580/the-k-th-lexicographical-string-of-all-h-6b63/?envType=daily-question&envId=2026-03-14
    //這個是官方解法，前三個方法也是backtracing
    //第四個方法是重點，是用math，不能說是很棒的解，但是一個很針對性地解
    //1.因為限制3個字元+lexicographical，所以k可找出分布的位置
    //2.因為限制3個字元+不能連續重複，可以簡單的用binary search的方式找下個字元
    //詳細還是要看解說，但確實達到 time O(n) space O(n) 的效果 => 下此可以試試看或至少默寫記一下
    //https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/solutions/7646558/aot-beats-100-see-it-in-action-by-nandin-xi9p/?envType=daily-question&envId=2026-03-14
    //這個方法其實蠻厲害的耶，跟第一位approach 4有點不同
    //他用 k/potenial (potenial = 可能的組合數) 然後 loop k%potenial 的方式進行，因為k/potenial會只留下整數 ex: k/potenial = a 的位置 (實際是a~b之間)， 下次loop 就變 a + k/(k%potenial) 類似十分逼近的方式
    //也確實會是 time O(n) space O(n)
    //https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/solutions/7646677/simple-greedy-beginner-friendly-beats-10-v384/?envType=daily-question&envId=2026-03-14
    //這位方法應該是第一位approach 4的變異版，但概念一樣

    //看來其實這題還是要想辦法追求O(n)，但有點偏數學，可能要多練習才能在面試短時間內寫出來O(n)方法
}
