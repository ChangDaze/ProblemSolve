using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1422MaximumScoreAfterSplittingaString
    {
        public int MaxScore(string s)
        {
            //left score array
            //iterate from left to right record 0's accumulate score
            //right score array
            //iterate from right to left record 0's accumulate score
            //left score array plus right score array to chose the biggest score from plus array

            //space O(2N) left array + right array
            //time O(3N) left array + right array + find max

            //left and right not empty

            int score = 0;            
            int[] leftScoreArray = new int[s.Length];//contain i start from 0 end at leftScoreArray.Length-2

            for (int i = 0; i < leftScoreArray.Length-1; i++)
            {
                if (s[i] != '0')
                    continue;
                score++;
                leftScoreArray[i] = score;
            }

            score = 0;
            int[] rightScoreArray = new int[s.Length];// not contain i start from leftScoreArray.Length-2  end at 0
            for (int i = leftScoreArray.Length-2; i > -1 ; i--)
            {
                if (s[i+1] != '1')
                    continue;
                score++;
                rightScoreArray[i] = score;
            }

            int maxScore = -1;

            for(int i = 0; i <= s.Length-2; i++) //compare 0 ~ Length-2
            {
                int plus = leftScoreArray[i] + rightScoreArray[i];
                if (plus > maxScore)
                    maxScore = plus;
            }

            return maxScore;
        }

        //https://leetcode.com/problems/maximum-score-after-splitting-a-string/editorial/
        //這個第2(比我省去多餘空間，也少繞一次)，第3方法(這比較偏數學解，思考方向要轉彎，但很棒)都更好
        //這好像不算suffix array 比較像 suffix sum
    }
}
