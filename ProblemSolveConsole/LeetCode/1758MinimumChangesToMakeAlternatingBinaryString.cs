using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1758MinimumChangesToMakeAlternatingBinaryString
    {
        public int MinOperations(string s)
        {
            //解題方式就是Alternating Binary String只有兩種開頭 0 開頭 或 1 開頭，解兩種所需要的次數即可
            //下面兩個ToCharArray用一個for取代可能比較好
            char[] firstZero = s.ToCharArray(); //偶數0 奇數1 正確
            int firstZeroCount = 0;
            if (firstZero[0] != '0') {
                firstZero[0] = '0';
                firstZeroCount++; //有轉換就計數
            }
            char[] firstOne = s.ToCharArray(); //偶數1 奇數0 正確
            int firstOneCount = 0;
            if (firstOne[0] != '1') {
                firstOne[0] = '1';
                firstOneCount++; //有轉換就計數
            }
            
            for (int i = 1; i < s.Length; i++)
            {
                if(firstZero[i] == firstZero[i - 1])
                {
                    firstZero[i] = firstZero[i - 1] == '1' ? '0' : '1';//有轉換就計數
                    firstZeroCount++;
                }

                if (firstOne[i] == firstOne[i - 1])
                {
                    firstOne[i] = firstOne[i - 1] == '1' ? '0' : '1';//有轉換就計數
                    firstOneCount++;
                }
            }

            return Math.Min(firstZeroCount, firstOneCount);
        }

        //https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/solutions/1064511/javacpython-easy-and-concise-by-lee215-k2j9/
        //這個應該是最佳解，主要兩個方法
        //1.index % 2 會變 0101這樣，他去對s 和index % 2的差異總數就是0101的需轉換次數 => 這只是單純不同方法，用其他方法也不會比較慢 => 這個方法space是O(1)喔
        //2.1010只是s.length - res => 這才是重點XD => 像我上面做了一堆其實很多都不必要
        //https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/solutions/4209587/minimum-changes-to-make-alternating-bina-hyyx/
        //這是官方解法，有兩個
        //法一只是第一位方法不用2.，法二就跟第一位一樣
        //https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/solutions/7625775/draft-by-la_castille-z9kb/
        //像這位方法其實跟第一位一樣，不過他檢查0101的方式是用index XOR  s[i] => 其實也是檢查奇偶數 => 因為奇數第一個bit一定是1偶數一定是0
    }
}
