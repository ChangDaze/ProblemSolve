using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3129FindAllPossibleStableBinaryArraysI
    {
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            //題目描述有點難懂，看題目範例會理解快一點
            //1.The number of occurrences of 0 in arr is exactly zero. => 0要出現達到變數zero value的次數
            //2.The number of occurrences of 1 in arr is exactly one. => 1要出現達到變數one value的次數
            //3.Each subarray of arr with a size greater than limit must contain both 0 and 1.
            //  => 這最難懂，先反著看，subarray 在 limit 長度以下 才能 有連續的1或0 => 所以limit = 2
            //  => 可以出現 00、11、0010 ， 但是 000 就不行
            //  => 白話文講就是可以連續出現的相同bit長度

            //1+2下array長度=zero+one
            //3可以看出limit可以小於zero或one

            int mod = 1000000007;

            long[][][] dp = new long[zero + 1][][];
            //long[zero + 1][one + 1][2];
            //index[x][][] 0 ~ zero
            //index[][x][] 0 ~ one 
            //index[][][x] 最後是 append 0 還是 1
            //ex : bp[i][j][0] => 最後是0的情況下有i個0,j個1的所有組合

            for (int i = 0; i <= zero; i++)
            {
                dp[i] = new long[one + 1][];
                for(int j = 0; j <= one; j++)
                {
                    dp[i][j] = new long[2];
                }
            }

            //設立起始點，才能讓dp轉動
            //ex:["1"][0]["0"] = 1 ,zero = 2 還沒滿足條件時只有1個可能繼續加zero
            //在計算上(最後的for邏輯) [A][B][] => A和B是線性獨立的(大概是)
            //[x][1][] 不會影響 [x][2][] 的所有計算 x for {1 ~ zero}
            // ex: [1][1][]、[2][1][]、[3][1][]在計算時只會用到[x][1][]的值(參照68和81行)
            //所以起始點像下面這樣設定是對的， zero = 2不會有 [1][1][0]  = [0][1][1] + [1][0][0] = 2的可能
            for (int i = 1; i <= Math.Min(zero, limit); i++)
            {
                dp[i][0][0] = 1;
            }

            for (int j = 1; j <= Math.Min(one, limit); j++)
            {
                dp[0][j][1] = 1;
            }

            //都未從1開始 因 1 <= zero, one
            for (int z = 1; z <= zero; z++)
            {
                for (int o = 1; o <= one; o++)
                {
                    //處理結尾是0

                    //ex:[2][1][0] => 2個0、1個1、結尾是0的情況如何發生?
                    //[1][1][0] 、 [1][1][1] => 少一1個0就能滿足的情況
                    dp[z][o][0] = (dp[z-1][o][0] + dp[z - 1][o][1] + mod) % mod;

                    //參照 However, if this creates more than limit consecutive zeros, those invalid cases are removed.
                    //判斷的方式有點抽象
                    //ex: [3][2][0] limit 1
                    //[3][2][0] - [1][2][1]
                    //1.為甚麼 - [1][2][1]就可以? 因為[1][2][1]到[3][2][0]只能add zero(add時沒有其他可能)所以[1][2][1]的組合次數等於這條路的全部次數
                    //2.目的是扣除當結尾0時剛好超過limit限制的情況
                    //3.因為DP過程都處理了limit，所以最後結果會全部符合limit限制

                    //用z>=limit+1比較清楚，代表dp[z][o][0]結尾是0的組合可能出現limit+1的情況了
                    if (z-limit-1 >= 0)
                    {
                        dp[z][o][0] = (dp[z][o][0] - dp[z - limit - 1][o][1] + mod) % mod;
                    }

                    //處理結尾是1，處理概念跟處理結尾是0一樣
                    dp[z][o][1] = (dp[z][o-1][0] + dp[z][o-1][1]) % mod;

                    if (o - limit - 1 >= 0)
                    {
                        dp[z][o][1] = (dp[z][o][1] - dp[z][o - limit - 1][0] + mod) % mod;
                    }
                }
            }

            //(x + mod) % mod
            //1.是怕long變int溢位
            //2.如果兩兩相加有可能long溢位
            //3.中間有相減的操作，沒+mod可能正的變負的
            //因此其實每次在計算都用(x + mod) % mod比較保險
            return (int)((dp[zero][one][0] + dp[zero][one][1] + mod) % mod);
        }

        //下次有機會再看看其他幾位的解法
        //主要抄這位的
        //https://leetcode.com/problems/find-all-possible-stable-binary-arrays-i/solutions/7635866/dynamic-programming-approach-to-count-st-wkw9/?envType=daily-question&envId=2026-03-09
    }
}
