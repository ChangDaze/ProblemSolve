using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1461CheckIfaStringContainsAllBinaryCodesofSizeK
    {
        public bool HasAllCodes(string s, int k)
        {
            //Time complexity:O(n)
            //Space complexity:O(m) > for bool[need]，不過仔細想想n應該會大於m，因為early exit的條件就確保n一定大於m了

            int need = 1 << k;//所有可能性就是2的k次
            int mask = need - 1;//need-1=mask做出k個digit的1111 => 後來知道可以用~0補數+32-k之類的做mask，但都可以

            //early exit
            //L - k + 1 (L>k的部分+1等於最少的可能子字串)>= 2^k (可能的組合數量)
            //移項就變L>=k+2^k-1
            //張出應該是很單純的想說長度為k的可能性至少要有need個可以推進才符合條件，所以(!(s.Length >= k + need))應該也可以 => 那時號腦袋好靈光，事後想好久
            if (s.Length < k + mask)
            {
                return false;
            }

            bool[] seen = new bool[need]; //所有可能的status紀錄

            int count = 0;
            int hash = 0;

            for(int i = 0; i < s.Length; i++)
            {
                hash = ((hash << 1) & mask) | (s[i] - '0'); //照順序將s組成長度為k-1的hash(mask確保了有效digit長度為k)，因為>=k時會繼續shift所以會像Sliding Window一樣推進檢查
                //有點rolling hash那味
                if (i >= k - 1)
                {
                    if (!seen[hash])//有沒處理過的目標出現就紀錄count和狀態
                    {
                        seen[hash] = true;
                        count++;

                        if(count == need)//當所有目標都達成即返回true
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        //https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/solutions/1105875/c-super-simple-5-line-easy-to-understand-pah5/?envType=daily-question&envId=2026-02-23
        //這個很扯，也應該要記住，但我不太善長這個，就是用hashset + substring長度k，跑sliding window 後只檢查size() == pow(2, k)，就是只驗證結果XD，很適合炫技加深第一印象
        //https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/solutions/660829/python-1-line-follow-up-by-lee215-6zyb/?envType=daily-question&envId=2026-02-23
        //這位方法跟第一位一樣
        //https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/solutions/7601051/1-by-kriswella-67jt/?envType=daily-question&envId=2026-02-23
        //這位方法跟我一樣

        //看來主流解法就是hashset或是像我一樣記錄狀態了，不過都是sliding window => 連續長度k的substring 用 sliding window蠻合理的
    }
}
