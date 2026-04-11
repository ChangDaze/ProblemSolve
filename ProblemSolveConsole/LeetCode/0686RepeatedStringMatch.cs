using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
#if false //一般解法
    public class _0686RepeatedStringMatch
    {
        public int RepeatedStringMatch(string a, string b)
        {
            // time : O(a(a+b))
            // space : O(a+b)

            StringBuilder sb = new StringBuilder();
            int count = 0;

            while(sb.Length < b.Length) //可同時判斷空字串
            {
                sb.Append(a);
                count++;
            }

            if(sb.ToString().Contains(b)) return count;

            sb.Append(a);//因為會有可能起始的邊界不同 ex: abcd vs cdabcdab  => abcdabcd false abcdabcdabcd true
            //ex: 長度雖是2但是位置是0.5 ~ 2.5(起始點會是0~1 => 所以結束點會是 2 ~ 3)所以要組成3才能完全contain，數字類比index
            count++;
            if (sb.ToString().Contains(b)) return count;
            //所以len會是(b <= x < b+2a) 間，contain一般可能是暴力比對，所以a越長最大比對的次數就可能會越多，此時總長度如果很長就可能比得很慢
            //但在字串短時kmp做出lps的成本就很高，維護難度也會提升超多，長度不夠一般也不會特別選KMP
            //可以看出這個解法時間百分比其實沒有很低

            return -1;
        }
    }
#endif

    #if true //kmp解法
    public class _0686RepeatedStringMatch
    {
        public int RepeatedStringMatch(string a, string b)
        {
            // time : O(a+b)
            // space : O(a+b)
            int n = a.Length; //a主串 text => 找人的地圖
            int m = b.Length; //b模式串 pattern => 要找的人

            int[] lps = ComputeLPS(b); //longest prefix suffix 最長前後綴 陣列

            // i 是主串 (a) 的虛擬指標，j 是模式串 (b) 的指標
            int i = 0;
            int j = 0;

            // 搜尋的上限：最多只需要檢查到 (a + b) 的長度 => 因為 b 起始點也一定是在第一個 a 裡面，所以長度頂多+a (跟一般方法比著眼不同，這是從b看，上面方法是從a看)
            while ( i < n + m)
            {
                //a[i%n] 用環狀循環 a 就不用組字串了 => 要記起來
                if (a[i%n] == b[j])
                {
                    i++;
                    j++;
                }

                if( j == m)
                {
                    // 成功找到完整的 b！
                    // 計算使用了幾個 a：總長度 i 除以 a 的長度，[無條件進位]，因為每次都是加上完整a
                    return (int)Math.Ceiling((double)i/n);
                }
                else if ( i < n + m && //還有後續
                    a[i%n] != b[j] //且不MATCH 才開始跳躍
                )
                {
                    if( j != 0)
                    {
                        // 利用 LPS 連環跳，j 不回頭，直接跳到上一個可能的位置
                        j = lps[j - 1];
                    }
                    else
                    {
                        // 如果 j 已經退到 0 了還是不配，i 就繼續往前了
                        i++;
                    }
                }
            }

            return -1;
        }
        /*
        找lps 和 主串模式串比對的方式很像
        AI說的
        這正是 KMP 演算法最美、也最神妙的地方：「計算 LPS 的過程，其實就是模式串『自己對準自己』的搜尋過程。」
        你可以把這兩件事看成是一模一樣的邏輯，只是「主串」換了人
        動作,主串 (Text),模式串 (Pattern)
        一般的 KMP 搜尋,外部的大字串 A,模式串 B
        計算 LPS 陣列,模式串 B 本身,模式串 B 本身 (移位後)
        */

        private int[] ComputeLPS(string b)
        {
            int m = b.Length;
            int[] lps = new int[m];
            int len = 0; //會受lps狀態影響， 前綴指標 ， 當前比對出的長前後綴長度
            int i = 1; // 在len狀態穩定下只會往前 ， 後綴指標 ， i 從 1 開始比對，避免自己跟自己比 (i==len)

            /*
             i = 4 的狀況
索引:  0  1  2  3  3  3  3  3 
字元:  A  B  A  B  B  B  B  B
         ↑     ↑
         len   i
         (前綴) (後綴)                         
             */


            while (i < m)
            {
                if (b[i] == b[len])
                {
                    len++; //先+再紀錄
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if(len != 0) //透過lps變動狀態 重新比對
                    {
                        //嘗試找「曾經最長前後綴的最長前後綴」
                        len = lps[len - 1];
                    } else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }                
            }

            return lps;
        }
    }

    /*
索引,子字串,LPS值 = 最長相等前後綴長度, 最長相等前後綴
0,A,0,無
1,AB,0,無
2,ABA,1,A
3,ABAB,2,AB
4,ABABA,3,ABA
5,ABABAB,4,ABAB

lps [0,0,1,2,3,4]

ex:
ABA 
前綴： 從第一個字開始，但不包含最後一個字的子字串。
prefix : A, AB
後綴： 從最後一個字開始往前，但不包含第一個字的子字串。
suffix : A, BA

假設 6 是 ABABABC
i = 6
len = 5
lps不match 他就會找到lps[len-1] = 3 (曾經最長前後綴的最長前後綴)(ABA) 繼續比

    原本比的
    ABABABC
      ABABABC => 不match
          ABA => len = lps[len-1] = 3 繼續比 不match
            A => len = lps[len-1] = 1 繼續比
      ...
            => 比到都不match len = 0, i 才繼續往前
    =>lps拿來比對很像尺子往右滑動

    => 中間過程少去比對次數的prefix就是相比於暴力法省去的時間(狀態的變化)
    => 這是算lps狀態的部分，拿lps跟主串比相比於暴力法還有比對時永不回頭的優勢
    ex:
    暴力法： 當你在第 12 個字元失敗時，主串的指標 $i$ 會從第 12 位退回到第 2 位，重新開始。這叫「回頭」。
    KMP： 主串的指標 $i$ 永遠停在第 12 位。它只會在那裡等模式串（尺）跳過來對齊。因為 $i$ 不回頭，所以主串的每個字元「最多只會被成功比對一次」。
    
    暴力解,每次失敗都重來，總共約 12×12=144 次。,乘法級別 (O(N⋅M))
    KMP,雖然 j 在跳，但主串指標 只走過一次，總共約 12+12=24 次。,加法級別 (O(N+M)) => 其實也是lps不會出現 [10,10,10]這種情況通常是[1,2,3]所以主串指標不回頭下頂多多lps長度次數的比對

    所以就算是 AAAAB VS AAAAC KMP也是加法級別，而且相比暴力解表現會是超級突出 (暴力解的worst case就是這個)
    */
#endif

    //好像還有個Rabin-Karp解法，等腦細胞回復以後再來看...
    //https://leetcode.com/problems/repeated-string-match/solutions/2303190/c-3-approaches-brute-force-rabin-karp-km-rk57/
}
