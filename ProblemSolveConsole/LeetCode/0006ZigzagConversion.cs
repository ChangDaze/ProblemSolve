using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0006ZigzagConversion
    {
        public string Convert(string s, int numRows)
        {
            #region 一般解法
#if true
            //input以上下(直線部分只上到下)優先後左右(斜線部分只有下到上並左往右)numRows的Z字形照順序組成字串
            //Z的斜線部分每個column只有一個字串且含頭尾連接直線部分的columns 數 = numRows => 要注意的是斜線的頭尾處理，也要注意currentIndex在斜線處理完不是+= numRows
            //ouput改由左右(只有左往右)優先後上下(只有上往下)組成字串
            //因為都是左往右，所以照Zigzag轉換成左往右的每個row組成numRows個stringbuilders後組成output吐出

            StringBuilder[] sbs = new StringBuilder[numRows];

            for (int i = 0; i < sbs.Length; i++)
            {
                sbs[i] = new StringBuilder();
            }

            for(int i = 0, line = 0;i < s.Length;line++)
            {
                //i交由內部有處理才++
                int j = 0;
                for (; j < numRows; j++)
                {
                    int currentIndex = j + i;
                    if (currentIndex >= s.Length)
                    {
                        break;
                    }
                    
                    if (line % 2 == 0)
                    {
                        //直線 單純上到下
                        sbs[j].Append(s[currentIndex]);
                    }
                    else
                    {
                        //斜線 去頭去尾row下到上

                        int zRow = (numRows - 1) - j - 1; //多-1為了去尾row

                        //break為了去頭row
                        if(zRow <= 0)
                        {
                            break ;
                        }

                        sbs[zRow].Append(s[currentIndex]);
                    }
                }
                i += j;//移動有處理的index數量(因為j是0開始所以結束後++時剛好等於處理數量)
            }

            return string.Concat(sbs.Select(sb => sb.ToString()));
#endif
            #endregion

            #region 因為太輕量，不太需要用 Parallel，如果要用應該會 直線+斜線 = step, 然後用parallel index處理 %step的方式來處理
            #endregion
        }
    }
}
