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
                (int leadingValue, int digit, int value) leadingInfo = getLeadingValueAndDigitl(current);

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

        public (int leadingValue, int digit, int value) getLeadingValueAndDigitl(int input)
        {
            int current = input;
            decimal digit = 0.1m; //最後一定是 >= 1
            int leadingValue = 0;

            do
            {
                //確定有的
                digit *= 10;
                leadingValue = current;
                //執行後要確定的
                current /= 10;
            }
            while (current != 0);


            return (leadingValue, (int)digit, leadingValue * (int)digit);
        }
    }
}
