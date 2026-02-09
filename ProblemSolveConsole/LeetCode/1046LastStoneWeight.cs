using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1046LastStoneWeight
    {
#if false //舊方法，使用Sorted List(感覺用array就好，但用使用Sorted會友Last可以用)，做得好複雜，可以看概念，但不要學應該是O(n*n) => 應該add和remove(單獨O(n)Last因為排好了才O(1))會造成這個複雜度，，Sorted List (全序) 和 Priority Queue / Heap (偏序) 核心差異: 前者相互間有排序，後者只有父子間有關聯，所以前者新增是O(N)，後者只要O(logN)，但取極值上兩者效果很像
            public int LastStoneWeight(int[] stones)
            {
                SortedList<int,int> queue = new SortedList<int,int>();

                foreach(int stone in stones) //用arrya index, value方式計數
                    if(queue.ContainsKey(stone))
                        queue[stone]++;
                    else
                        queue.Add(stone, 1);

                while (queue.Count > 1 || queue.Last().Value > 1)//還有2個以上就持續 
                {
                    int temp = queue.Last().Value > 1 ? 0 : queue.ElementAt(queue.Count-1).Key - queue.ElementAt(queue.Count - 2).Key;

                    if(temp == 0) //以前做法比較怪，找出極值，有兩個以上temp = 0，然後讓極值兩兩相消
                    {
                        queue[queue.Last().Key] -= 2;
                        if (queue[queue.Last().Key] == 0)
                            queue.Remove(queue.Last().Key);
                    }                                        
                    else//不能相消的極值互減
                    {
                        queue.Remove(queue.Last().Key);
                        if(--queue[queue.Last().Key] == 0) //倒數第2的處理
                            queue.Remove(queue.Last().Key);
                    }

                    //0也會被視為極值進入循環 > 這裡應該排除0加入循環，否則 0 會進入排序循環，增加不必要的計算量
                    if (queue.ContainsKey(temp))
                        queue[temp]++;
                    else
                        queue.Add(temp, 1);
                }

                if(queue.Count > 0)
                    return queue.Last().Key;
                else //剛好都互消
                    return 0;

                
            }
#endif
        public int LastStoneWeight(int[] stones)
        {
            //Time complexity:O(n + nlogn)
            //Space complexity:O(n)
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            foreach (int stone in stones) //O(n)
            {
                pq.Enqueue(stone, -stone); //預設是最小堆(越小越靠前)，所以要做最大堆priority要放負數
            }

            while(pq.Count > 1) //O(nlogn)
            {
                int diff = Math.Abs(pq.Dequeue() - pq.Dequeue());
                if (diff > 0)//為0時就抵銷掉不再加入
                {
                    pq.Enqueue(diff, -diff);
                }                
            }

            return pq.Count > 0 ? pq.Dequeue() : 0;//If there are no stones left, return 0，有可能遇到剩下兩個剛好相消
        }

        //原本要自己實作heap，但第一次真正用heap，所以先不造輪子
        //PriorityQueue的概念實作方法常見的就是heap

        //https://leetcode.com/problems/last-stone-weight/solutions/294956/javacpython-priority-queue-by-lee215-p4p3/
        //這個用的方法跟我一樣，不過有趣的是他的b-a是JAVA的比較器，C#沒有，所以她不用像我一樣Enqueue要同時提供priority
        //其他人方法都差不多用PriorityQueue沒再造輪子，有空再來造輪子看看
    }
}
