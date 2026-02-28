using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0482LicenseKeyFormatting
    {
#if false //舊方法，就是一堆API做brute force，問AI，Insert(0, '-')是對char[]操作，所以效果很差，新版C#sb底層不單純是char[]，但是在容量不足擴容時才有實作像linkedlist的block，不同block間還是單獨char[]存字元
        public string LicenseKeyFormatting(string S, int K)
        {
            var s = S.Replace("-", "").ToUpper();

            var i = s.Length;

            var sb = new StringBuilder();

            while (i >= 0)
            {
                sb.Insert(0, s.Substring(Math.Max(i - K, 0), Math.Min(i, K)));//也是由後往前

                if (i > K) sb.Insert(0, '-');//判斷i > K，所以Insert(0, '-')時必定還有下個group

                i -= K;
            }

            return sb.ToString();
        }
#endif
        public string LicenseKeyFormatting(string s, int k)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            Stack<char> stack = new Stack<char>(); //由後往前所以用stack存，也可以用linked list 效果應該差不多
            int c = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if(s[i] == '-')//原本'-'可以無視
                {
                    continue;
                }

                c++;
                if(s[i] > 90)//小寫變大寫
                {
                    stack.Push((char)(s[i]-32));
                }
                else
                {
                    stack.Push(s[i]);
                }
                
                if(c%k  == 0)//滿足k'-'
                {
                    while(i > 0)//最後一個group至少要一個字元，所以開始檢查下個字元，下個字元是'-'可以順變推進i，因為可能有連續多個'-'，當index==0時不再有下個字元只檢查i > 0
                    {
                        if (s[i-1] != '-')
                        {
                            stack.Push('-');//有下個字元才補'-'
                            break;
                        }
                        else
                        {
                            i--;
                        }
                    }                    
                }
            }

            StringBuilder stringBuilder = new StringBuilder();//StringBuilder省資源
            while (stack.Count > 0)
            {
                stringBuilder.Append(stack.Pop());
            }
            
            return stringBuilder.ToString();
        }

        //https://leetcode.com/problems/license-key-formatting/solutions/96512/java-5-lines-clean-solution-by-yuxiangmu-bgv9/
        //這位用的方法非常精準，值得記住
        //1.他用sb.length() % (k + 1) == k =>他是判斷現在的i是否能成立新的群組而非現在是否完成了一個群組，他可以不用像我用while判斷下個字元! x % (k + 1) == k => 這個數學判斷方法非常值得記住
        //2.sb.reverse() 他用sb直接reverse其實也行! 雖然我用stack沒比較差，但他這種就很適合新手，不過不太建議他用的.toString().toUpperCase()，在過程中自己轉換可能可以省一個O(n)
        //https://leetcode.com/problems/license-key-formatting/solutions/131978/beats-100-python3-submission-by-orphyus-lo03/
        //這位概念跟我舊方法一樣，不過python的處理複雜度可能比較好
        
        //其實可以看出string有非常多解法，所以解題容易，比較細節可能就是考慮到資源利用
    }
}
