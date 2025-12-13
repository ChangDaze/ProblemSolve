using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3606CouponCodeValidator
    {
        public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
        {
            //n = code.Length（coupon 數量）
            //L = 所有 code[i] 字串長度總和
            //k = 通過驗證、被加入的 coupon 數量
            //time: O(L + k log k) > k log k主要for合法數量排序
            //space: O(k) 合法數量
            HashSet<char> validChars = new HashSet<char>()
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                '0','1','2','3','4','5','6','7','8','9',
                '_'
            };

            Dictionary<string, List<string>> validCategories = new Dictionary<string, List<string>>()
            {
                {"electronics", new List<string>() },
                {"grocery", new List<string>() },
                {"pharmacy", new List<string>() },
                {"restaurant", new List<string>() },
            };


            for(int i  = 0; i < code.Length; i++)
            {
                if (!isActive[i])
                {
                    continue;
                }

                if(!validCategories.ContainsKey(businessLine[i]))
                {
                    continue;
                }

                bool valid = true;

                foreach(char c in code[i])
                {
                    if (!validChars.Contains(c))
                    {
                        valid = false;
                        break;
                    }
                }

                if (code[i].Length == 0 || !valid) //長度0也不合法
                {
                    continue;
                }

                validCategories[businessLine[i]].Add(code[i]);
            }

            List<string> result = new List<string>();

            string[] order = ["electronics", "grocery", "pharmacy", "restaurant"]; //種類順序
            foreach(string c in order)
            {
                result.AddRange(validCategories[c].Order(StringComparer.Ordinal));//字典順序
            }

            return result;
        }

        //結果C#也有isLetterOrDigit，不過如果基本不會變化的話hashset說不定也不錯
        //https://leetcode.com/problems/coupon-code-validator/solutions/7409915/c-easy-soultion-with-explaination-by-vis-0itv/?envType=daily-question&envId=2025-12-13&page=3
        //其實就是simulation，大家方法都差不多，不過我看其他人寫得好複雜...
    }
}
