using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1009ComplementofBase10Integer
    {
        public int BitwiseComplement(int n)
        {
            //Time complexity:O(log(n)) => log2 往下降
            //Space complexity:O(1)
            if (n == 0) return 1; //edge case

            //製作mask
            int temp = n;
            int mask = 1; //mask 最初比 n 多一bit ex: n = 101 (bit), mask 最終等於 1000(bit) - 1 = 111(bit)
            while (temp != 0)
            {
                temp >>= 1;
                mask <<= 1;
            }
            mask -= 1;

            return mask ^ n; //xor 就是補數，雖然bit xor 但value 還是 int 所以不用特別轉換
        }

        //https://leetcode.com/problems/complement-of-base-10-integer/solutions/3544067/solution-by-deleted_user-b37f/
        //這個方法也是做mask，不過跟我有點差異，他得比較直接做出1111bit mask，是個很好的參考
        //https://leetcode.com/problems/complement-of-base-10-integer/solutions/256740/javacpython-find-1111111-n-by-lee215-vgm0/
        //這位方法跟第一位一樣，不過沒用shift用*2
        //上面兩位的方法可以不用特別處理if(num == 0) return 1;，值得記住
        //大家大差不差都用bit masking，雖然approach有所差異但因為是log(n)所以核心概念和速度理論不會差太多
    }
}
