using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2651CalculateDelayedArrivalTime
    {
        public int FindDelayedArrivalTime(int arrivalTime, int delayedTime)
        {
            return (arrivalTime + delayedTime) % 24;
        }

        //大家計算都一樣簡單
        //https://leetcode.com/problems/calculate-delayed-arrival-time/solutions/3446040/leetcode-the-hard-way-one-line/
    }
}
