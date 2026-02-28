using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1680ConcatenationofConsecutiveBinaryNumbers
    {
        public int ConcatenatedBinary(int n)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            List<char> all = new List<char>();

            for(int i = n; i > 0; i--)
            {
                int temp = i;
                while(temp > 0)
                {
                    all.Add((temp&1) == 1 ? '1' : '0');//組成反向整串bits
                    temp >>= 1;
                }
            }
            all.Reverse();
            string num = String.Join("",all); //組成整串bits
            int result = 0;//目前最前面的位數組成現階段result，配合mod一路推進到最後一位
            int modulo = (int)Math.Pow(10, 9) + 7;//每位數mod不會影響答案
            for (int i = 0; i< num.Length; i++)
            {
                result <<= 1;//位數推進
                result |= (all[i] - '0');//注意char轉int
                result %= modulo;//每位數mod
            }

            return result;
        }

        //https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/solutions/2612207/java-explained-in-detail-fast-on-solutio-77sd/
        //這位很好的表現了bit manipulation 和 math的兩種解法，比起我的方法他的更精簡快速，值得記住
        //1.方法二的clean code而已
        //2.=> 要記住
        //(1)他有用(i & (i - 1)) == 0計算進位，原因是每個n獨自佔bit，所以shift時要一次shift多位，他用binaryDigits做累進紀錄狀態 => 有點像Brian Kerninghan's Algorithm的另一個運用 => 效果在剛好 2 ^ k 時會剛好(i & (i - 1)) == 0 (要記住!!)
        //(2)搭配(1)他可以在loop n時直接處理整個新讀到n的int，不像我char只能一個個bit處理(mod他的方法也能明顯更少次) => 所以速度效果會有明顯差距
        //3.用/2、*2表現shift和binaryDigits，但沒有binaryDigits記錄狀態，他不能一次shift，所以會像我的方法一位位進位(但能mod比我少次)，效能不如方法2
        //https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/solutions/2612407/c-diagram-related-problems-by-kiranpalsi-cwfk/
        //這位方法其實跟第一位一樣，不過他又精簡一點他直接用popcount == 1 XD => 這枚解釋會有點難看懂，但就是2 ^ k 時會剛好bit == 1(要記住!!)，所以他就增加shift的len長度
        //另外ans = ((ans << len) % MOD + i) % MOD;(就是競賽mod的標準公式)效果跟((ans << len)+ i) % MOD 應該一樣，不過他應該能多防溢位，可以記一下

    }
}
