using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0073SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            //這題主要應該是考space利用，雖然是inplace但也有用int[][] int[] int 或是原matrix多個選擇
            //一開始沒看懂我就照著提示直接做 用HashSet的 => 這種標記方法要記住
            //提示的O(1)方法我還不知道要如還在動態下不受影響

            //time:O(nm)
            //space:O(n+m)

            HashSet<int> row = new HashSet<int> ();
            HashSet<int> column = new HashSet<int>();

            //標記flag，替換代表性文字
            for (int i  = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        row.Add(i);
                        column.Add(j);
                    }
                }
            }

            //刷新資料
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (row.Contains(i) || column.Contains (j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        //https://leetcode.com/problems/set-matrix-zeroes/solutions/26014/any-shorter-o1-space-solution-by-mzchen-45mk/?page=3
        //結果還是能用O(1) space達成
        //1.因為row0 和 col0 當flag會互相影響，所以這位有防互相影響讓col0不看matrix的flag另外建flag variable
        //2.用row0 column0 當flag 後面要用botton up 來處理，避免修改的值被當flag用，如果用rowlast和columnlast當flag應該可以相反
        //step2的參考題 => 用top down參考flag會錯
        //[1, 1, 1, 1]
        //[1, 1, 0, 1]
        //[1, 1, 1, 1]
        //[0, 1, 1, 1]
        //這兩點都影響很多，要記住
        //https://leetcode.com/problems/set-matrix-zeroes/solutions/26008/my-ac-java-o1-solution-easy-to-read-by-l-scc7/?page=3
        //這個人處理方法很清晰，直接把困難點拔出來
        //1.比起上面一位這位把row0 和 col0是否整個更新都拔出來
        //2.先處理除flag外的所有格子 => 就不會因為flag被異動受影響
        //3.再統一處理row0 和 col0異動
        //雖然這位步驟多一點點但更加清晰單易懂，也不用管botton up 或 top down 之類的
    }
}
