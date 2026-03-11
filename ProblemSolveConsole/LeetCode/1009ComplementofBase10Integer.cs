using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1009ComplementofBase10Integer
    {
        public int BitwiseComplement(int n)
        {            
            if(n == 0) return 1; //edge case

            int temp = n;
            int mask = 1;
            while (temp != 0)
            {
                temp >>= 1;
                mask <<= 1;
            }
            mask -= 1;

            return mask ^ n;
        }
        //題目只是要找補數而已...要看清楚題目base10，沒有要再另外處理
    }
}
