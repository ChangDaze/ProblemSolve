using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3666MinimumOperationstoEqualizeBinaryString
    {
        public int MinOperations(string s, int k)
        {
            //c = 此次flip '0'的數量
            //k-c = 此次flip '1'的數量
            //0 <= c <= min(m,k)
            //k−c <= n−m => n-m就是s中目前'1'的數量
            //max(k−n+m,0) <= c <= min(m,k)
            //c1 = max(k−n+m,0) , c2 = min(m,k) => c1是c最小值，c2是c最大值 => [c1, c2] 間都是下一步可以做的選擇
            //m+k−2c,c∈[c1, c2] => m+k−2c是operation過後'0'的數量 => m (原本'0') - c (flip '0') - (k-c) (flip '1') = m+k−2c
            //m+k會影響結果是奇數偶數，-2c必定是偶數所以不影響 => 才有List<SortedSet<int>>(); //分成奇偶兩份 => 在選擇下個m+k−2c時因為已知m+k決定奇數偶數，所以分成兩組避免找出view時還要判斷奇數偶數
            int n = s.Length; //s的長度
            int m = 0; //s中目前'0'的數量
            int[] dist = new int[n + 1]; //'0'在s中可能從 0 ~ n 共 n + 1 種 => 紀錄BFS「第一次」踩到某個狀態時的最短路徑
            for (int i = 0; i < n; i++)//更新default值
            {
                dist[i] = int.MaxValue;
            }

            List<SortedSet<int>> nodeSets = new List<SortedSet<int>>(); //分成奇偶兩份
            nodeSets.Add(new SortedSet<int>());//使用SortedSet是因為GetViewBetween可以較容易取出view(range)配合[c1, c2]變化計算
            nodeSets.Add(new SortedSet<int>());
            for(int i = 0;i <= n;i++)
            {
                nodeSets[i%2].Add(i);//放入BFS的可能性
                if(i < n && s[i] == '0')//順便計算m
                {
                    m++;
                }
            }

            Queue<int> q = new Queue<int>();//放入queue一個個處理BFS的狀態紀錄 => queue清空時SortedSet還有剩的話也代表那幾個狀態永遠不會到達，已到達的dist[]則開始cycle => 跟DP不一樣的地方
            q.Enqueue(m);//一開始有
            dist[m] = 0; //0 step的起始值，記錄最早到達此狀態的step數
            nodeSets[m%2].Remove(m);//從對應SortedSet移除到達過的狀態
            while (q.Count > 0)
            {
                m = q.Dequeue();
                int c1 = Math.Max(k - n + m, 0);
                int c2 = Math.Min(m, k);
                int lnode = m + k - 2 * c2;//計算出下個狀態的range
                int rnode = m + k - 2 * c1;

                SortedSet<int> nodeSet = nodeSets[lnode%2];//取出對應SortedSet
                List<int> toRemove = new List<int>();//因為view是原資料所以會另做一個memory做後續處理
                SortedSet<int> view = nodeSet.GetViewBetween(lnode, rnode);//取view
                //GetViewBetween =「取得介於兩值之間的視圖」
                //所謂的 「視圖 (View)」，「並沒有複製一份新的數字出來」。它就像是一面鏡子，或者是資料庫裡的 View，你透過它看到的，依然是原本那棵樹（nodeSet）上的同一批資料

                //沒用toRemove間接處理會跳錯
                //System.InvalidOperationException : Collection was modified after the enumerator was instantiated.
                foreach (int val in view) 
                {
                    toRemove.Add(val);
                }

                foreach (int m2 in toRemove)
                {
                    dist[m2] = dist[m] + 1;//記錄最早到達此狀態的step數
                    q.Enqueue(m2);//下個BFS的起始狀態
                    nodeSet.Remove(m2);//從對應SortedSet移除到達過的狀態
                }
            }

            return dist[0] == int.MaxValue ? -1 : dist[0]; //查看有沒有到達過'0'數量為0的時候
        }

        //這是是披著 DP 狀態外衣的 BFS，精確地說，這叫作 「狀態空間上的 BFS(State-Space BFS)」。
        //1.BFS 利用 Queue 進行「同心圓式、一層一層向外擴張」的探索
        //2.當每一步的代價都一樣時，BFS ，「第一次」踩到某個狀態時，絕對就是最短路徑（最少步數)
        //3.DP 要求狀態轉移必須是有向無環圖 (DAG)」。狀態必須有明確的先後順序，不能繞圈，這題可以把字元從 '0' 翻成 '1'，但下一步也能把它從 '1' 翻回 '0'！ 狀態是可以互相往返的，所以不算DP

        //Time complexity: O(nlogn)
        //Each ordered set operation takes O(logn) time.Since each state is inserted and removed at most once, the total time complexity is O(nlogn).
        //Space complexity: O(n)

        //https://leetcode.com/problems/minimum-operations-to-equalize-binary-string/submissions/1933017005/
        //這是官方解法，理解後期時說明得很清楚
        //這題其時我完全沒想法所以直接看解答，這題其實就是純MATH了= =，雖然可能是不值得解的題目，但裡面的解法非常值得記住
        //因為理解很花時間，所以只看官方解法，等未來的我有能力再自己解，或分析其他解法

    }
}
