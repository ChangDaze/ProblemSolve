using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0264UglyNumberII
    {
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
    }
}
