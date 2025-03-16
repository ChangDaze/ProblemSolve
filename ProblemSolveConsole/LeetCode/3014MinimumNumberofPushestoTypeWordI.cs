using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3014MinimumNumberofPushestoTypeWordI
    {
        //public int MinimumPushes(string word)
        //{
        //    //因為9宮格按鈕位置好像沒有實質意義，所以都當作每個按鈕等價，然後有8個可用
        //    Dictionary<char, int> map = new Dictionary<char, int>();
        //    //O(n)
        //    for(int i = 0; i < word.Length; i++)
        //    {
        //        if (map.ContainsKey(word[i]))
        //        {
        //            map[word[i]]++;
        //        }else
        //        {
        //            map[word[i]] = 1;
        //        }
        //    }

        //    //由最多次的單字開始計算
        //    //O(nlogn)
        //    var sortedByValue = map.OrderByDescending(kvp => kvp.Value).ToList();

        //    int result = 0;
        //    int pushFactor = 1;
        //    int count = 0;
        //    foreach (var kvp in sortedByValue)
        //    {                
        //        count++;

        //        result+= kvp.Value * pushFactor;

        //        if(count >= 8) //只有8個鈕能用
        //        {
        //            pushFactor++;
        //            count = 0;
        //        }
        //    }

        //    return result;
        //}
        public int MinimumPushes(string word)
        {
            int result = 0;
            int pushFactor = 1;
            int count = 0;
            foreach (char c in word)
            {
                count++;

                result += pushFactor;

                if (count >= 8) //只有8個鈕能用
                {
                    pushFactor++;
                    count = 0;
                }
            }

            return result;
        }

        //我沒注意到題目的要求，並不會出現重複的單字，所以可以省去排序的動作，也無用記錄出現次數， 應該能再快
        //1 <= word.length <= 26
        //word consists of lowercase English letters.
        //All letters in word are distinct.
        //其實大家寫法差不多就是對8個鈕處理，這位是算除數和餘數，對長度很長的word這個統一處理方法可能真的比較好
        //https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i/solutions/4600908/the-best-explanation-beats-100-users/
        //這位就對最長為26的word做了寫死處理
        //https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i/solutions/4600677/o-1-one-liner/
    }
}
