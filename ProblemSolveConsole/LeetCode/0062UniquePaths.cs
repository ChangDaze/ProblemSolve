using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0062UniquePaths
    {
        public int UniquePaths(int m, int n)
        {
            //有想到兩種解法
            //1.數學 combination，因為只有向右和向下，所以選擇是固定的 C x 取 y 的combination (C x 取 y = C y 取 x)  => 這應該可能快點
            //2.DP，小問題解大問題，可以看到右下角格 = 鄰近兩格的可能路徑數相加的步數(用 2 X 2, 3 X 3 可驗證) => 然後 col = 0 及 row = 0 時可能路徑數都是 1，所以可以
            //從(1, 0)=1  + (0, 1)=1 解 (1, 1)=2， (1, 1)=2 + (0, 2)=1 解 (1, 2)=3 這樣一路解到右下角 

#if false //數學 combination

            //combination 複雜度的兩種情境
            //1.只算數字 : O(k) ，就是O(n)， 可以用公式 : result = result * (n - i) / (i + 1); => 從P(n,k)/k!來的 ，歸納法上看公式過程一定整除，所以可以先忽略是否整除的細節
            //2.輸出組合 : O(C(n,k)) ，遠大於O(n)， 因為要輸出所有組合，不會有更有效率的複雜度

            //time:O(n)
            //space:O(1)

            int Cn = (m - 1) + (n - 1);
            int Ck = m > n ? n - 1 : m - 1;
            long result = 1; //因為是乘法要避免除之前溢位
            for(int i = 0; i < Ck; i++)
            {
                result = result * (Cn - i) / (i + 1);
            }
            return (int)result;
#endif

#if true //DP

            //time:O(n)
            //space:O(n)

            int[][] dp = new int[m][];

            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            for(int i = 0;i < m; i++)
            {
                for(int j = 0; j <n; j++)
                {
                    if(i == 0 ||  j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }
            }

            return dp[m-1][n-1];
#endif
        }

        //其他人解法其實一樣
        //https://leetcode.com/problems/unique-paths/solutions/22954/c-dp-by-jianchao-li-litp/
        //DP
        //https://leetcode.com/problems/unique-paths/solutions/22958/math-solution-o1-space-by-whitehat-kkab/
        //combination
    }
}
