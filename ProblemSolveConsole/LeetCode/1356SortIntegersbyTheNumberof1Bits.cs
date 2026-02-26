using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1356SortIntegersbyTheNumberof1Bits
    {
#if false //舊方法，那個時候不會bit manipulation，意外用int /2 + math來解，其實蠻聰明的耶，雖然sort語法用得稀爛(要學一下怎麼寫Comparator...)，但單純看實作CountBits我覺得很有創意
            public int[] SortByBits(int[] arr)
            {
                int[][] record = new int[arr.Length][];
                for(int i = 0;i<record.Length ; i++)
                {
                    record[i] = new int[2] { CountBits(arr[i]), arr[i] };
                }

                return record.OrderBy(x => x[0]).ThenBy(x => x[1]).Select(x => x[1]).ToArray();
            }

            public int CountBits(int num)
            {
                int count = 0;
                while (num != 0)
                {
                    count += num % 2;//餘1代表這個位數有1
                    num = num / 2;
                }

                return count;
            }
#endif
        public int[] SortByBits(int[] arr)
        {
            //time:O(N) (每個元素PopCount) + O(N log N) (排序) + O(N) (toarray) = O(N log N)
            //space:O(N)
            //1.by bits order
            //2.by value order
            return arr.OrderBy(x => System.Numerics.BitOperations.PopCount((uint)x)).ThenBy(x=>x).ToArray();
        }

        //https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/solutions/2715364/simple-java-solution-easy-to-understand-1r0yv/
        //這個很有趣蠻值得學的，也蠻適合面試
        //1.因為value上限10001，所以把arr[i]+=bit*10001 => 組成成高位排序
        //2.因為是+=所以包含arr[i]的value，所以同bit也有低位排序
        //3.一次array sort就能完成高低為排序
        //4.%10001 把高低位編碼解回原本編碼
        //5.空間是 inplace會很有效率
        //=>這種「數值壓縮」的技巧在處理多層級排序、或是想在有限空間內存多個屬性時非常好用
        //https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/solutions/4224485/9658-built-in-functions-brian-kerninghan-wnyp/
        //這方法基本跟我一樣，不過是手刻的
        //https://leetcode.com/problems/sort-integers-by-the-number-of-1-bits/solutions/3986287/sort-integers-by-the-number-of-1-bits-by-h9v1/
        //這是官方的，索然沒有有趣的解法，但很詳細的教學了bit maniplation
        //1.和我一樣用API的解法
        //2.基礎用mask確認bit數的方法 num & mask 判斷、num ^= mask判斷後清理、mask <<= 1準備下個判斷
        //3.Brian Kerninghan's Algorithm => num &= (num - 1)直到num=0 => 等同bit數 => 這是一個值得背起來的工具之一，因為異動也是非常小
    }
}
