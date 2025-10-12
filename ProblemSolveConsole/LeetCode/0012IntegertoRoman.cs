using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0012IntegertoRoman
    {
        public string IntToRoman(int num)
        {
            Dictionary<int, string> map = new Dictionary<int, string>()
            {
                {1, "I" },
                {5, "V" },
                {10, "X" },
                {50, "L" },
                {100, "C" },
                {500, "D" },
                {1000, "M" },
            };

            string result = "";
            int current = num;
            while (current != 0) 
            {
                (int leadingValue, int digit, int value) leadingInfo = GetLeadingInfo(current);

                if(leadingInfo.leadingValue < 5)
                {
                    if(leadingInfo.leadingValue == 4)
                    {
                        int newDigit = 5 * leadingInfo.digit;
                        result += map[leadingInfo.digit] + map[newDigit];
                    }
                    else
                    {
                        for (int i = 0; i < leadingInfo.leadingValue; i++)
                        {
                            result += map[leadingInfo.digit];
                        }
                    }
                }
                else
                {
                    if (leadingInfo.leadingValue == 9)
                    {
                        int newDigit = 10 * leadingInfo.digit;
                        result += map[leadingInfo.digit] + map[newDigit];
                    }
                    else
                    {
                        int newDigit = 5 * leadingInfo.digit;
                        result += map[newDigit];
                        for (int i = 0; i < leadingInfo.leadingValue - 5; i++)
                        {
                            result += map[leadingInfo.digit];
                        }
                    }
                }

                current -= leadingInfo.value;
            }

            return result;

        }

        public (int leadingValue, int digit, int value) GetLeadingInfo(int num)
        {
            int digit = 1;
            while (num >= 10)
            {
                num /= 10;
                digit *= 10;
            }
            return (num, digit, num * digit);
        }

        //Pattern Mapping 規則資料表轉換
        //我還在dictionary...，人家用map已經直接達成O(1) => 把選項的排列組合全寫出來，畢竟位數就那幾個，要更加務實和符合需求且小範圍易擴展的解法
        //https://leetcode.com/problems/integer-to-roman/solutions/6274/simple-solution/
        //這種略差但補足了9和4程式也會比我的乾淨
        //https://leetcode.com/problems/integer-to-roman/solutions/6310/my-java-solution-easy-to-understand/
    }
}
