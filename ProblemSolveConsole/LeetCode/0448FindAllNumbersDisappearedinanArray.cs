using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0448FindAllNumbersDisappearedinanArray
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();

            for(int i = 1; i <= nums.Length; i++)
            {
                result.Add(i);
            }

            for(int i = 0; i < nums.Length; i++)
            {
                result.Remove(nums[i]); //hashset和dictionary remove不會跳error
            }

            return result.ToList();
        }

        //因為return list長度不定，所以就簡單用hashset解沒特別多想
        //https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/solutions/1583736/cpython-all-6-solutions-w-explanations-b-4858/
        //此人提供多個方法值得一看
        //法二: 滿有趣的 sort + binary search * n (1~n都搜尋一次)，可以當作一個開胃菜解題方法
        //法三: 跟我一樣
        //法四: 跟法三一樣，他優化了一點space，但我覺得沒特別必要
        //法五: 很有趣，是inplace swap(value移到對應index位置) + index用法，本質是O(2n)+result space(其實應該也是O(n))，但雖然純樸但說不定比hashset還快
        //法六: 是法五的另一種變話而已，把swap換成用sing來mark(可參考_0645SetMismatch inplace mark)，但這樣每次取值都要abs，本質上應該是會有些壞處
    }
}
