using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1295FindNumberswithEvenNumberofDigits
    {
        public int FindNumbers(int[] nums)
        {
            int result = 0;

            foreach(int num in nums)
            {
                string numStr = num.ToString();

                if(numStr.Length%2==0)
                {
                    result++;
                }
            }

            return result;
        }

        //這蠻有趣的，用限制來解題
        //https://leetcode.com/problems/find-numbers-with-even-number-of-digits/solutions/459489/java-solution-with-100-better-space-and-time/
        //這個官方解題，方法很多種，不過他也把轉換算進複雜度中...
        //https://leetcode.com/problems/find-numbers-with-even-number-of-digits/editorial/
    }
}
