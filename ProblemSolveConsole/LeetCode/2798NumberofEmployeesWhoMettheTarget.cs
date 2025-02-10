using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2798NumberofEmployeesWhoMettheTarget
    {
        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            int count = 0;
            foreach (int hour in hours) 
            {
                if(hour >= target) count++;
            }
            return count;
        }
    }
}
