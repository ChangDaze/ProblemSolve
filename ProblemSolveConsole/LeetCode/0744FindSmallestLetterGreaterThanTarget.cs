using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0744FindSmallestLetterGreaterThanTarget
    {
#if false //舊解法，哇，舊解法比較好，binary search只有logn
            public char NextGreatestLetter(char[] letters, char target)
            {
                int left = 0;
                int right = letters.Length-1;
                while (left <= right)
                {
                    int mid = left + (right-left)/2;
                    if (letters[mid] <= target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                if(left == letters.Length)
                    return letters[0];
                else
                    return letters[left];

            }
#endif
        public char NextGreatestLetter(char[] letters, char target)
        {
            char result = letters[0];

            foreach (char c in letters)
            {
                if (c > target)
                {
                    result = c;
                    break;
                }
            }

            return result;
        }

        //這題很單純，找出升序中大於target的最小值，所以找到就break了
        //太大意了，這題應該用binary search，因為單純，所以最優解也明顯...
        //但不用binary search確實程式碼很漂亮，可以做個漸進式嘗試來提供解法

        //https://leetcode.com/problems/find-smallest-letter-greater-than-target/solutions/110005/easy-binary-search-in-java-ologn-time-by-s34f/
        //binary search
        //這個人的優化方法註解有錯，只是不存在符合值時要return [0] 可以優雅傳回而已，我的舊方法的if(left == letters.Length)就完美處理了，可以不用考慮這位的
    }
}
