using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0476NumberComplement
    {
        public int FindComplement(int num)
        {
            int result = 0;
            int pow = 0;
            while (num > 0)
            {
                if(!((num & 1) == 1))
                {
                    result += (int)Math.Pow(2, pow);
                }
                
                num >>= 1;
                pow++;
            }

            return result;
        }
    }
}
