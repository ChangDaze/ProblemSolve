using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0188BestTimetoBuyandSellStockIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            //Time complexity:O(kn)
            //Space complexity:O(k)
            int[] ins = new int[k];
            int[] outs = new int[k];

            for(int i = 0; i < ins.Length; i++) //更新入場值
            {
                ins[i] = int.MinValue;
            }

            for(int i =0; i < prices.Length; i++)
            {
                for(int j = k-1; j > 0; j--) //index 0 沒有 out[-1] 可用，所以>0就停下
                {
                    outs[j] = Math.Max(outs[j], ins[j] + prices[i]);
                    ins[j] = Math.Max(ins[j], outs[j - 1] - prices[i] );
                }
                outs[0] = Math.Max(outs[0], ins[0] + prices[i]); 
                ins[0] = Math.Max(ins[0], - prices[i]); //index 0 沒有 out[-1] 可用 > 結果其實不用，用k+1陣列就好 => 因為k是次數不是index，所以不容易受index從0開始的影響
            }

            return outs[k-1] <= 0 ? outs.Max() : outs[k - 1]; //防止沒交易到k次 > 結果其實不用，> 0 利潤會往上複製
        }

        //直接從0123BestTimetoBuyandSellStockIII從2延伸成n次交易
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/solutions/54113/a-concise-dp-solution-in-java-by-jinrf-fivd/
        //這個人算法其實一樣，只是像row column互調一樣，他算完一次交易的才處理二次交易，我的是k個交易一起跑
        //然後大家其實有用if (k >= len / 2) return quickSolve(prices); => 因為要完成k次買賣其實需要2k天，所以天數不夠題目就退化成0122BestTimetoBuyandSellStockII > O(n)，可以有效剪枝掉O(kn)
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/solutions/54117/clean-java-dp-solution-with-comment-by-j-6lsq/
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/solutions/54125/very-understandable-solution-by-reusing-llpld/
        //其他人方法都差不多
        //沒想到這題是0122BestTimetoBuyandSellStockII + 0123BestTimetoBuyandSellStockIII 的融合體XD，我因為沒剪枝和多判斷outs[k-1] <= 0 ? outs.Max() : outs[k - 1]導致速度偏慢
    }
}
