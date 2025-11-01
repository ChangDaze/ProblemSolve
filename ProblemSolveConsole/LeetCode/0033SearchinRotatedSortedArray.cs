using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0033SearchinRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
#if false //ai 優化前
            //想到O(logn)就想到binary search

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                if (nums[left] == target) { return left; }
                else if (nums[right] == target) { return right; }

                int newPoint = (left + right) / 2;
                if (nums[newPoint] == target) {  return newPoint; }

                if( target < nums[right]) //確認在最右往左
                {
                    if (nums[newPoint] > nums[right]) //target在靠近循環點處(接近極值處)
                    {
                        left = newPoint + 1;
                    }
                    else//target 在正常範圍內做binary search
                    {
                        if(target < nums[newPoint])
                        {
                            right = newPoint - 1;
                        }
                        else
                        {
                            left = newPoint + 1;
                        }
                    }
                }
                else if (target > nums[left]) //確認在最左往右
                {
                    if (nums[newPoint] < nums[left]) //target在靠近循環點處(接近極值處)
                    {
                        right = newPoint - 1;
                    }
                    else//target 在正常範圍內做binary search
                    {
                        if (target < nums[newPoint])
                        {
                            right = newPoint - 1;
                        }
                        else
                        {
                            left = newPoint + 1;
                        }
                    }
                }
                else
                {
                    return -1;//target已不在範圍內
                }                
            }

            return -1;
#endif

#if true //ai 優化後
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                //其實只要拿有序的那半邊來當binary search的base就好了
                //一定會有一邊有序

                // 左半邊有序
                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid]) //target在有序內，把範圍縮成有序內
                        right = mid - 1;
                    else //target在有序外，把範圍縮成有序外
                        left = mid + 1;
                }
                // 右半邊有序
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return -1;
#endif

            //https://leetcode.com/problems/search-in-rotated-sorted-array/solutions/14425/concise-olog-n-binary-search-solution-by-5eby/
            //這位用了比較精準的binary search 用了兩次binary search
            //a 透過找最小值找到偏移index
            //b 用binary search找target 只是每次找新的點都會用index補正 找value 看對應現在roate後array後指的是哪個位置
#if false //因為對我需要理解所以寫個註解
        int lo=0,hi=n-1;

        //這在rotation下能找到最小值的原因是
        //如果mid > hi代表 最小值在 mid+1 ~ hi 之間，反之代表 lo ~ mid 之間
        //可以用為了能檢查到最小值所以判斷條件是用
        //(1)lo<hi => 最終歸於一點 lo = hi
        //(2)else hi=mid => 整數除法會往小靠近 => 最終歸於一點
        while(lo<hi){
            int mid=(lo+hi)/2;
            if(A[mid]>A[hi]) lo=mid+1; 
            else hi=mid;
        }
        
        int rot=lo; //找到index
        lo=0;hi=n-1;
        
        //下面就是binary search的精隨之一，要關注的是target在還原後mid的左還是右而已
        //ex:target在還原後mid右方，所以要往右找，如何能在還原後往右? => 目前的lo往右 => realmid 是循環的，但排序順序不變，所以realmid可能變小但在排序上是變大的
        //*這邊mid是暗指原本順序(非rotate後)，所以才用(mid+rot)%n去找對應現在順序下mid指到的是哪個值，所以lo和hi是用原本順序定位的binary search
        //用lo<=hi是因為可能沒有答案所以最後也要檢查
        while(lo<=hi){
            int mid=(lo+hi)/2;
            int realmid=(mid+rot)%n;
            if(A[realmid]==target)return realmid;
            if(A[realmid]<target)lo=mid+1;
            else hi=mid-1;
        }
        return -1;
#endif
        }
    }
}
