using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0075SortColors
    {
        public void SortColors(int[] nums)
        {
            //因為內容固定了，所以照著hint做的方法只要O(n), 空間更是只要O(1)因為種類很少
            //不過題目的inplace好像不太在意只是constant的額外空間

            Dictionary<int, int> counts = new Dictionary<int, int>() {
                {0,0} ,
                {1,0} ,
                {2,0} ,
            };

            foreach (int i in nums)
            {
                counts[i]++;
            }

            int pointer = 0;
            for(int i = 0; i < 3; i++)
            {
                while (counts[i]>0)
                {
                    nums[pointer++] = i;
                    counts[i]--;
                }
            }
        }

        //Dutch National Flag Problem 的價值不在顏色，而在於：它教你如何用「指標 + 不變量」，在一次掃描中完成資料分區。
        //結果指標很重要我都沒用@@
        //另外原本的好像也不用dictionary來操作@@

        //Dutch National Flag Problem 的原理是：
        //用三個指標維護「區間不變量」，
        //每一步只處理一個未知元素，
        //並且用最少的交換把它送進正確區間。

        //0   low     mid            high    n-1
        //|----|--------|--------------|------|
        //[0, low)	全部是「最小類」
        //[low, mid)	全部是「中間類」
        //[mid, high]	尚未處理
        //(high, n-1]	全部是「最大類」

        //把一個陣列，分成以上4類並在過程中釐清歸類

        //https://leetcode.com/problems/sort-colors/solutions/26481/python-on-1-pass-in-place-solution-with-ute9g/?page=3
        //上面的敘述可以照這位程式碼解
        //red(low), white(mid), blue(high)
        //white也能於iterator pointer
        //所以mid ~ high 中間會越來越小 => 未知種類越來越少
        //遇到low就swap值進low領地並推進
        //遇到mid因為已在領地所以不用特別處理 (mid領地會自動隨iterator推進)
        //遇到high就swap值進high領地並推進

        //這個方法論感覺是要達成O(1n)，只是要O(n)我的方法就應該能躺平
    }
}
