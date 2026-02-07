using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2073TimeNeededtoBuyTickets
    {
#if false // 舊方法，這個方法雖然是O(n^2)但其中觀念蠻值得學的 (1)queue.ElementAt(k)有這個語法糖存在 (2)if (k > 0) k--; else k = queue.Count - 1;，使用自製pointer製作queue的target狀態追蹤器 XD
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            int result = 0;
            Queue<int> queue = new Queue<int>(tickets);
            while (queue.ElementAt(k) != 0)
            {
                int temp = queue.Dequeue();
                if (temp > 0)
                {
                    result += 1;
                    temp -= 1;
                    queue.Enqueue(temp);
                }

                if (k > 0)
                    k--;
                else
                    k = queue.Count - 1;
            }
            return result;
        }
#endif
        public int TimeRequiredToBuy(int[] tickets, int k)
        {

            //Time complexity:O(n)
            //Space complexity:O(1)
            int target = tickets[k];
            int result = 0;
            for (int i = 0; i < tickets.Length; i++)
            {
                if (i < k) 
                {
                    if(tickets[i] <= target)//每個都會輪過，所以k之前且次數<=的一定會被輪完，不然就只輪target次
                    {
                        result += tickets[i];
                    }
                    else
                    {
                        result += target;
                    }
                }
                else if (i > k) //每個都會輪過，所以k之後且次數"<"(只有tickets[i]小於)的一定會被輪完，不然就只輪"target-1"次
                {
                    if (tickets[i] < target)
                    {
                        result += tickets[i];
                    }
                    else
                    {
                        result += (target-1); //注意要括號，忘掉答案會細微不同，難debug
                    }
                }
                else
                {
                    result += target; //k自己一定會輪完
                }
            }

            return result;
        }

        //這題原本要練習queue，但發現要用queue實作結構變好多不太必要的複雜，只是單純simulate，所以就放棄
        //但queue的題目給了一個很印象深刻的觀念，就是每個index都會被一次次輪過，把這個觀念整合進解題，才有上面O(n)解法喔

        //https://leetcode.com/problems/time-needed-to-buy-tickets/solutions/4995356/9744easy-solutionwith-explanation-by-mra-ofg7/
        //這個方法跟我一樣，但精簡超多，值得一學XDD
        //https://leetcode.com/problems/time-needed-to-buy-tickets/solutions/1576932/c-one-pass-by-lzl124631x-j5w2/
        //法一是暴力解，仔細想想queue就是暴力解XD
        //法二方法也一樣，但更精簡成oneline，但我比較喜歡上一位的精簡方式
        //https://leetcode.com/problems/time-needed-to-buy-tickets/solutions/4994472/time-needed-to-buy-tickets-by-leetcode-3bqz/
        //這是官方解
        //(1)這個展示了queue的另一種用法，使用tickets本身array+queue index，效果跟monotonic stack很像，要記住這個用法
        //(2)法一的不用queue的暴力解而已
        //(3)跟大家一樣的O(n)解法
    }
}
