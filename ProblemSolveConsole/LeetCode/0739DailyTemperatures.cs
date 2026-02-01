using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0739DailyTemperatures
    {
#if false //舊方法，這個好像是以前不會用monotonic stack時的做法，像是硬套stack的array解法XD，雖然有隱含monotonic stack概念但很難看懂，主要就是從後往前，然後 留下 [最近最大的排列monotonic stack] => 有點難懂XD
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] reslut = new int[temperatures.Length];

        Stack<int> indexsMonotonicStack = new Stack<int>();

        for (int i = temperatures.Length - 1; i >= 0; i--)
        {
            int targetIndex = -1;

            while(indexsMonotonicStack.Count > 0)
            {
                if(temperatures[i] < temperatures[indexsMonotonicStack.Peek()])
                {
                    targetIndex = indexsMonotonicStack.Peek();
                    break;
                }
                indexsMonotonicStack.Pop();
            }

            if (targetIndex != -1)
                reslut[i] = targetIndex - i;
            else
                reslut[i] = 0;

            indexsMonotonicStack.Push(i);
        }

        return reslut;
    }
#endif
        public int[] DailyTemperatures(int[] temperatures)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            Stack<int> stack = new Stack<int>(); //存放還未遇到符合條件的index，預計是單調遞減
            int[] result = new int[temperatures.Length]; //預設值為0

            for(int i = 0; i < temperatures.Length; i++)
            {
                while(stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i]) //temperatures間比較
                {
                    int index = stack.Pop();
                    result[index] = i - index;
                }
                stack.Push(i);
            }

            return result;
        }

        //這題雖然是medium但還不如1475FinalPricesWithaSpecialDiscountinaShop簡單，解題方式完全一樣
        //用的也是monotonic stack唯一要注意的是temperatures、result兩個arrray在用的時候要注意不要用錯個，錯蠻多次的

        //https://leetcode.com/problems/daily-temperatures/solutions/1574806/c-easy-standard-sol-intuitive-approach-w-vlb9/
        //舊方法可能是超這位的，用我的方法可能比較容易懂monotonic stack
        //https://leetcode.com/problems/daily-temperatures/solutions/4651723/easy-stack-friendly-explained-by-prodoni-dlpa/
        //https://leetcode.com/problems/daily-temperatures/solutions/109832/java-easy-ac-solution-with-stack-by-luck-njm3/
        //這兩位方法就跟我一樣

        //這樣看來經典的monotonic stack最佳解法應該都一致
    }
}
