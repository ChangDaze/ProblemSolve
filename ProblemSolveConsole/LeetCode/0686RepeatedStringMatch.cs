using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0686RepeatedStringMatch
    {
        public int RepeatedStringMatch(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            while(sb.Length < b.Length) //可同時判斷空字串
            {
                sb.Append(a);
                count++;
            }

            if(sb.ToString().Contains(b)) return count;

            sb.Append(a);//因為會有可能起始的邊界不同 ex: abcd vs cdabcdab  => abcdabcd false abcdabcdabcd true
            //ex: 長度雖是2但是位置是0.5 ~ 2.5(起始點會是0~1 => 所以結束點會是 2 ~ 3)所以要組成3才能完全contain，數字類比index
            count++;
            if (sb.ToString().Contains(b)) return count;

            return -1;
        }
    }
}
