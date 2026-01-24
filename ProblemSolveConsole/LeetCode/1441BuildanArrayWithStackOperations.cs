using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
#if false //舊方法，這方法有蠻特別的雖然是雙迴圈，但只會走n，適合爭取眼球
    public IList<string> BuildArray(int[] target, int n)
    {
        int streamIndex = 1;

        List<string> result = new List<string>();
        foreach (int num in target)
        {
            for (; streamIndex <= n; streamIndex++)
            {
                result.Add("Push");
                if (streamIndex == num)
                {
                    streamIndex++;
                    break;
                }
                result.Add("Pop");
            }
        }

        return result;
    }
#endif
    public class _1441BuildanArrayWithStackOperations
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            // 1 <= target[i] <= n
            //target is strictly increasing.
            //代表1~n一定能滿足答案
            //valid answers, return any of them => 因為 push push pop pop 和 push pop push pop 結果一樣
            List<string> result = new List<string>();
            int index = 0;
            for(int i = 1; i <= n; i++)
            {
                if(index == target.Length)
                {
                    break; //避免 out of index
                }

                result.Add("Push"); //有資料就一定會做
                if (i != target[index])
                {                    
                    result.Add("Pop"); //不需要就立即丟棄
                }
                else
                {
                    index++;//target point滿足所以移動
                }
            }

            return result;
        }

        //上面適用stack概念(pop丟棄)而非結構來解題
        //另外有想個解決方法，就是直接算target間差值來補push pop，但其實好像總add次數跟上面方法一樣，沒特別好很多就沒實作了
        //https://leetcode.com/problems/build-an-array-with-stack-operations/solutions/4241460/3-approaches-brute-forcetwo-pointers-sta-c6nb/
        //法一就是我的舊方法
        //法二其實就是法二
        //法三是我現在的方法
        //https://leetcode.com/problems/build-an-array-with-stack-operations/solutions/624278/java-simple-check-by-poorvank-fhnk/
        //這位方法跟我一樣，我用n來loop，他用target來loop，可以省去判斷break，值得參考!

    }
}
