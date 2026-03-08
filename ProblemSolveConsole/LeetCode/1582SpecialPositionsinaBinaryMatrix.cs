using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1582SpecialPositionsinaBinaryMatrix
    {
#if false //舊方法，偏向反證法，其實閱讀性蠻高的，就是最後狀態都是rRecord[i] == 1 && cRecord[j] == 1的才會是符合條件的point，不過這樣points要全走兩次 => 好像也還好
            public int NumSpecial(int[][] mat)
            {
                int result = 0;
                int[] rRecord = new int[mat.Length];
                int[] cRecord = new int[mat[0].Length];
                for(int i = 0;i<mat.Length; i++)
                    for (int j = 0; j < mat[0].Length; j++)
                        if (mat[i][j] == 1)
                        {
                            rRecord[i]++;
                            cRecord[j]++;
                        }

                for (int i = 0; i < rRecord.Length; i++)
                    for (int j = 0; j < cRecord.Length; j++)
                        if (rRecord[i] == 1 && cRecord[j] == 1)
                        {
                            if (mat[i][j]==1)
                                result++;
                        }
                            

                return result;
            }
#endif
        public int NumSpecial(int[][] mat)
        {
            //Dictionary<int, bool> iStatus = new Dictionary<int, bool>();//應該可以用int[]+1和0就好，資源可能省一點
            //Dictionary<int, bool> jStatus = new Dictionary<int, bool>();
            int[] iStatus = new int[mat.Length];//應該可以用int[]+1和0就好，資源可能省一點 => 確實變快了@@ => 要記住
            int[] jStatus = new int[mat[0].Length]; //要注意用mat[0]，他給的可能不是正方形
            List<(int, int)> potentilas = new List<(int, int)> (); //用tuple也稍微吃資源，可能用閱讀性較差的int[]又更好一些

            for (int i = 0; i < mat.Length; i++)
            {
                for(int j = 0; j < mat[i].Length; j++) //不能跳過整行或整列會影響狀態蒐集，所以每個點都要跑過
                {
                    if(mat[i][j] == 0) { continue; }

                    //if (iStatus.ContainsKey(i) || jStatus.ContainsKey(j)) //如果row或column其中之一有中，也會導致沒中的部分也被標記為false
                    //{
                    //    iStatus[i] = false;
                    //    jStatus[j] = false;
                    //}
                    //else //如果row和column都沒有中，把預設狀態標記為true，看後續是否被更改狀態
                    //{
                    //    iStatus[i] = true;
                    //    jStatus[j] = true;
                    //    potentilas.Add((i, j));//只有一開始狀態就都true的後續才會在結果檢查狀態是否都是true直到結束
                    //}

                    if (iStatus[i] != 0 || jStatus[j] != 0) //如果row或column其中之一有中，也會導致沒中的部分也被標記為-1
                    {
                        iStatus[i] = -1;
                        jStatus[j] = -1;
                    }
                    else //如果row和column都沒有中，把預設狀態標記為，看後續是否被更改狀態
                    {
                        iStatus[i] = 1;
                        jStatus[j] = 1;
                        potentilas.Add((i, j));//只有一開始狀態就都的後續才會在結果檢查狀態是否都是1直到結束
                    }
                }
            }

            int result = 0;
            foreach((int, int) point in potentilas)
            {
                if (iStatus[point.Item1] == 1 && jStatus[point.Item2] == 1)//檢查potentilas後續狀態是否被變更為false
                {
                    result++;
                }
            }

            return result;
        }

        //https://leetcode.com/problems/special-positions-in-a-binary-matrix/solutions/843949/c-2-passes-by-votrubac-4vhx/?envType=daily-question&envId=2026-03-04
        //這位方法跟舊方法一樣
        //https://leetcode.com/problems/special-positions-in-a-binary-matrix/solutions/843953/java-simple-loop-by-hobiter-u97k/?envType=daily-question&envId=2026-03-04
        //這位也跟舊方法一樣

        //後來用舊方法試跑確實比較快，但跟新方法改良後也只差1ms，可能是因為row和col不會太長導致potentilas地排除效果可能沒太好?
        //但就結果來說如果目標就是短小精幹多次使用，那確實舊方法符合優化方向，如果資料更多，狀態是0的資料占大部分，那新方法可能較優
        //如果真的有考，可能新舊兩種都要能拿得出手，是個不錯的對比
    }
}
