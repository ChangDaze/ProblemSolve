using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0089GrayCode
    {
        public IList<int> GrayCode(int n)
        {
            //Time complexity:O(2^n) => 總長度
            //Space complexity:O(2^n) => 總長度
            List<int> result = new List<int>();            
            int end = (int)Math.Pow(2, n) - 1;
            for (int i = 0; i <= end; i++)
            {
                result.Add(i ^ (i >> 1)); //公式解
            }

            return result;
        }
    }

    //https://en.wikipedia.org/wiki/Gray_code#Converting_to_and_from_Gray_code
    //wiki可以抄的公式，基本上目的是two successive values differ in only one bit ，主要用途是在數位電路中降低狀態轉換時的錯誤與歧義 => 因為bit只差一碼

    //https://leetcode.com/problems/gray-code/solutions/29891/share-my-solution-by-yuyibestman-jec5/
    //可能是公式來源的解法 => 規律觀察，作者用n=2和3，但自己應該用n=1和2會發現從中線會是對稱的，規律是| 1<<i => 所以就能像作者一樣側記演算法讓後半段從前半段對稱位置| 1<<i加入資料就好 => 十分值得記住
    //https://leetcode.com/problems/gray-code/solutions/6673710/unlock-the-xor-trick-behind-gray-code-se-h18d/
    //公式解 => 一定最快 => 被格雷馬公式 num ^ (num >> 1) 照順序 0 ~ end 套公式即可，
    //https://leetcode.com/problems/gray-code/description/
    //可能是公式來源的解法 => 這是backtracking，其實對稱的概念跟第一位很像，這位比較抽象，一樣是透過backtracking解決前半，但後半是觀察規律，他只有在前半後半轉換時要將第n碼的bit flip => 然後後半backtracking下去自然就解了，這個將第n碼的bit flip的點會幫每個部分都處理成只差一碼，另外 k == 0 時，代表目前的數調整完成，將其轉換為整數並存入結果(所以k==0有幾個數就發生幾次)，是一個比較微觀升級到宏觀抽象的規律觀察，跟第一位是一個對比概念又很相似
}
