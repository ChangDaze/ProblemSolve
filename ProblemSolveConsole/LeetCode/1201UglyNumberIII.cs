using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1201UglyNumberIII
    {
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            //time : O(log(high) * log(min(a, b, c)))
            //space : O(1)
            long low = 1;
            long high = long.MaxValue;
            long ans = high;
            while (low <= high)
            {
                long mid = low + (high - low) /2;
                if(Count(mid, a, b, c) >= n)
                {
                    ans = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return (int)ans;
        }

        private long Count(long n,long a, long b, long c)
        {
            return (n / a + n / b + n / c)
                - (n / GetLCM(a, b) + n / GetLCM(b, c) + n / GetLCM(a, c))
                + (n / GetLCM(GetLCM(a, b), c));
        }

        private long GetGCD(long a, long b)
        {
            while(b!=0)
            {
                a %= b;
                (a, b) = (b, a);
            }
            return a;
        }

        private long GetLCM(long a, long b)
        {
            return (a / GetGCD(a, b)) * b;
        }
    }
}
