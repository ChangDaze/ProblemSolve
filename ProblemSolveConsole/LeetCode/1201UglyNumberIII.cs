using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1201UglyNumberIII
    {
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            //這題標準跟0264UglyNumberII有點不同，只要是 a, b, c任一的倍數都算不用a&b&c
            //time : O(log(high) * log(max(a, b, c))) => log(high) for binary search、log(max(a, b, c))) for 3個數字LCM輾轉相除法中取複雜度最高的代表
            //space : O(1)
            long low = 1;
            long high = long.MaxValue;
            long ans = high;
            while (low <= high)
            {
                long mid = low + (high - low) /2;
                //這邊直接用n/x算有多少符合條件 ex: 10 / 2 => 代表1~10有5個2的倍數，再用排融原理+最小公倍數去掉重複算的部分
                //當算出有滿足n的UglyNumber數量就滿足答案 => 用binary search加速、因為>=+ (high = mid - 1)的關係，最後會low > high但mid應該會相等ans，會一直search到最小符合n的那個數字 = 第n個UglyNumber
                if (Count(mid, a, b, c) >= n)
                {
                    ans = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return (int)ans;
        }

        //排融原理 A + B + C - (A&B + B&C + A&C) + A&B&C
        private long Count(long n,long a, long b, long c)
        {
            return (n / a + n / b + n / c)
                - (n / GetLCM(a, b) + n / GetLCM(b, c) + n / GetLCM(a, c))
                + (n / GetLCM(GetLCM(a, b), c));
        }

        //Greatest Common Divisor 最大公因數
        /*
        這段是輾轉相除法
        輾轉相除法的核心在於一個數學性質：兩個正整數 a 與 b 的最大公因數，等於 b 與「a mod b」的最大公因數。
        => gcd(a, b) = gcd(b, a mod b)
        成立證明: 
        假設 d 是 a 和 b 的公因數，a = md ; b = nd，
        a = qb + r（其中 r 是餘數，q 是商數）移項 => r = a - qb = md - q(nd) = (m - qn)d
        這說明了 d 同時也是餘數 r 的因數。
        因此，a 和 b 的所有公因數，同時也是 b 和 r 的公因數。既然公因數集合完全一樣，那「最大」的那個自然也一樣。
        */
        private long GetGCD(long a, long b)
        {
            while(b!=0)
            {
                a %= b;
                (a, b) = (b, a);//swap 讓大的值變被除數 => 讓gcd(b, a mod b)輾轉走下去
            }
            return a;
        }

        //least common multiple 最小公倍數
        private long GetLCM(long a, long b)
        {
            return (a / GetGCD(a, b)) * b; //最小公倍數 = 最大公因數 * a特有因數 * b特有因數 
        }
    }

    //公因數因為固定所以理論上要放記憶體耶，我每次好像重算 => 所以可能因此才比別人慢耶
    //https://leetcode.com/problems/ugly-number-iii/solutions/387539/cpp-binary-search-with-picture-binary-se-1up8/?submissionId=1919182022
    //這位方法就一樣是標準解法，不過他就更精簡+有用記憶體紀錄，不像我多做了一堆獨立function => 值得參考
    //https://leetcode.com/problems/ugly-number-iii/solutions/387780/javac-binary-search-with-venn-diagram-ex-pmdv/?submissionId=1919182022
    //這位方法一樣是標準解法，不過跟我的接近完全一樣，另外他只用int理論上也會更快
    //看來這題大家也是多用標準解法
}
