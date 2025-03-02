using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3184CountPairsThatFormaCompleteDayI
    {
        #region 暴力解
        //public int CountCompleteDayPairs(int[] hours)
        //{

        //    int result = 0;
        //    int[] remainders = new int[hours.Length];

        //    for (int i = 0; i < hours.Length; i++)
        //    {
        //        remainders[i] = hours[i] % 24;
        //    }

        //    for (int i = 0; i < remainders.Length; i++)
        //    {
        //        for (int j = i + 1; j < remainders.Length; j++)
        //        {
        //            //hours題目有預設 > 0，所以相加一定 > 0，下面的判斷一定是24的倍數
        //            if (remainders[i] + remainders[j] == 24 ||
        //                remainders[i] + remainders[j] == 0)
        //            {
        //                result++;
        //            }
        //        }
        //    }

        //    return result;
        //}
        #endregion

        public int CountCompleteDayPairs(int[] hours)
        {

            Dictionary<int , int> record = new Dictionary<int , int>();
            int result = 0;

            for(int i = hours.Length - 1 ; i >= 0  ; i--)
            {
                int remainder = hours[i] % 24;
                //要注意除0和 24 vs 0 的問題
                if(record.TryGetValue(remainder == 0 ? 0 : 24 - remainder,out int count))
                {
                    result += count;
                }

                //事後紀錄已經過的餘數
                if (record.ContainsKey(remainder))
                {
                    record[remainder]++;
                }
                else
                {
                    record[remainder]=1;
                }
            }

            return result;
        }

        //這個hashmap的概念就是把i < j的概念倒過來看，不是往後看有那些符合，是往前看有哪些符合，用 j > i 來看，結論會一樣，這概念要學起來，用單純的backforward也能表現出 i < j
        //https://leetcode.com/problems/count-pairs-that-form-a-complete-day-i/solutions/5319834/brute-force-vs-hashmap-approach-detailed-explanation/
    }
}
