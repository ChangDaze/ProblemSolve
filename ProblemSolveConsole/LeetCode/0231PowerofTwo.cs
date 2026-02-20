using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0231PowerofTwo
    {
        public bool IsPowerOfTwo(int n)
        {
            //Time complexity:O(logn) => n就看他指數的層級
            //Space complexity:O(1)
            if (n == 0 || n < 0) return false; //2的指數不會有負數也不會有0

            while (n % 2 == 0)
            {
                n/=2;
            }

            return n == 1;//直接用n是否由2相乘組成來判斷
        }
    }

    //https://leetcode.com/problems/power-of-two/solutions/1638707/pythoncjava-detailly-explain-why-n-n-1-w-mpon/
    //這個是標準解法 => 要記住
    //簡單講就是
    //1.2的指數會有個特性，就是整個bit只會有一個1 => 要記住
    //2.n如果是2的指數時，n-1其實就是n那個bit以前的bits全部都是1，所以n&n-1 == 0 => 要記住
    //3.其他如果n不是2的指數時，n&n-1基本上最左邊的bit都會是1，因為都是base on 小一階的n的指數上 => 要記住
    //https://leetcode.com/problems/power-of-two/solutions/1638704/c-easy-to-solve-all-interview-approaches-pm66/
    //這個應該就包含大部分解法了
    //1.跟我的解法相同
    //2.法一的遞迴版本
    //3.標準解法
    //4.log2的解法，因為log2會有小數，所以只有剛好算出整數時ceil和floor會得出相同結果 => math
    //5. C++提供的語法糖__builtin_popcount(n)可以算bits中有幾個1
    //6.很有趣的解法，就是抓出限制中最大的2的指數，其他2的指數因為因數完全一樣，所以理論上才能整除他 XD
}
