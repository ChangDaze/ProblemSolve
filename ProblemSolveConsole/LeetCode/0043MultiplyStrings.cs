using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolveConsole.LeetCode
{
    public class _0043MultiplyStrings
    {
#if false //失敗嘗試
        public string Multiply(string num1, string num2)
        {
            //num長度會到200 > 總位數會到 40000 => 所以可能要自制乘法器

            //1.char to int
            //2.每處理一個位數前 *= 10
            //3.結果相乘後tostring回來

            return (StringToInt(num1) * StringToInt(num2)).ToString();
        }

        private int StringToInt(string str)
        {
            int current = 0;

            for (int i = 0; i < str.Length; i++)
            {
                current *= 10;
                current += (str[i] - '0');
            }

            return current;
        }
#endif
        public string Multiply(string num1, string num2)
        {
            //num長度會到200 > 總位數會到 40000 => 所以可能要自制乘法器
            //自己實作字串乘法器和加法器
            //幸好如果有負數和減法或許就要實作減法器 還有保留一個signal這樣            

            //time : O(n³) => for n * 第二層for n * Insert(0) n => n^3 => gpt建議用append最後reverse就能降到 n^2 ...XD
            //space : O(n)

            string result = "";
            int shift = 0;            

            for (int i = num1.Length - 1; i >= 0; i--, shift++) //shift乘法位數增加
            {
                StringBuilder current = new StringBuilder(40000);
                int left = 0;//進位
                int digit = (num1[i] - '0');
                for(int j = num2.Length - 1; j >= 0; j--)
                {
                    int computed = (num2[j] - '0') * digit + left;
                    int value = computed % 10;
                    left = computed / 10;
                    current.Insert(0, value.ToString());                    
                }

                if(left != 0)
                {
                    current.Insert(0, left.ToString());
                }

                for(int j = 0; j < shift; j++)
                {
                    current.Append('0');
                }

                //移除leading zero
                int pointer = 0;
                while (pointer < current.Length && current[pointer] == '0')
                {
                    pointer++;
                }
                current.Remove(0, pointer);

                result = Plus(result, current.ToString());
            }

            return result == "" ? "0" : result;
        }

        public string Plus(string num1, string num2)
        {
            StringBuilder result = new StringBuilder(40000);
            string longer = "";
            string shorter = "";
            if (num1.Length > num2.Length)
            {
                longer = num1;
                shorter = num2;
            }
            else
            {
                longer = num2;
                shorter = num1;
            }

            int digitDiff = longer.Length - shorter.Length;

            //for迴圈如果直接放longer.Length - shorter.Length式確定每次會重複計算的，所以shorter長度變長會影響迴圈次數，每次計算效率也不好
            for (int i = 0; i < digitDiff; i++) 
            {
                shorter = '0' + shorter;
            }

            int left = 0; //進位
            for (int i = longer.Length - 1; i >= 0; i--)
            {
                int computed = (longer[i] - '0') + (shorter[i] - '0') + left;
                int value = computed % 10;
                left = computed / 10;
                result.Insert(0, value.ToString());
            }

            if (left != 0)
            {
                result.Insert(0, left.ToString());
            }

            return result.ToString();
        }

        //https://leetcode.com/problems/multiply-strings/description/?page=3
        //人家一個int[]計算器直接打趴我string計算器，不過int[]也才比較接近一般底層進位計算XD
        //1.int[] pos = new int[m + n]; => string builder capacity也應該學，可以進一步避免浪費容量
        //2.int p1 = i + j, p2 = i + j + 1; => 位數還是由右往左計算
        //3. if(!(sb.length() == 0 && p == 0)) => 簡簡單單避免leadingzero => 只要還沒有leadingnumber時遇到0就是leadingzero
        //4. sb.length() == 0 ? "0" => 避免全是leadingzero
    }
}
