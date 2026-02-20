using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0263UglyNumber
    {
        public bool IsUgly(int n)
        {
            //Time complexity:O(logn)
            //Space complexity:O(1)O(1)
            if (n == 0) return false;//題目會出0，防呆，沒防會無限執行，然後0不算正整數

            //醜數 Ugly Number: 正整數，質因數只有2,3,5 An ugly number is a positive integer which does not have a prime factor other than 2, 3, and 5.
            //只是用作因數分解練習和概念，醜數本身是設計出來的
            int[] primes = { 2, 3, 5 };

            foreach (int i in primes)//prime factor質因數
            {
                while (n % i == 0)//代表可整除
                {
                    n /= i; //可能不會是1，但while會繼續判斷同個數可否能除，除到剩1，或其他prime是否為因數
                }
            }

            return n == 1;
        }
    }

    //https://leetcode.com/problems/ugly-number/solutions/69214/2-4-lines-every-language-by-stefanpochma-zk0d/
    //這位方法跟我一樣
    //https://leetcode.com/problems/ugly-number/solutions/6634497/master-the-prime-factor-shortcut-intervi-fgxq/
    //這位也一樣

    //看來大家方法都一樣
}
