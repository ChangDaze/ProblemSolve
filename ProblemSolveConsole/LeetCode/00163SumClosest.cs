using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _00163SumClosest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            //時間複雜度
            //排序 → O(n log n)
            //外層迴圈 i → O(n)
            //內層左右指標掃描 → 每個 i 最多掃描 n 次 → O(n)
            //總計：O(n²)

            //空間複雜度
            //排序使用  

            //基本照抄00153Sum
            //1.重複的不用檢查
            //2.用two pointer逼近最接近的數即可
            Array.Sort(nums);
            int result = int.MaxValue;
            int absDelta = Math.Abs(target - result);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if( i > 0 && nums[i] == nums[i - 1]) //滿足1.
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    int tempDelta = target - sum;
                    int tempAbsDelta = Math.Abs(tempDelta);

                    if(tempAbsDelta < absDelta)
                    {
                        result = sum;
                        absDelta = tempAbsDelta;
                    }

                    //滿足2.
                    if (sum == target)
                    {
                        break;
                    }
                    else if(tempDelta > 0) //找比現在大的組合
                    {
                        do
                        {
                            left++;
                        } while (left < right && nums[left] == nums[left - 1]);
                    }
                    else //找比現在小的組合
                    {
                        do
                        {
                            right--;
                        } while (left < right && nums[right] == nums[right+ 1]);                        
                    }
                }

                if (result == target)
                {
                    break;
                }
            }

            return result;
        }
    }
}
