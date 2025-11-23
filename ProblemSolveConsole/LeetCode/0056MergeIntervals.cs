using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0056MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            //time : sort : O(nlogn), Insert() and RemoveAt() 都是 O(n) => O(n^2) => 因為 List<T> 是 array-based，需要搬移元素。 看來直接用list做大量物件操作不是好選擇，用個index或hash紀錄位置應該能簡單處理好
            //space: O(n)

            List<int[]> result = intervals.OrderBy(x => x[0]).ToList();

            for(int i = 1; i<result.Count; i++)
            {
                if(result[i][0] <= result[i - 1][1])
                {
                    int[] insert = new int[2];
                    insert[0] = result[i-1][0]; //有sort過
                    insert[1] = result[i - 1][1] < result[i][1] ? result[i][1] : result[i - 1][1]; //有可能前[1]比後[1]大
                    result.Insert(i, insert);
                    result.RemoveAt(i+1);
                    result.RemoveAt(i-1);
                    i--; //融合後要追隨目前位置
                }
            }

            return result.ToArray();
        }
        //https://leetcode.com/problems/merge-intervals/solutions/21222/a-simple-java-solution-by-brubru777-83sh/
        //這個人解法很乾淨俐落，可以學學
        //1.int[][]應該也能用Array sort
        //2.他的List<int[]> result不使用Insert()和RemoveAt()，是比較完後直接修改newInterval，如果不必修改了就換下個newInterval，因為物件特性，所以newInterval修改也會更新result中的上下限
        //3.最後把result(為了add用list)轉回array
        //https://leetcode.com/problems/merge-intervals/solutions/5513226/video-sorting-solution-by-niits-8ea5/
        //這個人方法跟第一位一樣
        //如果我的方法改用index或hash，最後整理要再loop一遍整理，應該還是可行，指示操作變兩階段
    }
}
