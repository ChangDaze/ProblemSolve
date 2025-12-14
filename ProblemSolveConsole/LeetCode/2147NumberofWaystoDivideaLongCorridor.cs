using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2147NumberofWaystoDivideaLongCorridor
    {
        public int NumberOfWays(string corridor)
        {
            int sCount = 0;
            Dictionary<int, int> sCountRecord = new Dictionary<int, int>(); //可以不用dictionary因為留下的也是index相關，用List<int> > index 代表sCount ，value 代表 對應index

            for (int i = 0; i < corridor.Length; i++)
            {
                if( corridor[i] == 'S')
                {
                    sCount++;
                    sCountRecord[sCount] = i;
                }
            }

            if(sCount == 0 || sCount % 2 != 0) //不符合題目
            {
                return 0;
            }

            long result = 1; //藥用LONG不然相乘可能溢位...

            while(sCount > 2) //其實for(i=2..i+=2)也可以，不用倒序也不用 sCount -= 2
            {
                result = (result * (sCountRecord[sCount - 1] - sCountRecord[sCount - 2]) ) % (1000000000+7) ; //注意off-by-one 錯誤，可以用簡單實例輔助 + 先乘後MOD，不然最後結果可能超過MOD導致跟答案不同
                sCount -= 2;
            }

            return (int)result;
        }

        //這題好像只是簡單的分析題目，dp的部分可能就是List<int>的抽象應用，其他就一般的組合相乘而已，好像也不至於hard
        //這題比較能特別的其實是頭尾不用特別處理就能自然結束(因為不能乘)
        //https://leetcode.com/problems/number-of-ways-to-divide-a-long-corridor/solutions/1709704/greedy-solution-c-by-invulnerable-eu3i/?envType=daily-question&envId=2025-12-14&page=3
        //這位就很正統的解法，概念有隱含在細節，因為沒註解所以要仔細看，但值得效仿
        //https://leetcode.com/problems/number-of-ways-to-divide-a-long-corridor/solutions/1709725/javacpython-two-solutions-with-explanati-qpnl/?envType=daily-question&envId=2025-12-14&page=3
        //這個人有點極致
        //法一: k % 2 == 1可以用現在位置去確定要計算，j = i每次=='S'會紀錄，所以上次k % 2 == 0其實就被記錄了所以可以拿來用
        //法二:b2 其實沒用到，可以忽略，這解法有點鬼(沒%也沒乘法)所以紀錄註解一下，但一般人應該根本想不到...，這是狀態機(a,b,c) + DP(複製)
        //abc一直在傳遞切法數量 => 狀態機
        //a 目前這個 segment 已經有 0 個 S ，目前前面傳遞的切法數量
        //b 目前這個 segment 已經有 1 個 S ，目前前面傳遞的切法數量
        //c 目前這個 segment 已經有 2 個 S ，目前前面傳遞到的切法數量
        /*
        public int numberOfWays(String s) {
            int a = 1, b = 0, b2 = 0, c = 0, mod = (int)1e9 + 7;
            for (int i = 0; i < s.length(); ++i)
                if (s.charAt(i) == 'S') {
                    a = (a + c) % mod; //剛遇到S時a最後再複製一次(應該等價於我們上面的+1)再丟給P
                    c = b; //當s = 1時 其實內容都是0
                    b = a; //當s = 1 時會存有前面傳遞的切法數量，當s=0,2時其實內容都是0
                    a = 0; //當s = 1時其實內容都是0
                } else {
                    a = (a + c) % mod;
                    //當s = 1時等於S和S之間的P，然後a和c都是0，切法數量存在b，所以計算無任何影像
                    //當s = 2時等於SS後的P，此時c存有切法數量，每遇到一個P，就會整份複製到a，多個P就會出現乘法效果 > 然後就進入 s = 0 的情境，a開始存有切法數量
                }
            return c;
        }
         */
        //太難懂，也不知道有沒有解析對，但應該是效能也很好，大概

    }
}
