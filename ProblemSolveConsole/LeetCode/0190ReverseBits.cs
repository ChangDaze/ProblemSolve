using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0190ReverseBits
    {
        public int ReverseBits(int n)
        {
            //Time complexity:O(1) 因為 & | >> << 都是 cpu級運算所以可以算做O(n)
            //Space complexity:O(1)

            //題目是要bit前後翻轉，不是單純補數，補數可以直接用~

            //答案沒管實際值得sign 所以32個bit都是數字可以直接翻轉
            //用bit manipulation

            int result = 0;

            for (int i = 0; i < 32; i++) //對n的32位數由右至左往result加入即可
            {
                result <<= 1; //1.讓出一格0

                int temp = (n & 1);//2.取得n目前最右邊的一位數，不是0就是1

                n >>= 1;//3.n right shift 準備下一輪的數

                result |= temp; //4.將取得的一位數補入1.空出的位置

                //1~4做32次就會將n的32個bit倒轉至result中
            }
            
            return result;
        }
        
    }
    //最簡單的暴力解應該是轉成bit string convert有提供語法糖，但用這個因為運算層級比較高，所以反而不如bit manipulation
    //ex:string binaryFull = Convert.ToString(n, 2).PadLeft(32, '0');

    //https://leetcode.com/problems/reverse-bits/solutions/54738/sharing-my-2ms-java-solution-with-explan-uzih/
    //這位方法類似，只是他把|=改用bool判斷是否為true而已
    //https://leetcode.com/problems/reverse-bits/solutions/54760/my-3ms-pure-c-solution-by-xcv58-ctym/
    //這位方法也一樣

    //https://leetcode.com/problems/reverse-bits/solutions/54916/whats-with-the-follow-up-by-sergeytachen-lcj3/
    //這位是符合follow up 的解法，暫時無法直接理解，後面有用到再說
    //簡單講是用mask遮住部分的數，再用||組合造成兩兩、四四、八八交換，最終就會有resverse效果 => 這應該篹是有公式的以後能背
    //>>>只是unsign right shift避免程式自動補sign
    //follow up 的部分就是先把reverse全算好用map的，66536是16個bit，應該單純是32bit要存長度太長，然後n拆兩個16bit+mask方式查表組成32bit結果這樣 => 所以以此類推也能只存8或4bit，只是查表時要拆
    //以這個來說我的方法就可能不適合follow up 但真的要有差距，可能較算量要超大才有感覺，但我的方法就相對容易懂bit manipulation方式
}
