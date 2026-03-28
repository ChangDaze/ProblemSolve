using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1727LargestSubmatrixWithRearrangements
    {
        public int LargestSubmatrix(int[][] matrix)
        {
            //Time complexity:O(m*n*logn) => prefixsum + copy matrix + sort
            //Space complexity:O(m * n) => copy matrix
            int m = matrix.Length;
            int n = matrix[0].Length;
            int ans = 0;

            for(int row = 0; row < m; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    if(matrix[row][col] != 0 && row > 0)//(1)非連續就會歸零(重點)=> 所以submatix 靠上方row還是靠下方row這個問題就會被解決(2)防止超出邊界
                    {
                        matrix[row][col] += matrix[row - 1][col];
                    }
                }

                int[] currRow = new int[n];
                Array.Copy(matrix[row], currRow, n); //避免影響prefix sum 和 dp
                Array.Sort(currRow); //由小到大排序
                for(int i = 0; i< n; i++)
                {
                    ans = Math.Max(ans, currRow[i] * (n-i)); //因為由小到大排序，所以才n-i，因為i之後的都>=i的value
                                                             //ex: n = 3, i = 0, value = 1; i = 1, value = 2 ; i = 2, value = 3
                                                             //    i = 0 劃出的submatrix = 1 * (3-0) = 3 組成 1 * 3 格子
                                                             //    i = 1 劃出的submatrix = 2 * (3-1) = 4 組成 2 * 2 格子
                                                             //    i = 2 劃出的submatrix = 3 * (3-2) = 2 組成 3 * 1 格子

                }
            }

            return ans;
        }

        //https://leetcode.com/problems/largest-submatrix-with-rearrangements/solutions/4187914/largest-submatrix-with-rearrangements-by-cmhr/?envType=daily-question&envId=2026-03-17
        //官方解法，看圖超級清楚，看完就懂了 => 不過我這次只看了第一第二個approach 他後面還有兩個approach 可以研究
        //第二個approach只是共用一個temp array 而已
        //第三個approach其實有點heap + queue的感覺耶，很有趣 => 值得記住
        //List<Pair<Integer,Integer>> prevHeights + List<Pair<Integer,Integer>> heights 形成 queue的傳遞，只有consecutive blocks會在每次heights被留下
        //所以heights會自動形成sort 高到低 => 所以後續才Math.max(ans, heights.get(i).getKey() * (i + 1)) => i + 1是因為 0 base，直接乘是因為高到低所以i往前的value都是>=i的value
        //不過這個approach的空間應該算 O(mn) 因為heights會一直進進出出
        //https://leetcode.com/problems/largest-submatrix-with-rearrangements/solutions/7653052/solution-by-la_castille-s27d/
        //https://leetcode.com/problems/largest-submatrix-with-rearrangements/solutions/7653134/simple-begineer-friendly-dry-run-by-sh_t-jypz/
        //看來大家方法都一樣耶，可能就是要記住prefix sum 和 consecutive blocks 觀念
    }
}
