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

                //計算過往最佳結果 + 當前持有(一定是>=0，因為買賣都能選擇，0是因為可能價格相等)
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
    }
}
