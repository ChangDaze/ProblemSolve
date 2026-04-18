using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3296MinimumNumberofSecondstoMakeMountainHeightZero
    {
        public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
        {
            //Time complexity:O((n + h)logn) => 建pq nlogn + moutaint作業 hlogn + 找max nlogn
            //Space complexity:O(n) => pq大小

            /*
            To reduce the height of the mountain by 2, it takes workerTimes[i] + workerTimes[i] * 2 seconds, and so on.
            => 完成第一輪需要一單位，完成第二輪需要再兩單位，完成第三輪需要再三單位 => 三輪共六單位
            */

            //用tuple可能可以有比較好的閱讀性，用index有點錯亂
            PriorityQueue<long[], long> pq = new PriorityQueue<long[], long>();
            //[cost, futurecount, used], needsecond
            //[一單位耗時, 第幾輪, 完成這輪後總共過的時間], 下一輪完成總共過的時間

            //因為是同步執行，所以先完成一輪的會先更新紀錄 =>
            //紀錄 
            //完成第幾輪 => 計算下一輪完成總共過的時間用
            //完成這輪後總共過的時間 => 紀錄所有工程完成的耗時用 => 可能有機會共用簡化? 要想一下
            //下一輪完成總共過的時間 => pq權重

            //O(nlogn)
            foreach (int worker in workerTimes)
            {
                pq.Enqueue([worker, 1, 0], worker);                
            }

            //O(hlogn)
            //一權重執行工作直到 mountainHeight = 0
            while (mountainHeight > 0)
            {
                long[] workerInfo = pq.Dequeue();
                mountainHeight -= 1;
                workerInfo[2] += workerInfo[0] * workerInfo[1]; 
                workerInfo[1]++;
                pq.Enqueue(workerInfo, workerInfo[2] + workerInfo[0] * workerInfo[1]);
            }

            //找出實際總耗時
            long result = 0;
            //O(nlogn)
            while (pq.Count > 0)
            {
                long[] workerInfo = pq.Dequeue();
                if (workerInfo[2] > result)
                {
                    result = workerInfo[2];
                }
            }

            return result;
        }

        //https://leetcode.com/problems/minimum-number-of-seconds-to-make-mountain-height-zero/solutions/7644480/solution-by-la_castille-k0q1/?envType=daily-question&envId=2026-03-13
        //哇!這個人的解釋寫的超好，用法是binary search + 等差級數公式而已，相比我的發法，他的方法在數字大的時候超快，我的只能1秒秒減，我應該也要想到等差級數的
        //然後重點是這句 We take the floor value because the mountain height is an integer.
        //他把等差級數轉變成h的目的就是要處理此秒"正在工作中"的工人進度尾差 => 公式表現得很明顯但程式是用整數轉型 => 所以要仔細看他的說明
        //值得學習
        //https://leetcode.com/problems/minimum-number-of-seconds-to-make-mountain-height-zero/solutions/5818294/min-heap-vs-binary-search-math-by-votrub-ytkg/?envType=daily-question&envId=2026-03-13
        //這位有用第一位的方法也有我的方法
        //https://leetcode.com/problems/minimum-number-of-seconds-to-make-mountain-height-zero/solutions/5818267/binary-search-approach-in-java-by-shubha-zfuj/?envType=daily-question&envId=2026-03-13
        //這位跟第一為方法一樣，不過他提醒了我一個點，就算不用像第一位用h直接算公式也有土炮的辦法
        //直接用time binary search + true/false即可 => 然後binary search直到最低可以完成的秒數 => 因為true/false對的也是高度也有轉成整數所以理論上也不會有尾差問題 => 比較像第一位公式的展開而已 效果應該差不多
        //這位的canReduceMountain雖然又套了層binary search但應該可以不用，可以直接用梯形公式foreach就好 => 問AI的

        //雖然pq概念不錯但在height很高時就不夠看，應該要有更擴充的看法，梯形公式+binarysearch逼近法一定要記住
    }
}
