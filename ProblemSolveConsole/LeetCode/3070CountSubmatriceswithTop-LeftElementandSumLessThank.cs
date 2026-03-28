using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3070CountSubmatriceswithTop_LeftElementandSumLessThank
    {
        public int CountSubmatrices(int[][] grid, int k)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            int result = 0;
            int x = grid.Length;
            int y = grid[0].Length;

            //建立prefixSum
            int[][] map = new int[x][];//map 的每格 = 所有小於等於此格x和y的value加總
            for(int i = 0 ; i < x; i++)
            {
                map[i] = new int[y];
            }

            //loop
            for (int i = 0; i < x; i++) //by row 往下增長
            {
                for (int j = 0; j < y; j++)
                {
                    int temp = 0;
                    if (i - 1 >= 0)
                    {
                        temp += map[i-1][j];
                    }

                    if(j - 1 >= 0)
                    {
                        temp += map[i][j-1];
                    }

                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        temp -= map[i - 1][j - 1]; 
                    }

                    temp += grid[i][j]; //cur = map[i-1][j] + map[i][j-1] - map[i - 1][j - 1] (重覆計算部分) + grid[i][j] (沒計算到的部分)

                    map[i][j] = temp; //紀錄cur

                    if (temp <= k) //往後只會更大，所以不用再比了
                    {                        
                        result++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }

        //有一點dynamic programming 味道，但感覺比較偏 prefixsum
        //https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/solutions/7655684/count-submatrices-with-top-left-element-9bqfe/
        //這方法其實跟我一樣，不過他row 是推進累積得所以會省空間，我當初因為想寫的不要太複雜所以沒省空間，但熟練後應該要信手拈來
        //https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/solutions/7655586/2d-prefix-sum-begineer-friendly-with-dry-cg1g/
        //https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/solutions/7655319/2d-prefix-sum-with-early-stopbeats-100-b-wdit/
        //這幾位方法都一樣，看來這題就標準解
    }
}
