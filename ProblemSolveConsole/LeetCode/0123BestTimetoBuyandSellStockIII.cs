using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0123BestTimetoBuyandSellStockIII
    {
        public int MaxProfit(int[] prices)
        {
            //找出每次入場成本最低的點，才有可能獲得最大利潤(雖然可能不再最低點獲利最高，但跳過就有機會錯過，所以不能跳過，重點是定義)
            //定義:入場成本最低 = 留在手上的錢最高(已實現獲利 - 再入場成本)而非買入點最低            

            int out1 = 0;//第一次交易出場剩餘金額，最初是0
            int out2 = 0;//第二次交易出場剩餘金額，最初是0，所以後面>0才會更新
            int in1 = int.MinValue;//第一次交易入場剩餘金額，在index 0 時就會入場取代掉
            int in2 = int.MinValue;//第二次交易入場剩餘金額，在index 0 時就會入場取代掉

            for (int i = 0; i < prices.Length; i++)
            {
                //買賣不能發生在同一天，所以更新順序很重要 => in和 out都要用上一輪loop的資料來比對
                out2 = Math.Max(out2, in2 + prices[i]); //全部中最大值才留下 => dp和greedy的概念，就算後面有更好的第一次交易入場，只要第二次交易沒更好結果就不會更新
                in2 = Math.Max(in2, out1 - prices[i]); //隨著loop前進入場成本會一直變動，全部中留在手上的錢最高才是入場成本
                out1 = Math.Max(out1, in1 + prices[i]); //留下第一次交易最大獲利
                in1 = Math.Max(in1, -prices[i]); //確定入場成本最低才更新
            }

            return out2;
        }

        //這題跟0122BestTimetoBuyandSellStockII有個重要的差距
        //1.只能交易兩次 => 就要用greedy找出中途最好 => 0122因為能無限交易，所以遇到低點就買，高點就賣，把所有獲利都能收下，不需考慮，定義:入場成本最低 = 留在手上的錢最高(已實現獲利 - 再入場成本)而非買入點最低
        //2.同天不能同時交易賣買 => 買賣不能發生在同一天，所以更新順序很重要 => in和 out都要用上一輪loop的資料來比對
        //只要加上in3,out3 ...理論上可以輕易拓展到第三第四次交易上限 => array dp

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/solutions/39611/is-it-best-solution-with-on-o1-by-weijia-a7ru/?page=3
        //主要超這位的，重要觀念就是，定義:入場成本最低 = 留在手上的錢最高(已實現獲利 - 再入場成本)而非買入點最低，理解比較重要
        //大家最終方法都差不多這樣
    }
}
