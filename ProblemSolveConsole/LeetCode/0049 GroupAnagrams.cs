using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0049_GroupAnagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //最簡單的map + sort暴力解而已
            //time O(n · k log k) => k log k是OrderBy
            //space O(n · k)
            Dictionary<string, List<string>> maps = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                string key = string.Join("", str.ToList().OrderBy(x => x));
                if (maps.ContainsKey(key))
                {
                    maps[key].Add(str);
                }
                else
                {
                    maps[key] = new List<string>() { str};
                }
            }

            return maps.Values.Select(x => (IList<string>)new List<string>(x)).ToList(); //(IList<string>)沒做upcast(向上轉型，零成本，且參考一致，更多是單純告訴編譯器這裡是用甚麼而已)會吃不下去
        }

        //https://leetcode.com/problems/group-anagrams/solutions/19176/share-my-short-java-solution-by-legendar-0yrd/
        //這個人方法一樣，不過他的方法二是自己用26字母array令建key(這裡單純用int[]應該也可)，就能不sort，會把O(k log k)濃縮成O(k)，理論上在字串越長就越有效率 => 這種應該要能馬上想到@@

    }
}
