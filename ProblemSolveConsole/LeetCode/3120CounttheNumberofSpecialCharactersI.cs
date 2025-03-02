using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3120CounttheNumberofSpecialCharactersI
    {
        public int NumberOfSpecialChars(string word)
        {
            //65 : A 、 97 : a， diff gap 32
            //直接用ascii的int來用
            HashSet<int> record = new HashSet<int>();
            HashSet<int> specials = new HashSet<int>(); //只存小寫

            foreach (char c in word)
            {
                int check; //檢查special用的值
                int target; //存special用的值
                if (c >= 97)
                {
                    check = c - 32;
                    target = c - 32;
                }
                else
                {
                    check = c + 32;
                    target = c;
                }


                if (specials.Contains(target))//use map 1
                {
                    continue;
                }
                else if(record.Contains(check))//use map 2
                {
                    specials.Add(target);//use map 3
                }

                //每個用過的character都要記錄
                record.Add(c);//use map 4
            }

            return specials.Count;
        }

        //大家的方法其實差不多，不過我用hashset成本(搜尋、建立時)可能比array大，另外就是我其實檢查map的次數不少
        //https://leetcode.com/problems/count-the-number-of-special-characters-i/solutions/5052483/c-bit-manipulation-o-1-space/
        //https://leetcode.com/problems/count-the-number-of-special-characters-i/solutions/5052481/simple-java-solution/
    }
}
