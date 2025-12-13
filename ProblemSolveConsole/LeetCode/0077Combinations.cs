using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0077Combinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            //Time complexity:O(C(n, k))
            //Space complexity:O(C(n, k))
            IList<IList<int>> result = new List<IList<int>>();
            List<int> combine = new List<int>();
            List<int> chooses = Enumerable.Range(1, n).ToList(); //其實不用做chooses，for i 1 ~ n 是一樣意思...
            int end = n - k + 1; //外層的臨界點限制

            for (int i = 0; i < end; i++) //在外層做可以用end少做幾個recursive
            {
                combine.Add(chooses[i]);
                Recursive(chooses, i + 1, k, result, combine);
                combine.RemoveAt(combine.Count - 1);
            }

            return result;
        }

        private void Recursive(List<int> chooses, int index, int k, IList<IList<int>> result, List<int> combine)
        {
            if (combine.Count == k)
            {
                result.Add(new List<int>(combine));
                return;
            }

            for (int i = index; i < chooses.Count; i++) //n - (k - combine.Count) + 1 ，這裡其實也能剪枝
            {
                combine.Add(chooses[i]);
                Recursive(chooses, i + 1, k, result, combine);
                combine.RemoveAt(combine.Count - 1);
            }
        }

        //https://leetcode.com/problems/combinations/solutions/26992/short-iterative-c-answer-8ms-by-hengyi-xtma/
        //這個是固定k的長度(vector<int> p(k, 0);)，然後i當pointer(在處理第幾個值)，p[i]是實際的值組合，扁平化其實概念跟for+recursive一模一樣，但他這樣混用有夠難懂，不過沒有讓廢任何空間和時間，確實可能很快
        //p[i] = p[i - 1]; 讓下個數在下個迴圈開頭就++，以達成C的效果
        //p[i]++; if (p[i] > n) --i; 最後個字跑完到n後，回上層++，在下來一層跑到n，所以說跟recursive其實一樣
        //https://leetcode.com/problems/combinations/solutions/5418489/video-simple-backtracking-solution-by-ni-ug0h/
        //這方法其實一樣
    }
}
