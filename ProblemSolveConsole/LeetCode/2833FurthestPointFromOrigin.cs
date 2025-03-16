using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2833FurthestPointFromOrigin
    {
        public int FurthestDistanceFromOrigin(string moves)
        {
            //用規則只出現3個單字來寫死
            Dictionary<char, int> record = new Dictionary<char, int>()
            {
                { 'R', 0 },
                { 'L', 0 },
                { '_', 0 },
            };
            for (int i = 0; i < moves.Length; i++)
            {
                record[moves[i]]++;
            }

            return record['R'] > record['L'] ? record['R'] - record['L'] + record['_'] : record['L'] - record['R'] + record['_'];
        }

        //直接用abs + _的count，不用dictionary會更快...
        //https://leetcode.com/problems/furthest-point-from-origin/solutions/3965638/java-c-python-easy-count/
    }
}
