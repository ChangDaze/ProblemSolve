using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0944DeleteColumnstoMakeSorted
    {
        public int MinDeletionSize(string[] strs)
        {
            //time:O(kn)
            //spaceL:O(k)

            int n = strs.Length;
            if (n <= 1) //不用比較
            {
                return 0;
            }
            
            int k = strs[0].Length;// all of the same length
            int result = 0;

            bool[] fails = new bool[k]; //預設false

            for (int i = 1; i < n; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    if (fails[j]) //防止重複計算
                    {
                        continue;
                    }

                    if (strs[i][j] < strs[i - 1][j])//lexicographically可接受等於
                    {
                        fails[j] = true;
                        result++;//有非符合條件就納入計算
                    }
                }
            }

            return result;
        }

        //我是一rowrow走，別人columncolumn走直接不用bool[] XD

        //https://leetcode.com/problems/delete-columns-to-make-sorted/solutions/2989644/simple-java-solution-with-comments-by-sa-kvr2/?envType=daily-question&envId=2025-12-20&page=3
        //這個人方法跟我一樣，不過他做得比我好多了XD，他是by column一次比完，所以根本不用bool[]XD
        //其他人方法都差不多，這題超單純
    }
}
