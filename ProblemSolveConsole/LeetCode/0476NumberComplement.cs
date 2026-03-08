using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0476NumberComplement
    {
        public int FindComplement(int num)
        {
            int result = 0;
            int pow = 0;
            while (num > 0)
            {
                if(!((num & 1) == 1))//0就補成1，如果原本是1就跳過
                {
                    result += (int)Math.Pow(2, pow);//應該是很常見的取bit方式:每位數乘2^n
                }
                
                num >>= 1;//digit進位
                pow++;//隨digit次方成長
            }

            return result;
        }

        //https://leetcode.com/problems/number-complement/solutions/96018/java-very-simple-code-and-self-evident-e-0gba/
        //這位用的原理跟我一樣是pow of 2，不過他用mask的方法達成補數 => 值得記住!
        //for example:
        //100110, its complement is 011001, the sum is 111111. So we only need get the min number large or equal to num, then do substraction
        // => 意思就是 a + b = c (111111) => 所以 c - b = a => 所以只要找到足夠位數的mask - num 就等於補數 (注意i >=num就要停下，不然剛好=時還執行可能會多找一位數)
        //https://leetcode.com/problems/number-complement/solutions/96017/3-line-1-line-c-by-lzl124631x-7n5q/
        //法1.這個也是用mask方式，不過他是使用num+mask倆倆補數互相對照
        //他先用num & mask == 0(mask是先補成全部bit1，找出所有bit & 時為0時的mask)，找出有值digit(num)和沒值digit(新mask)
        //再用~mask & ~num => ~mask會把沒值的部分變0，有值部分變像第一位那樣有值部分都是1，
        //這邊要解釋~是對32bit都做補數 => ~num沒值部分變1透過~mask和&抵銷成0，剩下的~num就成為答案補數，透過剩下的~mask篩選出有值部分的補數
        //法2. _builtin_clz(n)：算算前面有幾個 0 =>然後用 >> 推進成第一位那樣有值部分都是1 => 然後使用 ^ (XOR) => 其實跟第一位直接用全滿的bit-num是一樣效果

        //bit manipulate使用mask的多種變化真的要記住，不然太容易卡住
    }
}
