using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1979FindGreatestCommonDivisorofArray
    {
        public int FindGCD(int[] nums)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach(int num in nums)
            {
                //因為可能每個num都一樣大，所以min max比較都要完整做完
                if (num < min)
                {
                    min = num;
                }

                if (num > max)
                {
                    max = num;
                }
            }

            return GCD(min, max);

            int GCD(int a, int b)
            {
                //輾轉相除法，兩個整數的最大公因數等於其中較小的數和兩數相除餘數的最大公因數
                //不會證明，但會用就好
                //https://zh.wikipedia.org/zh-tw/%E6%9C%80%E5%A4%A7%E5%85%AC%E5%9B%A0%E6%95%B8
                //https://zh.wikipedia.org/wiki/%E8%BC%BE%E8%BD%89%E7%9B%B8%E9%99%A4%E6%B3%95
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }

                return a;
            }
        }

        //其他人方法差不多，就是gcd也能用遞迴的
        //https://leetcode.com/problems/find-greatest-common-divisor-of-array/solutions/1419750/java-c-solution-using-euclidean-algorithm/
    }
}
