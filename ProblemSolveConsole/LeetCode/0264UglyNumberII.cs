using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0264UglyNumberII
    {
#if false
        public int NthUglyNumber(int n)
        {
            List<long> heap = new List<long>(); //實作pq
            HashSet<long> seen = new HashSet<long>();
            int[] primes = { 2, 3, 5 };

            //加入base
            heap.Add(1);
            seen.Add(1);

            long dequeue = 1; //目前彈出檢查的值
            for (int i = 0; i < n; i++)//走n次直到找到第n個
            {
                //dequeue
                dequeue = heap[0];//左至右，小至大
                heap[0] = heap[heap.Count - 1]; //swap尾端，並將最尾端值滾到頂端後續重排
                heap.RemoveAt(heap.Count - 1); //移除最小值

                //heap[0]下沉重排
                int move = 0;
                while(true)
                {
                    //重排時跟兩個child比 => 這些都是index
                    int left = 2 * move + 1;
                    int right = 2 * move + 2;
                    int smallest = move;

                    //有檢查heap.Count 空heap就也不會出問題(move==smallest)
                    if (left < heap.Count && heap[left] < heap[smallest])
                    {
                        smallest = left;
                    }

                    if (right < heap.Count && heap[right] < heap[smallest])
                    {
                        smallest = right;
                    }

                    if (smallest == move) break; //重排完畢，不再移動

                    (heap[move], heap[smallest]) = (heap[smallest], heap[move]); //夠大，重排繼續，swap後繼續下沉
                    move = smallest; //smallest的值被swap成要繼續重排的值了，接續重排
                }

                foreach (int p in primes) //生成數字並enqueue
                {
                    long next = dequeue * p;
                    if (!seen.Contains(next))
                    {
                        seen.Add(next);
                        heap.Add(next);

                        //新enqueue的值做上浮
                        int enqueue = heap.Count - 1;
                        while(move > 0) //沒到頂點還能繼續浮就浮
                        {
                            int parent = (enqueue - 1) / 2;//因為是binary tree 所以要背起來找parent方式
                            if (heap[enqueue] >= heap[parent])
                            {
                                break; //不夠小了，不繼續上浮
                            }

                            (heap[enqueue], heap[parent]) = (heap[parent], heap[enqueue]);//夠小，swap後繼續上浮                  
                            enqueue = parent;//parent的值被swap成enqueue的值了，接續上浮
                        }
                    }
                }
            }

            return (int)dequeue;
        }
#endif
#if true
        public int NthUglyNumber(int n)
        {
            //如果用1~n的方式檢查uglynum在數字小時容易做到，但數字越大uglynum間隔越大
            //假設第2e個uglynum要走到n=8e，就會造成非常多不必要的計算，用自行生成就能消滅這些間隔 => 結果第1407就破intㄌ...多算的間隔超大XD，根本不是2e 8e的差距，是不用可能算不出來

            //time:O(n log n) => 因為每次*3個數去掉重複 約 2~3n 再乘 heap 搜尋
            //space:O(n)

            PriorityQueue<long, long> pq = new PriorityQueue<long, long>();
            int[] primes = [2, 3, 5];
            HashSet<long> seen = new HashSet<long>(); 
            pq.Enqueue(1,1);
            long cur = 0;//1 <= n <= 1690，所以答案至少是1
            while (n > 0)
            {
                cur = pq.Dequeue();
                foreach(int i in primes) //自行生成後續順序的uglynum(也會自動排列組合後由小到大被dequeue)
                {
                    
                    long generateUgly = cur * i;
                    if (seen.Contains(generateUgly)) //排列組合相乘會出現重複，要跳過
                    {
                        continue;
                    }
                    pq.Enqueue(generateUgly, generateUgly);
                    seen.Add(generateUgly);
                }
                n--;
            }
            return (int)cur;
        }
#endif
    }

    //https://leetcode.com/problems/ugly-number-ii/solutions/69364/my-16ms-c-dp-solution-with-short-explana-h56l/
    //這位的數字生成概念是一樣的，不過他是用DP+多pointer實作 => 用pointer來控制生成，用pointer+min代替pq找最小值的效果 => pointer少時可簡單實作，pointer多時應該也能時做2元dp ， 註:C++ false true可以直接return int 0 和 1
    //https://leetcode.com/problems/ugly-number-ii/solutions/69362/on-java-solution-by-syftalent-8clu/
    //這位方法跟第一位一樣
    //霸部分人其實是用dp耶，因為相比pq O(nlogn) dp是O(n) 確實也比較好
}
