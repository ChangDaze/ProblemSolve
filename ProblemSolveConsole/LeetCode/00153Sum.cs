using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _00153Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
#if false //完全暴力解會超過time limit
            //複雜度 sum(i=0~n-3)sum(j=i+1~n-2)(n-j) = n(n−1)(n−2)/6 => O(n^3)

            HashSet<Tuple<int, int, int>> result = new HashSet<Tuple<int, int, int>>();
            if (nums == null || nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            int[] tempNums = new int[nums.Length];
            Array.Copy(nums, tempNums, tempNums.Length);
            Array.Sort(tempNums);

            for (int i = 0; i< tempNums.Length - 2; i++)
            {
                for(int j = i + 1; j < tempNums.Length -1; j++)
                {
                    for (int k = j + 1; k < tempNums.Length; k++)
                    {
                        if (tempNums[i] + tempNums[j] + tempNums[k] == 0)
                        {
                            result.Add(Tuple.Create(tempNums[i], tempNums[j], tempNums[k]));
                        }
                    }
                }
            }

            return result
                    .Select(t => (IList<int>)new List<int> { t.Item1, t.Item2, t.Item3 })
                    .ToList(); ;
#endif

#if true // two pointer

            //時間複雜度
            //排序 → O(n log n)
            //外層迴圈 i → O(n)
            //內層左右指標掃描 → 每個 i 最多掃描 n 次 → O(n)
            //總計：O(n²)

            //空間複雜度
            //排序使用 O(1) 額外空間（原地排序）
            //結果 List → 最多 O(n²)（最壞情況，所有三元組都符合） > 最多O(n^2)直觀來說就算所有都符合條件，外層for = O(n) 內層 while O(n) 所以有可能存的結果就是 O(n) * O(n) => two pointer幫忙將O(n^2)變O(n)了
            //總計：O(n²)

            //(1)index要不同(2)組合用的value distinct
            //1.代表每層迴圈只能提供相同的數字一次來完成條件 > 每層要完成
            //2.提供的組合不同但用的內容一樣業需排除 ex:[-1,0,1] == [-1,1,0] > 計算要完成
            List<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
            {
                return new List<IList<int>>();
            }
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if( i > 0 && nums[i] == nums[i - 1]) //滿足1.條件
                {
                    continue;
                }

                //因有排序過，所以用two pointer來加速跳過不必要的計算
                //A.因為排序過可以用sum >0,<0,==0 來推進pointer尋找可能的組合
                //B.因為排序過可以輕易跳過使用過的數字
                // two pointer + sort能達成2.的條件
                int left = i + 1;
                int right = nums.Length - 1;

                while( left < right )
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if( sum == 0 )
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });

                        //跳過後續中重複的組合(因為要sum == 0 ，所以重複的數字一定會落入2.的排除條件)
                        while (left < right && nums[left] == nums[left + 1])
                        {
                            left++;
                        }
                        while (left < right && nums[right] == nums[right-1])
                        {
                            right--;
                        }
                        //因為要sum == 0 ，所以重複的數字一定會落入2.的排除條件，所以left right都會動(pointer收縮)                        
                        left++;
                        right--;
                        //至此每層完成1. 計算完成2.的條件
                    }
                    else if( sum < 0)
                    {
                        left++; //因為sum < 只能找能提供更大sum的選擇繼續比對

                        //do
                        //{
                        //    left++;
                        //} while (left < right && nums[left] == nums[left - 1]);
                        //或
                        //left++;
                        // while (left < right && nums[left] == nums[left - 1]) left++; // 小幅加速 > 重複很多時確有奇效，可以左右都加上
                        //狀況 差異
                        //元素全不同 幾乎沒變化
                        //重複元素很多 執行時間可減少 10 % ~30 %
                        //結果三元組很多 不影響正確性
                    }
                    else
                    {
                        right--; //因為sum > 只能找能提供更小sum的選擇繼續比對
                    }

                }
            }

            return result;
#endif
            //https://leetcode.com/problems/3sum/solutions/3736346/java-easiest-solution-ever-by-abhiyadav0-l3rg/?page=3
            //最簡單還是sort + 2 pointer
            //https://leetcode.com/problems/3sum/solutions/725950/python-5-easy-steps-beats-974-annotated-0bej2/?page=3
            //這個用列舉所有可能(1個0，2個0(同3個0)，3個0...) + set來解 => 算偏暴力吧，因為可能性爆炸就G了
        }
    }
}
