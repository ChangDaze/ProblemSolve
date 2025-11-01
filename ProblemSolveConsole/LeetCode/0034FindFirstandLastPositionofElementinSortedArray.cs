using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0034FindFirstandLastPositionofElementinSortedArray
    {
#if false //AI優化前
        public int[] SearchRange(int[] nums, int target)
        {
        //Time complexity:O(logn)
        //Space complexity:O(1)
            if(nums == null || nums.Length == 0)
            {
                return [-1, -1];
            }

            //先用binary search 找到確定點
            int left = 0;
            int right = nums.Length - 1;
            int mileStone = -1;
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    mileStone = mid;
                    break;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if(mileStone == -1)
            {
                //沒找到就回傳[-1, -1]
                return [-1, -1];
            }

            //有找到就分兩邊找上下界
            int smallBoundry = FindBoundry(nums, target, 0, mileStone, false); //mid只會找到小於或等於
            int bigBoundry = FindBoundry(nums, target, mileStone, nums.Length -1, true); //mid只會找到大於或等於

            return [smallBoundry + 1, bigBoundry - 1];
        }

        private int FindBoundry(int[] nums,int target, int left, int right, bool findBigger)
        {
            //長度1進來因為left = right 所以不會out of boundry            
            //長度2進來會受findBigger引導走對方向也不會out of boundry            

            while (left < right) //沒用=判斷必定找到一個
            {
                int mid = (left + right) / 2;

                if (nums[mid] == target)
                {
                    if (findBigger)
                    {
                        left = mid + 1; //最後findBigger會丟回的相異地方
                    }
                    else
                    {
                        right = mid - 1; //最後!findBigger會丟回的相異地方
                    }
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            //會找到相異(因為一定有相同的，所以一定會定位到nums[mid] == target影響的指標)的地方，所以要依據找到的方向丟回
            //但若最後沒辦法丟回相異的boundry時要特殊處理
            if (findBigger)
            {
                //最後有檢查nums[index]就要避免 out of boundry
                return left <= nums.Length -1 && nums[left] == target ? left + 1 : left;
            }
            else
            {
                return right >= 0 && nums[right] == target ? right - 1 : right;
            }
           
        }
#endif
#if true //AI優化後
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new[] { -1, -1 };

            int first = LowerBound(nums, target);

            // 如果 first 越界 或該位置不是 target，就不存在
            if (first == nums.Length || nums[first] != target)
                return new[] { -1, -1 };

            int last = UpperBound(nums, target) - 1;

            return new[] { first, last };
            //整體比較易讀(迴圈也從3個變2個，雖然搜尋總長度應該3個迴圈比較短)，但能理解優化後方法的，基本也是能理解優化前的用法

            //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/solutions/14734/easy-java-ologn-solution-by-atwenbobu-ee1d/
            //這個人就思路更清晰，只記錄合法的範圍內結果，但方法內容基本一樣

        }

        // 找第一個 >= target 的位置
        private int LowerBound(int[] nums, int target)
        {
            int left = 0, right = nums.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] >= target)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left; //會找到left == right == target的靠左唯一點 或 target不存在 left == nums.Length的點
        }

        // 找第一個 > target 的位置
        private int UpperBound(int[] nums, int target)
        {
            int left = 0, right = nums.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                    right = mid;
                else //(nums[mid] <= target)
                    left = mid + 1;
            }
            return left; //會找到left == right == target的靠右唯一且+1的點 或 target一定存在(因為前面找過了)
        }
#endif
    }
}
