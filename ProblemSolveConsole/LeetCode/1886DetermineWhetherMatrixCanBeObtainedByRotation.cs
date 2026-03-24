using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1886DetermineWhetherMatrixCanBeObtainedByRotation
    {
#if false //舊方法， 其實這方法也是很猛耶...，只有一次O(n)的暴力解，我用LU分解還要O(12n)其實蠻值得記住最後來炫技的，口頭說明應該就蠻清楚了
        public bool FindRotation(int[][] mat, int[][] target)
        {
            int indexLen = mat.Length - 1;
            bool method1 = true;
            bool method2 = true;
            bool method3 = true;
            bool method4 = true;
            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] != target[j][indexLen - i])
                        method1 = false;
                    if (mat[i][j] != target[indexLen - i][indexLen - j])
                        method2 = false;
                    if (mat[i][j] != target[indexLen - j][i])
                        method3 = false;
                    if (mat[i][j] != target[i][j])
                        method4 = false;
                }

            if (method1 || method2 || method3 || method4)
                return true;


            return false;
        }
#endif
        public bool FindRotation(int[][] mat, int[][] target)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            for (int i = 0; i < 4; i++)
            {
                //rotate 會被分解成 對角線映射 X 垂直映射 就像線性代數的LU分解 =>  VerticalSwap X DiagonalSwap = Rotate => 這就是證明 (也可以說是 Rotate X Rotate X Rotate X Rotate X mat = mat)
                DiagonalSwap(mat); //在線性代數叫做轉置 transpose                
                VerticalSwap(mat);
                if(MatrixCompare(mat, target))
                {
                    return true;
                }
            }

            return false;
        }

        private void DiagonalSwap(int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for(int j = mat[i].Length - 1;  j > 0; j--)//因為比i < j，j若從0開始每次都會是false
                {
                    if (i < j)
                    {
                        int temp = mat[i][j];
                        mat[i][j] = mat[j][i];
                        mat[j][i] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void VerticalSwap(int[][] mat)
        {
            for(int i =0; i < mat.Length;i++)
            {
                int middle = mat[i].Length / 2;
                for(int j = 0; j < middle; j++)
                {
                    int temp = mat[i][j];
                    int swapPoint = mat[0].Length - 1 - j;
                    mat[i][j] = mat[i][swapPoint];
                    mat[i][swapPoint] = temp;
                }
            }
        }
        private bool MatrixCompare(int[][] mat, int[][] target)
        {
            for(int i =0; i<mat.Length; i++)
            {
                for(int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] != target[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //不確定線性代數有沒有專用的演算法讓這種LU分解的SWAP能交換得更快速
        //不過我覺得這題算是激起想繼續學線性代數很好的映證題目XD
        //https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/solutions/1254089/c-straightforward-solution-comparing-in-m24bz/
        //這位跟舊方法一樣
        //https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/solutions/1254128/c-solution-with-rotation-working-and-eas-3r03/
        //這方法跟我一樣，reverse each row其實就是VerticalSwap
        //https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/solutions/3273931/java-100-fast-no-rotation-only-indexing-3dcx6/
        //這位跟舊方法一樣暴力解
        //說不定舊方法不算暴力解XD，在沒有變化下應該算是聰明解XD
    }
}
