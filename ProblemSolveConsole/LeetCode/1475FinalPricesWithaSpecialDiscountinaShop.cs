using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1475FinalPricesWithaSpecialDiscountinaShop
    {
#if false //舊方法
            public int[] FinalPrices(int[] prices)
            {
                int[] result = new int[prices.Length];
                Stack<int> stack = new Stack<int>();
                for(int i = 0;i<prices.Length ;i++)
                {
                    while(stack.Count> 0 && prices[stack.Peek()]>= prices[i])                    
                        result[stack.Peek()] = prices[stack.Pop()] - prices[i];                    
                    stack.Push(i);
                }

                if (stack.Count == prices.Length) 
                    return prices;
                else if(stack.Count> 0)
                {
                    while (stack.Count() > 0)
                        result[stack.Peek()] = prices[stack.Pop()];
                } 

                return result;
            }
#endif
        public int[] FinalPrices(int[] prices)
        {
            Stack<int> stack = new Stack<int>(); //加入還未處理的stack

            int[] result = new int[prices.Length]; //因為1 <= prices[i]，所以預設值0

            //預計stack會存入單調遞增，直到有較小值
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = prices[i]; //先填入初始價格，後續符合條件再更新
                while(stack.Count > 0 && prices[stack.Peek()] >= prices[i]) //符合條件遇到小於等於，開始discount，直到為空或不再符合條件
                {
                    int discountIndex = stack.Pop(); //不用特別存變數
                    result[discountIndex] -= prices[i]; //result更新discount
                }
                stack.Push(i); //新值加入等待discount
            }

            return result;
        }

        //經典Monotonic stack問題，不過其他人方法其實都一樣，不知到為啥我的跑特別慢(複製跑很快的人的也一樣...)
        //https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/solutions/685390/javacpython-stack-one-pass-by-lee215-4nb3/
        //這位方法一樣，不過他pop沒特別存變數
        //https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/solutions/6154427/final-prices-with-a-special-discount-in-s7t8g/
        //官方解法
        //1. 兩層for 暴力解
        //2. monotonic stack
        //因為是經典題型，所以也沒有其他特別解法
    }
}
