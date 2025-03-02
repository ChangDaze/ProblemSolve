using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1450NumberofStudentsDoingHomeworkataGivenTime
    {
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int count = 0;

            for(int i = 0; i < startTime.Length; i++)
            {
                //return the number of students where queryTime lays in the interval [startTime[i], endTime[i]] inclusive.
                if ( startTime[i] <= queryTime && queryTime <= endTime[i])
                {
                    count++;
                }
            }

            return count;
        }

        //就很簡單的計算
        //https://leetcode.com/problems/number-of-students-doing-homework-at-a-given-time/solutions/636365/java-python-3-simple-code/
    }
}
