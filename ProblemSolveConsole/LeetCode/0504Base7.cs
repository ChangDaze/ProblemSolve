using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0504Base7
    {
        public string ConvertToBase7(int num)
        {
            //Time complexity:O(logn) => ex: log (base 7 ) n，除法是log級遞增
            //Space complexity:O(logn)
            if (num == 0) return "0";

            int baseNum = 7;
            LinkedList<char> list = new LinkedList<char>();
            int value = Math.Abs(num);//要取ABS不然取榆樹會有負數+'0'就會不準
            while (value != 0)
            {
                list.AddFirst((char)((value % baseNum) + '0'));
                value /= baseNum;
            }

            if(num < 0)
            {
                list.AddFirst('-');
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in list)
            {
                sb.Append(c);
            }            
            return sb.ToString();
        }

        //https://leetcode.com/problems/base-7/solutions/98364/javacpython-iteration-and-recursion-by-l-l6ji/
        //這位作法原理一樣，不過他規劃recursive的方法要記住 => 分割擊破，高位digit交給下一層擊破
        //最高層判斷負號 => if (n < 0) return "-" + convertToBase7(-n); => 用value去走下面幾層
        //第二層判斷附加位 => to_string(n % 7)
        //後續到最末層判斷 => convertToBase7(n / 7) ; if (n < 7) return to_string(n);
        //https://leetcode.com/problems/base-7/solutions/98363/verbose-java-solution-by-shawngao-kvf9/
        //這方法跟我完全一樣，不過JAVA stringbuilder可以reverse，C#好像沒有，所以我用linkedlist替代

        //意外的大家沒有特別處理string耗損 =>
        //不過仔細想想也是，因為是log級遞減，所以在限制內的字串長度一定都超短，所以像我創建stringbuilder和linkedlist的資源成本可能就超過他們單純用短string+短string的成本了XD
    }
}
