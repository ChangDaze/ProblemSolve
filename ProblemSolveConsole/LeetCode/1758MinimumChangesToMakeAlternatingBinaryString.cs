using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1758MinimumChangesToMakeAlternatingBinaryString
    {
        public int MinOperations(string s)
        {
            char[] firstZero = s.ToCharArray(); //偶數0 奇數1 正確
            int firstZeroCount = 0;
            if (firstZero[0] != '0') {
                firstZero[0] = '0';
                firstZeroCount++; 
            }
            char[] firstOne = s.ToCharArray(); //偶數1 奇數0 正確
            int firstOneCount = 0;
            if (firstOne[0] != '1') {
                firstOne[0] = '1';
                firstOneCount++; 
            }
            
            for (int i = 1; i < s.Length; i++)
            {
                if(firstZero[i] == firstZero[i - 1])
                {
                    firstZero[i] = firstZero[i - 1] == '1' ? '0' : '1';
                    firstZeroCount++;
                }

                if (firstOne[i] == firstOne[i - 1])
                {
                    firstOne[i] = firstOne[i - 1] == '1' ? '0' : '1';
                    firstOneCount++;
                }
            }

            return Math.Min(firstZeroCount, firstOneCount);
        }
    }
}
