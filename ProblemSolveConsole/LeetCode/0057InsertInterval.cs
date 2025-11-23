using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0057InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            //基本上follow 0056 的解法，再另外處理newInterval就好 => 最蠢其實就insert進去然後再跑一次就好XD => 頂多多跑一次O(n)
            //time: O(n + nlogn) 
            //space: O(n)

            List<int[]> newIntervals = intervals.ToList();
            newIntervals.Add(newInterval);
            int[][] newIntervalsArray = newIntervals.ToArray();

            Array.Sort(newIntervalsArray, (a,b) => a[0].CompareTo(b[0]));
            List<int[]> result = new List<int[]>();

            int[] tempInterval = newIntervalsArray[0];
            result.Add(tempInterval);

            for(int i = 1; i < newIntervalsArray.Length; i++)
            {
                if (tempInterval[1] >= newIntervalsArray[i][0])
                {
                    tempInterval[1] = tempInterval[1] > newIntervalsArray[i][1] ? tempInterval[1] : newIntervalsArray[i][1];
                }
                else
                {
                    tempInterval = newIntervalsArray[i];
                    result.Add(tempInterval);
                }
            }

            return result.ToArray();
        }

        //https://leetcode.com/problems/insert-interval/description/
        //這題我好像有兩個細節沒注意到
        //1.intervals早已被sorted
        //2.intervals原本一定沒有overlap...
        //所以題目可能要求一定要O(n)...不然解題意義不大 => 這是我犯的錯
        //anyway，這位的解法就嚴格follow上面兩個前置條件，(1)小於但沒overlap，加入i(2)大於於但沒overlap，加入newInterval和i(3)overlap，更新newInterval，看後面還有沒有overlap(4)最後檢查newInterval是否殘留要加入result
        //https://leetcode.com/problems/insert-interval/solutions/21602/short-and-straight-forward-java-solution-h749/?page=3
        //1.加入比較小的
        //2.處理overlap
        //3.加入newInterval
        //4.加入比較大的
        //重點在原本就sort過，所以在1,2,4有用 i < intervals.size() && 各階段判斷 => 最終也只跑了一圈loop
        //這種簡單易懂的也是值得學習
    }
}
