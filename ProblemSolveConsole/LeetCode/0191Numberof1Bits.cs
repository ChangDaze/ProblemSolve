using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0191Numberof1Bits
    {
        public int HammingWeight(int n)
        {
            string binaryString = Convert.ToString(n, 2);
            return binaryString.Where(x => x == 49).Count(); //char 1 對應 int 49

            #region reference 1
            //int ones = 0;
            //while (n != 0)
            //{
            //    ones = ones + (n & 1);
            //    n = n >> 1;
            //}
            //return ones;
            #endregion
        }

        //我寫的是最單純用API的暴力解，可想而知比較慢，但很易懂
        //1. https://leetcode.com/problems/number-of-1-bits/solutions/55099/simple-java-solution-bit-shifting-by-fab-xyui/
        //這位是標準的shift + & 作法，用>>>只是為了正負號是JAVA語法，不過題目都要求正整數>>應該沒關係
        //2. https://leetcode.com/problems/number-of-1-bits/solutions/55255/c-solution-n-n-1-by-housed-bxce/
        //這位也很有趣，就用二進位慢慢檢查下去每一位數XD，是單純 & 作法
    }
}
