using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1725NumberOfRectanglesThatCanFormTheLargestSquare
    {
        public int CountGoodRectangles(int[][] rectangles)
        {
            int maxLen = -1;
            int maxRecord = 0;

            for(int i = 0; i < rectangles.Length; i++)
            {
                //選出較小者
                int rectangle = rectangles[i][0] > rectangles[i][1] ? rectangles[i][1] : rectangles[i][0];

                if (rectangle < maxLen)
                {
                    continue;
                }
                else if (rectangle == maxLen)
                {
                    maxRecord++;
                }
                else
                {
                    maxLen=rectangle;
                    maxRecord = 1;
                }

            }

            return maxRecord;
        }

        //大家解法都差不多，不過我多寫了continue
        //https://leetcode.com/problems/number-of-rectangles-that-can-form-the-largest-square/solutions/1054626/java-easy-and-100-solution/
    }
}
