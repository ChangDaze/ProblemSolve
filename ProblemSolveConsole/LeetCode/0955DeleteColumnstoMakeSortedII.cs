using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0955DeleteColumnstoMakeSortedII
    {
        public int MinDeletionSize(string[] strs)
        {
            //Time complexity:O(kn)
            //Space complexity:O(k + n)

            int result = 0;
            int n = strs.Length;
            int k = strs[0].Length; //k個要比較的column

            bool[] checks = new bool[n]; //不必再檢查的row => O(n)

            for (int c = 0; c < k; c++)//逐column比較，前面的column都合法就直接不用比後面的了 => greedy
            {
                List<int> tempChecks = new List<int>();//暫存確認此row已是字典序，此column沒刪除才會生效=> O(k)
                for (int r = 1; r < n; r++) //此column每個row跟上一row確認
                {
                    if (checks[r])//前面column有>後面同row不同column就不用比 => 已是字典序
                    {
                        continue;
                    }

                    if (strs[r - 1][c] < strs[r][c])//比較的row已是字典序
                    {
                        tempChecks.Add(r);//同row後續column不用繼續比
                    }
                    else if (strs[r - 1][c] > strs[r][c]) //前面row有<就確認要刪除 => 不是字典序要刪除，此column後面row不用比了，因為刪除了
                    {
                        result++;
                        tempChecks.Clear(); //此column刪除，前面row的check不會生效了
                        break;
                    }
                    //strs[r - 1][c] == strs[r][c]，前面row字元不是嚴格字典序就要往後面row繼續比 => 避免後面coumn可能不是字典序要刪除
                }

                //確認此row已是字典序，生效
                foreach(int i in tempChecks)
                {
                    checks[i] = true;
                }
            }

            return result;
        }

        //這題就單純的greedy+simulation，重點是考細心度...，沒思考完整會花很多時間，剩下看得可能就是程式碼優雅度影響速度...，看來我是都沒表現多好 => 不過就結果來說因為沒有特別花招，所以不用太糾結特別解法，速度不會差到太多
        //https://leetcode.com/problems/delete-columns-to-make-sorted-ii/solutions/203182/javacpython-greedy-solution-omn-by-lee21-5t1p/
        //這寫法跟我完全一樣，只是他><分兩次比，if (i < n - 1) continue;代表有刪column就不用更新check了
        //https://leetcode.com/problems/delete-columns-to-make-sorted-ii/solutions/203171/c-12-ms-brute-force-by-votrubac-c7nv/
        //這是理直氣壯的暴力解XD，直接兩兩row比對，可能題目沒有time limit，重點是 di.insert(j);i = 0; => 如果有刪除會回到第一row重比
    }
}
