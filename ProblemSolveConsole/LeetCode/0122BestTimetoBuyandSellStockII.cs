using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0122BestTimetoBuyandSellStockII
    {
#if false //寫錯了..不小心寫成可多可空的版本
        public int MaxProfit(int[] prices)
        {
            //一樣使用Kadane's Algorithm
            //紀錄
            //1.過往最佳結果 + 當前持有 VS 當下最佳值 => DP
            //2.過往最小值 > 做當下最佳值
            //3.過往最大值 > 做當下最佳值

            int smallest = prices[0];
            int biggest = prices[0];

            int maxProfit = 0;
            int holdingSmallest = prices[0];
            int holdingBiggest = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                //計算當下值最佳
                int cur = Math.Max(prices[i] - smallest, biggest - prices[i]);

                //計算過往最佳結果 + 當前持有(一定是>=0，因為買賣都能選擇，0是因為可能價格相等)
                maxProfit = maxProfit + Math.Max(prices[i] - holdingSmallest, holdingBiggest - prices[i]); 

                //比較並更新holding
                if (cur > maxProfit)
                {
                    maxProfit = cur;
                    //交易後holding只能是當下價格
                    holdingSmallest = prices[i];
                    holdingBiggest = prices[i];
                }
                else
                {
                    //沒交易可以選擇最佳holding > 這裡可能要參考下面後來改的修正，因為沒交易才能選擇過往prices[i]當hoding
                    if (prices[i] < holdingSmallest)
                    {
                        holdingSmallest = prices[i];
                    }

                    if (prices[i] > holdingBiggest)
                    {
                        holdingBiggest = prices[i];
                    }
                }

                //更新最小最大值
                if (prices[i] < smallest)
                {
                    smallest = prices[i];
                }

                if (prices[i] > biggest)
                {
                    biggest = prices[i];
                }
            }

            return maxProfit;
        }
#endif
        public int MaxProfit(int[] prices)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            //一樣使用Kadane's Algorithm
            //紀錄
            //1.過往最佳結果 + 當前持有 VS 當下最佳值 => DP
            //2.過往最小值 > 做當下最佳值

            int smallest = prices[0];

            int maxProfit = 0;
            int holdingSmallest = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                //計算當下值最佳
                int cur = Math.Max(prices[i] - smallest, 0);

                //計算過往最佳結果 + 當前持有(一定是>=0，因為買賣能同天，0是因為可能價格相等)
                int holdingDiff = prices[i] - holdingSmallest;
                maxProfit = maxProfit + Math.Max(holdingDiff, 0);

                //比較並更新holding，交易後holding只能是當下價格
                if (cur > maxProfit)
                {
                    //跟過往最小值交易
                    maxProfit = cur;
                    holdingSmallest = prices[i];
                }
                else 
                {
                    if (
                        (holdingDiff <= 0 && prices[i] < holdingSmallest) ||//沒交易可以選擇最佳holding
                        holdingDiff > 0 //holding當下有交易
                    )
                    {
                        
                        holdingSmallest = prices[i];
                    }

                    //只有holdingDiff <= 0 && prices[i] >= holdingSmallest 時，可以選擇過往的prices[i]當holdingSmallest
                }


                //更新最小值
                if (prices[i] < smallest)
                {
                    smallest = prices[i];
                }
            }

            return maxProfit;
        }

        //我的方法雖然是Kadane's Algorithm，但另一個角度來說我好像弄得太複雜了
        //因為在無線交易次數底下且當天能再買進，還沒手續費，我只要每個prices[i] < prices[i+1]都交易，就必定可以收穫全部收益XD
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solutions/208241/explanation-for-the-dummy-like-me-by-chi-5v10/?page=3
        //這位就是抓住全部收益的方法，如果sell = prices[i+1]; 然後多一次i++後，甚至可以不用第三個while，不過好像就不是dp，只是單純array處理
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solutions/803206/pythonjsjavagoc-on-by-dp-greedy-visualiz-bzy0/?page=3
        //哇喔，這位是從概念上對我方法優化的降維打擊，是從概念上DP，就是理解
        //either keep hold, or buy in stock today at stock price
        //hold = Math.max(prevHold, prevNotHold - stockPrice);
        // either keep not-hold, or sell out stock today at stock price
        //notHold = Math.max(prevNotHold, prevHold + stockPrice);
        // maximum profit must be in not-hold state => 最後一定收回錢賺最多
        //跟0123BestTimetoBuyandSellStockIII，理解到意思就會形成最佳解...

        //但Kadane's Algorithm還是在這能用啦 => 不過我一直無腦多算cur，所以會明顯比別人多慢一節
        //第一位方法用的人最多(最單純)，但我覺得第二位的方法最聰明

    }
}
