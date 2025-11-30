using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0072EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            //要做DP表
            //ex:hor vs : ro dp[][] => 以下面為例 [0][1] 代表 "" -> "r"的step, [2][1] 代表 "ho" -> "r"
            //那step有的動作就是 delete insert replace
            //注意:這裡只比較 dp[][]中對應的最後字母，這樣才能錨定去參考前面的最短路徑
            //delete 參考 [i][j-1]  ex: [2][1] = [1][1] + 1 因為 "ho" + delete(word1) -> "r" 代表從 "ho" -> "r" to "h" -> "r"(參考他)
            //insert 參考 [i-1][j]  ex: [2][1] = [2][0] + 1 因為 "ho" + insert(word2) -> "r" 代表從 "ho" -> ""(參考他)  to "ho" -> "r"
            //replace 參考 [i-1][j-1] ex: [2][1] = [1][0] + 1 因為 "ho" + replace(word1 to word2) -> "r" 代表delete和insert都做, (參考)"h" -> ""
            //還有個隱藏選項，當最後字母相同時其實是參考 [i-1][j-1]但不做operation，ex: [2][1] = [1][0] + 0
            //      "", "r", "ro"
            //""     0   1    2
            //"h"    1
            //"ho"   2
            //"hor"  3
            //一開始給定的值都是固定確認的step

            //註:(1)如果有word3就可能變dp[][][]，如果有更多operation，(2)只要能定義出參考的位置其實就也能融入dp表規則中，雖然題目是設計好的，但自己歸納好規則，平常就可能使用出來
            //另外可以記住像word的dp小問題，大部分會是像更小部分的word1變word2的形式，這要記住
            //要注意因為多""比較的boundry，一直跳錯會有點尷尬

            int[][] dp = new int[word1.Length+1][];
            for(int i  = 0; i < dp.Length; i++)
            {
                dp[i] = new int[word2.Length + 1];
                dp[i][0] = i;
                if(i == 0)
                {
                    for(int j  = 0; j < dp[i].Length; j++)
                    {
                        dp[i][j] = j;
                    }
                }
            }

            for(int i = 1;  i < dp.Length; i++)
            {
                for(int j = 1;j < dp[i].Length; j++)
                {
                    //不用選找參考中最小就好
                    dp[i][j] = int.Min(
                        dp[i - 1][j] + 1, //delete
                        int.Min(
                            dp[i][j - 1] + 1, //insert
                            word1[i-1] == word2[j - 1] ? dp[i-1][j-1] : dp[i - 1][j - 1] + 1//replace/same
                        )
                    );
                }
            }

            return dp[word1.Length][word2.Length]; //有多一格""所以不用length - 1
        }

        //https://leetcode.com/problems/edit-distance/solutions/159295/python-solutions-and-intuition-by-anders-amxq/?page=3
        //這位還有提供recusive的解法，概念其實也是解小問題，他有加上cache解掉重複問題(沒解就會變像backtracing，複雜度變combination會爆炸)
        //https://leetcode.com/problems/edit-distance/solutions/25846/c-on-space-dp-by-jianchao-li-7fkd/?page=3
        //這位方法一樣，只是後面有點精簡，沒有追求100%可以不用理會
        //我看大家都是if (word1[i - 1] == word2[j - 1]) {} else {} => 仔細想想也是，因為概念上simulation必定是 [i-1][j-1] < [i-1][j] && [i-1][j-1] < [i][j-1] 因為直接少個字(雖然沒想如何證明)，但我直接全部比可以直接不用思考，也還行
    }
}
