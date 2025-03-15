using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3206AlternatingGroupsI
    {
        public int NumberOfAlternatingGroups(int[] colors)
        {
            int groups = 0;
            int contiguous = 0;
            int preColor = colors[colors.Length-1];//尾部磁磚

            for(int i = 0; i < colors.Length; i++)
            {
                if (colors[i] != preColor)
                {
                    if(++contiguous >= 2)
                    {
                        groups++;
                    }                    
                }
                else
                {
                    contiguous = 0;
                }
                preColor = colors[i];
            }
            //每個瓷磚影響兩個group，且首尾相連，所以開頭和結尾都要特別處理
            if (colors[0] != preColor && ++contiguous >= 2)
            {
                groups++;
            }

            return groups;
        }

        //但我覺得我的寫法判斷應該比較少吧? 可能邏輯太單純所以比不出速度
        //因為%對象是n，所以%只是讓循環不用額外處理而已
        //https://leetcode.com/problems/alternating-groups-i/
    }
}
