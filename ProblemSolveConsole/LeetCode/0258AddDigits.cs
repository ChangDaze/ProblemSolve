using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0258AddDigits
    {
        public int AddDigits(int num)
        {

            #region 暴力解
            int current = num;
            while (current >= 10)
            {
                int temp = current;
                int tempCurrent = 0;
                while (temp > 0)
                {
                    tempCurrent += temp % 10;
                    temp /= 10;
                }
                current = tempCurrent;
            }
            return current;
            #endregion
            #region 數根
            //if (num == 0) return 0;
            //else if (num % 9 == 0) return 9;
            //else return num % 9;
            #endregion


        }

        //用數學特性解可以超快，這裡就是可以用數根特性
        //數根說明
        //https://zh.wikipedia.org/zh-tw/%E6%95%B8%E6%A0%B9
        //數根說明2
        //https://ithelp.ithome.com.tw/m/articles/10238613
        //數根解法
        //https://leetcode.com/problems/add-digits/solutions/1754040/c-recursion-and-iteration-and-o-1-approaches-fast-solutions/

    }
}
