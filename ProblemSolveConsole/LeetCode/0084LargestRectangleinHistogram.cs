using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0084LargestRectangleinHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            Stack<int> stack = new Stack<int>();  //存入index，遇到較小(>=都能形成rectangle)才計算rectangle，所以stack是單調遞增
            int max = 0;

            for(int i = 0; i < heights.Length; i++)
            {
                while(stack.Count > 0 && heights[stack.Peek()] > heights[i])//馬上不符合的也會計算到height * 1的面積 
                {
                    int size = heights[stack.Pop()] * (i- (stack.Count > 0 ? stack.Peek() + 1 : 0) ); 
                    //高度是stack.Pop()，寬度是 i ~ 上上一個最小之間(stack.Peek())，因為上上一個最小會更小所以不包含，此高度會是這寬度之間的最低，如果是整個array最低或i以前最低，就會用 0
                    if (size > max)
                    {
                        max = size;
                    }
                }
                stack.Push(i);
            }

            //計算到最後都有形成rectangle的面積
            while (stack.Count > 0)
            {
                int size = heights[stack.Pop()] * (heights.Length - (stack.Count > 0 ? stack.Peek() + 1 : 0) );
                if (size > max)
                {
                    max = size;
                }
            }

            return max;
        }

        //這個還在單純的monotonic stack的應用範疇，比較抽象的是，寬度是 i ~ 上上一個最小之間
        //因為之前的都單純用i ~ stack.Pop()，所以index的利用也漸漸要往更多面向理解，像這裡stack.Pop()就是此高度會是這寬度之間的最低，所以真正寬度是i ~ 上上一個最小之間而非i ~ stack.Pop()

        //https://leetcode.com/problems/largest-rectangle-in-histogram/solutions/28902/5ms-on-java-solution-explained-beats-96-skgtx/
        //這個人是用dynamic program，以每個heights[i]為中心，找往左能延伸的最遠index  lessFromLeft[i]，找往右能延伸的最遠index lessFromRight[i]
        //因為往左和右都是遇到比自己更小才停下，所以實際寬度計算是 (lessFromRight[i] - 1) - (lessFromLeft[i] + 1) + 1 (+1是i本身的寬度1)
        //所以空間時間都會O(3n) ， 雖然可能不如monotonic stack但也是值得記住的方法
        //https://leetcode.com/problems/largest-rectangle-in-histogram/solutions/28917/ac-python-clean-solution-using-stack-76m-nmv1/
        //這位的方法就跟我一樣
        //不過他有做一個特別的事，他height.append(0)來多賦予一個絕對最小值，讓最後會自動在迴圈中計算所有組合
        //這讓他不用像我一樣最後要整理stack，但也需消耗array重整成n+1的記憶體，可以當作精簡程式碼的漂亮一筆，也值得記住
        //https://leetcode.com/problems/largest-rectangle-in-histogram/solutions/5378360/video-explanation-by-niits-vacy/
        //這位的方法就跟我完全一樣

        //看來用monotonic stack解比較多
    }
}
