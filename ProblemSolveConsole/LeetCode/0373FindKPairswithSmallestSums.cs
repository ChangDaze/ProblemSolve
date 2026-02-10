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
            //Time complexity: O(N * M * log K) => pq限制k也有好處，比較peek時只有O(1)，因為容量只有k，所以新增最多也就O(log K)，不限制容量logk也是會很大
            //Space complexity: O(K) => 因為容量只有k

            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if(pq.Count < k)
                    {
                        pq.Enqueue([nums1[i], nums2[j]], -(nums1[i] + nums2[j]));
                    }
                    else
                    {
                        pq.TryPeek(out int[] element, out int priority);
                        if (-(nums1[i] + nums2[j]) <= priority) //<=最小值就剪枝，基本上所有組合都有可能...，沒剪枝就會超過timelimit
                        {
                            break;
                        }

                        pq.DequeueEnqueue([nums1[i], nums2[j]], -(nums1[i] + nums2[j])); //沒dequeue限制space上限就會超過space limit
                    }
                }
            }

            List<IList<int>> result = new List<IList<int>>();
            
            for (int i =0; i < k && pq.Count > 0; i++)
            {
                result.Add(pq.Dequeue());
            }
            
            return result ;
        }
    }
}
