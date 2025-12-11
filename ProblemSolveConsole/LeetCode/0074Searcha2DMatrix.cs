using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0074Searcha2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            //Time complexity:O(log(m * n))
            //Space complexity:O(1)
            int left = 0;
            int right = matrix.Length -1;
            int targetRow = -1;            

            //先找到該行
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (matrix[mid][0] <= target && target <= matrix[mid][matrix[mid].Length - 1]) //找到對的行才有這個效果
                {
                    targetRow = mid;
                    break;
                }
                else if(matrix[mid][0] > target) //後面簡單判斷即可
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if(targetRow == -1)
            {
                return false;
            }

            //該行找到該值
            left = 0;
            right = matrix[targetRow].Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (matrix[targetRow][mid] > target) 
                {
                    right = mid - 1;
                }
                else if (matrix[targetRow][mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        //這題要注意的可能是第一個while的binary search 變形用法，要記住怎麼使用
        //https://leetcode.com/problems/search-a-2d-matrix/solutions/26220/dont-treat-it-as-a-2d-matrix-just-treat-u8vgk/
        //...，這個人的做法更易懂XD，直接搭配%拆成一維，變成一般的binary search
        //https://leetcode.com/problems/search-a-2d-matrix/solutions/1895837/c-binary-search-tree-917-explained-with-3mijz/
        //這位很特別，他用1 row row找，所以不是O(log(m * n))，是單純O(n)，也很有趣
    }
}
