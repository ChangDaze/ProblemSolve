using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1461CheckIfaStringContainsAllBinaryCodesofSizeK
    {
        public bool HasAllCodes(string s, int k)
        {
            int need = 1 << k;
            int mask = need - 1;
            if (s.Length < k + mask)
            {
                return false;
            }

            bool[] seen = new bool[need];

            int count = 0;
            int hash = 0;

            for(int i = 0; i < s.Length; i++)
            {
                hash = ((hash << 1) & mask) | (s[i] - '0');

                if(i >= k - 1)
                {
                    if (!seen[hash])
                    {
                        seen[hash] = true;
                        count++;

                        if(count == need)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
