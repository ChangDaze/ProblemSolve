using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating
    {
        public int MinFlips(string s)
        {
            //Time complexity:O(n) > 2n
            //Space complexity:O(1)

            int len = s.Length;
            int zeroFirst = 0;//match
            int oneFirst = 0;
            
            //只會有兩種 (1)0開頭 (2)1開頭
            //計算match次數(不是type2翻的次數)
            for (int i = 0; i < len; i++)
            {
                if(i%2 == 0)
                {
                    if (s[i] == '0')
                    {
                        zeroFirst++;
                    }
                    else
                    {
                        oneFirst++;
                    }
                }
                else
                {
                    if (s[i] == '0')
                    {
                        oneFirst++;                        
                    }
                    else
                    {
                        zeroFirst++;
                    }
                }
            }

            int max = Math.Max(zeroFirst, oneFirst);
            bool lastEven = (len - 1)%2 == 0;

            //計算對目前結果執行type1
            for (int i = 0; i < len; i++)//指到的位置從0變到Last
            {
                //原本要翻的會變不用翻的，不用翻的會便要翻的
                zeroFirst = len - zeroFirst; 
                oneFirst = len - oneFirst;

                //因為前一步有做len - x的動作，所以默認s[i]在index = -1
                //處理s[i]位在index=-1時被移除時的變化 > 原本要加的不用加了要扣回
                if (s[i] == '1')// index 0 to index -1, even to cur [odd]
                {
                    zeroFirst--; //zeroFirst index=-1,odd,時是'1'match               
                }
                else
                {
                    oneFirst--; //oneFirst index=-1,odd時,是'0'match
                }

                //處理s[i]被移到last的變化，match就+1
                if (lastEven)
                {
                    if (s[i] == '0')
                    {
                        zeroFirst++;
                    }
                    else
                    {
                        oneFirst++;
                    }
                }
                else
                {
                    if (s[i] == '0')
                    {
                        oneFirst++;
                    }
                    else
                    {
                        zeroFirst++;
                    }
                }

                max = Math.Max(Math.Max(max,zeroFirst), oneFirst); //計算最大match
            }

            return len - max;//不match的就是type2要翻的次數
        }

        //https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/solutions/1253874/c-solution-sliding-window-on-time-o1-spa-mykb/?envType=daily-question&envId=2026-03-07
        //這位code蠻有趣的，法一和法二只差在有沒有把s1,s2存起來而已
        //重點是他的for迴圈效果是把我兩個for迴圈合起來的效果(他for長度也是2n)，他有帶入sliding windows的概念
        //if(i % 2 != s[i % n]) => 這種的2n中每次都會跑 => 這個自帶type2判斷，但在i >= n時會自帶type1 add last 效果
        //if((i - n) % 2 != s[i - n]) => 這種的只有i >= n才會跑 會有type1 remove first 效果
        //if(i >= n - 1) 這個判斷則能減少比較判斷，多少應該會加點速
        //https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/solutions/7631262/solution-by-la_castille-yiau/?envType=daily-question&envId=2026-03-07
        //這個解法本質跟第一位一樣，不過他混入的bit 而已
        //int[2] op => 拿來存0和1開頭的計數而已
        //然後他odd和even判斷是用bit & 1 => 還蠻讚的，理論上說不定比%快
        //又然後他把別人處理0和1的2行判斷濃縮成1行，說不定又更快

        //這題很適合sliding window + cycle shift概念，可以記一下

    }
}
