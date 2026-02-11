using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1354ConstructTargetArrayWithMultipleSums
    {
        public bool IsPossible(int[] target)
        {
            //time :O(nlog n + logM*log n) => nlog n 是enqueue、logM是「歐幾里得演算法（輾轉相除法）」 % 的每次計算複雜度、log n是max查詢複雜度
            //space : O(n) => pq count == target

            if (target.Length == 1) return target[0] == 1; // 單個元素必須是 1

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            long totalSum = 0;
            foreach (int num in target)
            {
                pq.Enqueue(num, -num);
                totalSum += num;
            }

            while (pq.Peek() > 1)
            {
                PriorityQueue<int, int> temp = new PriorityQueue<int, int>();
                long max = pq.Dequeue();
                long restSum = totalSum - max;

                // 特判：當陣列只有兩個元素且其中一個是 1，不然ex [1,2]跑後面會錯
                if (restSum == 1) return true;
                //=>if (target.Length == 2 && (target[0] == 1 || target[1] == 1)) return true; 這段不能用，因為我們用heap沒在控制target，
                //所以還是if (target.Length == 2 && restSum == 1) return true; 精簡後其實就是上面那個

                // 相等於 
                /*
                n > 2 時，restSum 永遠不會是 1？
                當 n = 3 時，就算其他兩個保底為 1 => 不然在進行過程中就被false掉或題目不符合規則1 <= target[i] <= 109
                restSum 也至少是 2
                只要人數n增加，restSum 的保底數值 n - 1
                所以，如果要讓 restSum 等於 1
                這代表人數必須剛好是 2 
                */


                // Guard Clauses (衛句)：
                // 1. restSum == 0 預防 n=1 或無其他元素時產生的「除以零」崩潰。
                // 2. max <= restSum 攔截不合法的組合
                //    代表回推後的數值會變為 0 或負值，違反「所有數字保底為 1」的規則。
                if (restSum == 0 || max <= restSum)
                {
                    return false;
                }

                long next = max % restSum; //特例 %1必定 = 0

                if (next == 0) //因為%所以一定>=0
                {
                    return false;
                }

                totalSum = restSum + next;
                pq.Enqueue((int)next, (int)-next);
            }

            return true;
            //return totalSum == target.Length; 
        }

        //說直接一點，那些我寫註解的Guard Clauses，我應該是永遠都想不到，難怪說hard有些太超過所需
    }
}
