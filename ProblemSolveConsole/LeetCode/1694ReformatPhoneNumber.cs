using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1694ReformatPhoneNumber
    {
        public string ReformatNumber(string number)
        {
            int limit = 4;
            int limitPoint = 0;
            int count = 0;
            //先回頭找出限制點
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(number[i]))
                {
                    count++;

                    if(count >= limit)
                    {
                        limitPoint = i;
                        count = 0;
                        break;
                    }
                }
            }

            int groupStandard = 3;
            string temp = "";
            string groupSplitStandard = "-";
            int lastPointer = -1; //形成group的點都不能算到lastSection
            //從頭邊走邊做出字串，使用stringbuilder，因為是單一字串
            StringBuilder result = new StringBuilder(); 
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (Char.IsDigit(number[i]))
                {
                    temp += number[i];
                    count++;

                    if (temp.Length >= groupStandard)
                    {
                        result.Append(temp);
                        result.Append(groupSplitStandard);
                        count = 0;
                        temp = "";
                        lastPointer = i;
                    }
                }

                if( i >= limitPoint && temp.Length <= 1) //temp.Length <= 1 剛好4個digit沒形成group也要break
                {
                    break;
                }
            }

            //超過限制點就開始處理尾巴
            //2 digits: A single block of length 2.
            //3 digits: A single block of length 3.
            //4 digits: Two blocks of length 2 each.
            string lastSection = "";
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(number[i]))
                {                    
                    if (i <= lastPointer)
                    {
                        break;
                    }
                    lastSection = number[i] + lastSection;
                }
            }

            switch(lastSection.Length)
            {
                case 2:
                    result.Append(lastSection);
                    break;
                case 3:
                    result.Append(lastSection);
                    break;
                case 4:
                    result.Append(lastSection.Substring(0,2));
                    result.Append(groupSplitStandard);
                    result.Append(lastSection.Substring(2, 2));
                    break;
                default:
                    result.Append(lastSection);
                    break;

            }

            return result.ToString();
        }

        //下面這幾位對於題目的2、3、4分組禮節都比我好，我只有呆呆用switch case，還用了一堆變數存讓問題變得很複雜，應該也可以先思考看看2、3、4的關聯 => 只會發生(最終處理上也是)剩4個和非剩4個的情況，每次3個一組一定會達成前述結果
        //regex語法，但會反覆檢查，不過應該也不會太慢，他排除剩4個digit的方法是確認後面的字串至少兩個digit才去做group形成
        //https://leetcode.com/problems/reformat-phone-number/solutions/979806/1-liner-python-java-c/
        //這蠻有趣直接的，用queue size來控制，然後執行時都是一次執行3個，不過是2N，然後寫死的量也跟我差不多，但他的程式碼會比我乾淨不少
        //https://leetcode.com/problems/reformat-phone-number/solutions/978606/java-queue-o-n-easy-to-understand/
        //這是用recursive，效率就像說明所說
        //https://leetcode.com/problems/reformat-phone-number/solutions/978728/c-functional-short/
    }
}
