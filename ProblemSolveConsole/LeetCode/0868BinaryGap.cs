using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0868BinaryGap
    {
        public int BinaryGap(int n)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            int max = 0;
            int pointer = -1;
            int previousBit = int.MaxValue;

            //判斷每個bit是否為1，使用right shift推進
            while (n != 0)
            {
                pointer++;
                if( (n&1) == 1)//檢查到此bit是1
                {
                    int gap = pointer - previousBit;//檢查距離
                    if(gap > max)//更新最遠距離
                    {
                        max = gap;
                    }
                    previousBit = pointer;//更新前次位置的紀錄
                }
                n >>= 1;
            }

            return max;
        }

        //https://leetcode.com/problems/binary-gap/solutions/149835/cjavapython-dividing-by-2-by-lee215-wq4o/
        //這位方法原理其實跟我一樣，只是他表現出來不同
        //1.N % 2 == 1 => n&1
        //2.N /= 2 => n >>= 1
        //3.int d = -32;d++;d = 0 =>就是像previousBit的錨點而已
        //https://leetcode.com/problems/binary-gap/description/
        //這位方法其實跟第一位一樣，他有maxGap + 1是因為他的gap是用+1算的，不是用兩點相減算的
        //https://leetcode.com/problems/binary-gap/solutions/149820/binary-gap-by-leetcode-qn2i/
        //這方法其實跟我的方法一樣，不過它寫成一團我覺得會難看懂一點，比較意外的是他把bit shift看作O(logN) @@
    }
}
