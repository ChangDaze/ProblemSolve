using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3010DivideanArrayIntoSubarraysWithMinimumCostI
    {
        public int MinimumCost(int[] nums)
        {
            //Time complexity: O(n)
            //Space complexity: O(1)
            int min = int.MaxValue;
            int secondMin = int.MaxValue;
            for(int i = 1; i < nums.Length; i++)//因為要是包含整個array的subarray，所以nums[0]一定要選(所以比較時也能跳過)，剩下只要挑兩個最小就好，subarray可以隨便切，其實只是找最小值
            {
                if (nums[i] < min)
                {
                    secondMin = min;
                    min = nums[i];
                }
                else if (nums[i] < secondMin)
                {
                    secondMin = nums[i];
                }
            }
            return nums[0] + min + secondMin; 
        }

        //原本想用sort，但撞到nums[0]一定要選，所以不能，另外想過min、secondMin是否只能呆呆比較，但想到好像就算有資料結構储存，可能也是比較後储存頂多比較中用binarysearch去linked list(好像也不行?)中插入之類的就沒多想
        //單純array loop
        //https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/solutions/4598879/easy-video-explanation-finding-2-minimum-db7g/
        //這位展示了部分array sort的方法，我原本以為沒提供，但想想in place sort應該早就有人實做了XD，C#也可以，不過會變nlogn，比單存手造輪子O(n)有一點點差異
        //https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/solutions/4598277/simple-java-solution-by-siddhant_1602-eght/
        //這位方法就完全一樣
        //https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/solutions/4598930/python-3-6-lines-heap-ts-99-81-by-spauld-3gft/
        //這位用了我想用的但想不到的資料結構heap，簡單講就是優先權，這裡就是最小的留著，heappush是引入的function，參數每次有傳入array(名叫heap)變數，第一次看有搞混，值得參考!
        //AI說的，以後研究
        //Priority Queue (優先權隊列) 是一種 概念
        //Heap(堆) 是一種 具體的資料結構 (是實現 Priority Queue 最有效率的一種方式)
    }
}
