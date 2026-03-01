using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0831MaskingPersonalInformation
    {
        public string MaskPII(string s)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            //最後一碼 phone 會有'-'的符號，所以不能單用s最後一碼是否為數字判斷
            int atIndex = s.IndexOf('@');
            if (atIndex != -1)
            {
                return MaskEmail(s, atIndex);
            }
            else
            {
                return MaskPhone(s);
            }
            
        }

        private string MaskEmail(string s, int atIndex)
        {            
            return $"{Char.ToLower(s[0])}*****{Char.ToLower(s[atIndex - 1])}{s.Substring(atIndex).ToLower()}";
        }

        private string MaskPhone(string s)
        {
            int localStart = 0;
            List<char> nums = new List<char>();
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(s[i]))
                {
                    nums.Add(s[i]);
                }

                if(nums.Count >= 10)
                {
                    localStart = i;
                    break;
                }
            }
            nums.Reverse();

            string prefix = "";
            if(localStart > 0)
            {
                for(int i = 0; i < localStart; i++)
                {
                    if (Char.IsDigit(s[i]))
                    {
                        prefix += '*';
                    }
                }

                if(prefix.Length > 0)
                {
                    prefix = '+' + prefix + '-';
                }
            }

            return $"{prefix}***-***-{nums[6]}{nums[7]}{nums[8]}{nums[9]}";
        }

        //這題感覺要更注重跟面試官取得情報，像我test 5 ~ 6都是一開始沒考慮到的，或至少問問能不能多幾個edge case 或 special case
        //ex:test5 => phone最後一碼可以是非字元、test6 => 雖然剛好10個num但開頭原本有會有字元符號
        //其他表現應該是在加速部分，但我覺得沒特別練習過或其他想法應該很難選到特別快的(因為string方法太多了)

        //https://leetcode.com/problems/masking-personal-information/solutions/128955/javacpython-easy-and-concise-by-lee215-hsfl/
        //對阿這位直接lowercase、正則取代phone的字元+country map，很難說哪種速度比較快，不過他的程式碼確實少
        //https://leetcode.com/problems/masking-personal-information/solutions/128976/short-python-solution-by-solomon3-4bjq/
        //這位也是lowercase、正則
        //https://leetcode.com/problems/masking-personal-information/solutions/128967/masking-personal-information-by-leetcode-ts8l/
        //這位是官方的，但他竟然寫O(1) (假的...)，事實上跟前面兩位比也沒比較好...

        //前面幾個都solution pythonXDD，python感覺很適合這種
    }
}
