using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3099HarshadNumber
    {
        public int SumOfTheDigitsOfHarshadNumber(int x)
        {
            int sum = 0;
            int current = x;

            while(current > 0)
            {
                sum += current % 10;
                current /= 10;
            }

            return x % sum == 0 ? sum : -1;
        }
    }
}
