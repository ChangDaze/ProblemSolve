using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3168MinimumNumberofChairsinaWaitingRoom
    {
        public int MinimumChairs(string s)
        {
            //人會進進出出，但椅子不會變，所以一開始最少要擺幾張椅子才能讓進出的人同時都有位置可座
            //找出峰值
            int max = 0; //峰值
            int current = 0; //目前人數

            foreach (char c in s)
            {
                if(c == 'L')
                {
                    current--;
                    continue; //因為減少就一定不是峰值
                }
                else if (c == 'E')
                {
                    current++;
                }

                if (current > max)
                {
                    max = current;
                }
            }

            return max;
        }

        //replace LE方法最後會變有EEELL這種，還蠻有意思的解法，但沒有說比較好
        //https://leetcode.com/problems/minimum-number-of-chairs-in-a-waiting-room/solutions/5256703/2-method-very-easy-solution-is-0ms/
    }
}
