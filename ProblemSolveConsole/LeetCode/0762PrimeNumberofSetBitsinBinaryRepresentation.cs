using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0762PrimeNumberofSetBitsinBinaryRepresentation
    {
        public int CountPrimeSetBits(int left, int right)
        {
            //time : O(M * (log N +sqrt(logN))) => m是left ~ right，log N是找bitsCount，sqrt(logN)是用bitsCount找prime
            //space : O(1);
            int result = 0;
            for (int i = left; i <= right; i++) 
            {
                int temp = i;
                int bitsCount = 0;
                //int bitsCount = System.Numerics.BitOperations.PopCount((uint)i); => C#好像跟C++一樣有內建了"硬體加速"的位元計算 XD，JAVA也有
                while (temp != 0) //題目只有正數，好像沒有sign問題
                {
                    if((temp & 1) == 1)
                    {
                        bitsCount++;
                    }
                    temp >>= 1;
                }

                if (IsPrime(bitsCount))
                {
                    result++;
                }
            }

            return result;
        }

        //質數的定義是：「一個大於 1 的正整數，且只有 1 和它自己兩個正因數。」
        //C# 沒有內建 IsPrime XD
        private bool IsPrime(int n) //bitsCount 最大不超過 20（32 位元下最大也才 32），我們可以直接把 32 以內的質數寫成一個 HashSet 或 常數陣列 XD，變成O(1)
        {
            //time:O(sqrt(n))
            if (n <= 1)
            {
                return false;
            }

            if(n == 2) //2是唯一的偶數質數
            {
                return true;
            }

            for(int i = 2; i * i <= n; i++) //檢查到平方根即可，要注意是<=
            {
                if(n%i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/solutions/113232/665772-by-stefanpochmann-sli1/
        //這位用了兩個地方的bit manipulation，然後程式碼都很精簡
        //1.算bit
        //2.用19個bit代替自建hashset放入20以下的常數，1100 => 3 true、2 true、1 false、0 false => index  + shift對應true false
        //第一位留言的講的比較詳細
        //https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/solutions/113227/javac-clean-code-by-alexander-b156/
        //這位解法跟我一樣，不過他有注意到自建hashset
        //https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/solutions/127421/prime-number-of-set-bits-in-binary-repre-j9fn/
        //官方解法只有一個跟大家一樣的標準解法XD => 看來是要背起來
    }
}
