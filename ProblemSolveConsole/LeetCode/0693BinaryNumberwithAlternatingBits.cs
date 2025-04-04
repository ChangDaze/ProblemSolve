using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolveConsole.LeetCode
{
    public class _0693BinaryNumberwithAlternatingBits
    {
        public bool HasAlternatingBits(int n)
        {
            //gpt給了3個方法
            //1 Convert.ToString(num, 2) => string
            //2 new BitArray(BitConverter.GetBytes(number)); => array
            //3 binary += ((number >> i) & 1) == 1 ? "1" : "0"; => 位運算
            int temp = n;
            bool flag = (temp & 1) == 1;
            temp = temp >> 1;

            while (temp > 0) //等於0時代表每個位數都走過了
            {
                if(((temp & 1) == 1) == flag)
                {
                    return false;
                }

                flag = !flag;
                temp = temp >> 1;
            }

            return true;
        }

        //這位的很有趣，用了一些數學觀念確保交錯的情況，理論上應該是O(1)
        //https://leetcode.com/problems/binary-number-with-alternating-bits/solutions/113933/java-super-simple-explanation-with-inline-example/
        //這位也是，向他第一個解法也有點像上一位一樣去做個mask來過濾，但他提出更多方法，有空可以看看，但有點多就沒細看
        //https://leetcode.com/problems/binary-number-with-alternating-bits/solutions/108427/oneliners-c-java-ruby-python/
    }
}
