using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0007ReverseInteger
    {
        public int Reverse(int x)
        {
            //Time : O(log x) => 每次/10就是log10
            //Space : O(1)

            int sign = 1;

            if(x < 0)
            {
                sign = -1;
                x = x * -1; //統一x 的處理
            }
            
            int result = 0;

            while (x > 0)
            {
                int temp = x % 10;
                if (result > (int.MaxValue - temp) / 10) //判斷溢位 => 這個簡單方法也應該是常用工具之一
                {
                    return 0;
                }
                result = result * 10 + temp;
                x /= 10;

                
            }

            if(result == int.MaxValue && sign == -1) //int 範圍 -2^31 <= x <= 2^31 - 1
            {
                return 0;
            }

            return sign * result;
        }

        //https://leetcode.com/problems/reverse-integer/solutions/4060/my-accepted-15-lines-of-code-for-java-by-3wd4/
        //意外其實大家都用最樸實的方法臨時計算臨界判斷溢為，我還以為要用bit之類的
        //https://leetcode.com/problems/reverse-integer/solutions/5428589/video-using-remainder-by-niits-dhbu/
        //這位是直接轉用string工具reverse後用intparse，雖然怪怪的，但用string解是個方法要記住
        //https://leetcode.com/problems/reverse-integer/solutions/5572539/easy-and-simple-c-approach-beats-100-beg-ygc9/
        //這個方法跟第一位一樣，但比較粗糙，問AI有確認在+digit時確實可能溢位，所以本質上不安全
    }
}
