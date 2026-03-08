using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1980FindUniqueBinaryString
    {
        public string FindDifferentBinaryString(string[] nums)
        {
            //Time complexity:O(n) > 因為n == nums.length，所以loop理論上也不會超過n個太多
            //Space complexity:O(n) > 因為n == nums.length，

            HashSet<int> set = new HashSet<int>();//用來裝nums => 感覺用bool[maxPlus1]來記錄狀態也是可，理論上nums只要稍長bool[]可能就比較划算，也比較快， 結果題目有限制n == nums.length 好像bool沒比較好，因為這題根本也不是考狀態紀錄GG
            foreach (string s in nums)
            {
                set.Add(Convert.ToInt32(s, 2));//用base2轉成int
            }

            int maxPlus1 = 1 << nums[0].Length;//會是max+1

            for(int i = 0;  i < maxPlus1; i++)//loop所有可能
            {
                if (!set.Contains(i))
                {
                    return Convert.ToString(i, 2).PadLeft(nums[0].Length, '0');//用base2轉成string並補上足夠長度
                }
            }

            throw new Exception("No answer!");//題目沒有說會沒有答案
        }

        //看完下面才覺得搞錯核心題目 => 如果是考試這可能要在考試中跟考官探索出來
        //https://leetcode.com/problems/find-unique-binary-string/solutions/
        //核心:ans+= nums[i][i]=='0' ? '1' : '0'; => as it differs from all others at atleast one position => make sure that the binary we have made is unique 就這麼簡單
        //他有提到一個理論Cantor's diagonal argument => https://en.wikipedia.org/wiki/Cantor%27s_diagonal_argument => 性質一樣，用對角線來找集合中不存在的組合 => 值得記住
        //https://leetcode.com/problems/find-unique-binary-string/solutions/4196840/find-unique-binary-string-by-leetcode-x211/
        //官方的，前面3個好像就是string + '0' or string + '1' + rescursive的窮舉 => 難怪有backtracing 不過窮舉就是n^2
        //第四個方法也是Cantor's diagonal argument

        //仔細想想我也是窮舉耶...，還以為比較聰明XD，不過Cantor's diagonal argument應該是最佳解
        //但因為n == nums.length，所以loop理論上也不會超過n個太多 => 所以這題就算窮舉速度也不會差太多，在非常多次執行中比較能體現Cantor's diagonal argument效果
    }
}
