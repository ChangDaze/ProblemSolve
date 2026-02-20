using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0342PowerofFour
    {
        public bool IsPowerOfFour(int n)
        {
            //Time complexity:O(logn)
            //Space complexity:O(1)
            if (n <= 0) return false; //要小心0會造成無限迴圈

            while(n%4 == 0)
            {
                n /= 4;
            }

            return n == 1;
        }
    }

    //用跟0231PowerofTwo一樣解法，但不知道怎麼用bit-manipulation
    /*
    在十六進位中，5 代表的是二進位的 0101。 => 8(個5)*4=32
    所以，0x55555555 展開成 32 位元後會長這樣：
    01010101 01010101 01010101 01010101
    這是一個非常有規律的數組，也就是**「奇數位全是 1，偶數位全是 0」**（從右邊第 0 位開始數）。
    */
    //4個指數都是在奇數bit => 要記住

    //https://leetcode.com/problems/power-of-four/solutions/80457/java-1-line-cheating-for-the-purpose-of-5l4kb/
    //這位是延伸0231PowerofTwo的bit-manipulation，加上偶數bit mask 0x55555555 => 要記住
    //https://leetcode.com/problems/power-of-four/solutions/80460/1-line-c-solution-without-confusing-bit-qqfjw/
    //這位是用Math的同餘理論作收斂，(num - 1) % 3 == 0 => 同餘理論就是 4 mod 3 餘數 1，4^n mod 3 餘數 1^n => 1^n = 1 所以可以得到bool判斷式 (細節可能要看數學，不用同餘理論，用歸納法應該也可以，因為觀察出來確實也如此(num - 1) % 3 == 0)
    //https://leetcode.com/problems/power-of-four/solutions/772428/c-three-solution-explain-naive-bit-manip-z1cg/
    //這個蠻特別的，因為在int範圍內其實4的指數很少，所以她直接做map和equal比對
    //1. 主要的兩個condition (1)只能有一個bit是1(2)bit在奇數位置 => return no_of_one==1 && one_pos&1 ; => &&左邊是(1)右邊是抓到bit是1的index&1是(2)，因為所有奇數第一個bit都是1
    //2. 用 32 bit 和 i+=2直接用只能有一個bit是1和equal來比對 ， 或是直接做 map
    //3. 跟我方法一樣
}
