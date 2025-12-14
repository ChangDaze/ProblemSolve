using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0081SearchinRotatedSortedArrayII
    {
        public bool Search(int[] nums, int target)
        {
            //Time complexity:無重複為 O(log n)，有重複元素時會退化到 O(n)，因為可能要線性掃描才能找到真正最小值
            //Space complexity:O(1)

            //先找到最小值找出位移

            int left = 0;
            int right = nums.Length - 1;

            while (left < right) // 最終會找到等於
            {
                int mid = (left + right) / 2;
                if(nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else //<=
                {
                    right = mid;
                }
            }

            //因為有duplicate所以還要向左找到最小 ex:[2, 2, 2, 2, 3, 2, 2] 沒繼續找會找錯 > 加上這個好像就從O(logn)變成O(n)ㄌ > 所以有duplicate是會有明顯影響的
            int limit = left; //避免整個陣列都一樣的值導致無限回圈
            int checkLeft = (left - 1 + nums.Length) % nums.Length;
            while (nums[checkLeft] <= nums[left] && checkLeft != limit)
            {
                left = checkLeft;
                checkLeft = (left - 1 + nums.Length) % nums.Length; //這只是單純一直向左找的公式
            }

            int rotate = left;

            //使用位移找target
            left = 0;
            right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                //int fixMid = (mid - rotate + nums.Length) % nums.Length; => 雖然是回推index的公式，但這是不對的用法，因為回推出原本index後現在的nums value也不等於原本index沒rotate 的 value
                //01234 index
                //ABCDE before rotate
                //DEABC after rotate
                //rotate = 2
                //index 2 用公式回推得到 index 0， 但 nums[0] = D != before rotate nums[0] = A
                int fixMid = (mid + rotate) % nums.Length; //這個反而對
                    //因為這邊left, right, mid都是假想用before rotate找到的位置
                    //所以實際去rotate後就會得到對應在nums上的位置

                if (nums[fixMid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[fixMid] < target)
                {
                    left = mid + 1;
                }
                else // =
                {
                    return true;
                }
            }

            return false;
        }

        //https://leetcode.com/problems/search-in-rotated-sorted-array/solutions/14425/concise-olog-n-binary-search-solution-by-5eby/
        //雖然是不同題distinct的，不過主要還是抄這位的
        //https://leetcode.com/problems/search-in-rotated-sorted-array-ii/solutions/28218/my-8ms-c-solution-ologn-on-average-on-wo-6inp/?page=3
        //這題是我那個 Q33 解法的進化版，蠻精簡的，簡單講就是一當下狀況去判斷target是否在範圍內來選擇往哪邊縮
        //他有加個重點 : https://leetcode.com/problems/search-in-rotated-sorted-array-ii/solutions/28218/my-8ms-c-solution-ologn-on-average-on-wo-6inp/?page=3
        //問AI是這樣解釋，蠻有道理的，如果左右端點和中點都相等，就「跳過」左右端點，因為這些元素對於判斷旋轉點或目標沒有幫助。 > 也確實這就代表右到左之間不是答案(前面先判斷)也都是duplicate的無用資訊

        //上面兩種方法都很清晰，應該都要會
    }
}
