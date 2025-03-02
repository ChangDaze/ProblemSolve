using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3019NumberofChangingKeys
    {
        public int CountKeyChanges(string s)
        {
            int changeCount = 0;
            int temp = s[0];
            foreach(char c in s)
            {
                if(!((temp == c) || temp == (c+32) || temp == (c - 32)))
                {
                    changeCount++;
                }
                

                temp = c;
            }

            return changeCount;
        }
    }

    //一般都是直接tolower或字元用int比對
    //https://leetcode.com/problems/number-of-changing-keys/solutions/4636782/simple-java-solution/
}
