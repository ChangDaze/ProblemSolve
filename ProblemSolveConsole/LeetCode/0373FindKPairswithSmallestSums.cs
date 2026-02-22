using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0373FindKPairswithSmallestSums
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            //Time complexity: O(N * M * log K) => pq限制k也有好處，比較peek時只有O(1)，因為容量只有k，所以新增最多也就O(log K)，不限制容量複雜度可能就也會很大，N、M代表nums1、nums2
            //Space complexity: O(K) => 因為容量只有k

            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if(pq.Count < k)//限制容量只有k
                    {
                        pq.Enqueue([nums1[i], nums2[j]], -(nums1[i] + nums2[j]));//priority高會靠前，為了排除最小值就用負數
                    }
                    else
                    {
                        pq.TryPeek(out int[] element, out int priority);//TryPeek才能同時取得value和priority
                        if (-(nums1[i] + nums2[j]) <= priority) //<=最小值就剪枝，因為default有排序了，基本上所有組合都有可能...，沒剪枝就會超過timelimit
                        {
                            break;
                        }

                        pq.DequeueEnqueue([nums1[i], nums2[j]], -(nums1[i] + nums2[j])); //沒dequeue限制space上限就會超過space limit
                    }
                }
            }

            List<IList<int>> result = new List<IList<int>>();
            
            for (int i =0; i < k && pq.Count > 0; i++)//i < k && pq.Count > 0 => 因為可能直接pq裡數量不到k，所以用&&
            {
                result.Add(pq.Dequeue());
            }
            
            return result ;
        }

        //https://leetcode.com/problems/find-k-pairs-with-smallest-sums/solutions/84551/simple-java-oklogk-solution-with-explana-iuy3/
        //這位方式也是用pq
        //1.(a,b)->a[0]+a[1]-b[0]-b[1] => 這是priority 比較器，兩兩int[]只比第一和第二個元素，第三個元素是找候補num2用
        //2.que.offer(new int[]{nums1[i], nums2[0], 0}); => 代表預設從nums1整條 + nums2[0] 開始，num2其實只會被考慮k次，第三個參數是用到的num1+num2中用到的num2 index，他會從用過的最小值中匹配下個num2 index看有沒有機會找到更小 => 這段其實蠻需要記住的，但我因為剪枝，所以出來的效果可能也跟他一樣喔@@
        //3.que.offer(new int[]{cur[0],nums2[cur[2]+1], cur[2]+1}); => 對應2的後續用法
        //https://leetcode.com/problems/find-k-pairs-with-smallest-sums/solutions/84550/slow-1-liner-to-fast-solutions-by-stefan-drc7/
        //這位最後的方法跟第一位很像，但概念更純粹，他num1可能都沒走完

        //上面兩位和我自己觀察出都能得到個結論 => 因為num1、num2都是排序過的，所以其實最小值一定包含num1[0]+num2[0] => 第二小值一定是num1[0]+num2[1]或num1[1]+num2[0] => 因為這個概念所以第二位的方法就很好的表現出來，第一位的方法就跟我很像先把num1都處理了

    }
}
