using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0079WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            //N = board.Length（列數）    
            //M = board[0].Length（行數）
            //L = word.Length
            //time:O(N*M*3^L) > 因為起點外後面都可能有3個方向可以backtracking
            //space:O(L)

            char first = word[0];

            int n = board.Length;
            int m = board[0].Length;
            List<(int, int)> directions = new List<(int, int)>()
            {
                (-1,0),(1,0),(0,-1),(0,1)
            };
            HashSet<(int, (int, int))> failRecords = new HashSet<(int, (int, int))>(); //同樣index到同樣位置失敗過就不用再走，剪枝用
            for (int i = 0; i < n;i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if(board[i][j] == first)
                    {
                        HashSet<(int, int)> path = new HashSet<(int, int)>();
                        
                        if (Recursive(board, word, "", 0, (i, j), path, directions, n, m, failRecords))
                        {
                            return true;
                        }
                        //failRecords.Add((0, (i, j))); //加上是錯誤剪枝，不過這index是0其實好像沒差
                    }
                }
            }
            

            return false;
        }

        private bool Recursive(char[][] board, string word, string current, int index, (int, int) position, HashSet<(int, int)> path, List<(int, int)> directions, int n, int m, HashSet<(int, (int, int))> failRecords)
        {
            //檢查方向合法
            if(path.Contains(position) ||
                !(position.Item1 >= 0 && position.Item1 < n && position.Item2 >= 0 && position.Item2 < m) ||
                failRecords.Contains((index, position))
            )
            {
                return false;
            }

            //組合字串
            current += board[position.Item1][position.Item2];

            //比對
            if (index == current.Length - 1 && current == word)
            {
                return true;
            }
            else if (current != word.Substring(0, index + 1))//結果好像是word.Substring嚴重拖累速度@@
            {
                failRecords.Add((index, position)); //這是絕對失敗的案例 > 結果這好像不是很有效的剪枝紀錄...，因為就算其他路徑跑到這也只是多判斷個current[index] != word[index] 好像無傷大雅
                return false;
            }

            //加入已走過路徑
            path.Add(position);

            //下一步
            foreach((int, int) direction in directions)
            {
                if (Recursive(board, word, current, index + 1, (position.Item1 + direction.Item1, position.Item2 + direction.Item2), path, directions, n, m, failRecords))
                {
                    return true;
                }
            }

            //都沒通移除路徑
            path.Remove(position);
            //failRecords.Add((index, position)); //加上是錯誤剪枝
            //「到這個 index + position，不管往哪走都失敗」 != 「在目前這一條 path 下，不管往哪走都失敗」
            //因為兩個過程不同的path，在HashSet<(int, int)> path中禁止走的下一步也不同，所以目前失敗，下一條path還是有不同可能性


            return false;
        }

        //https://leetcode.com/problems/word-search/solutions/27658/accepted-very-short-java-solution-no-add-s2q5/
        //下次要照這位的寫，精巧又精準
        //board[y][x] != word[i] > 應該要這樣比，我的比法超花時間
        //board[y][x] ^= 256; XOR（^），目的是標記已走過，ASCII 字元範圍：0 ~ 127所以加上256一定不會是原本數字，所以同個path走回來就會被擋下
        //但最差複雜度其實是一樣的
        //https://leetcode.com/problems/word-search/solutions/4965052/9645easy-solutionwith-explanation-by-mra-injv/
        //這位方法其實一樣只是不是用board[y][x] ^= 256而是直接改掉來標示已走過

        //這樣看其實我的解題方向沒錯，指示處理手法錯得離譜...

    }
}
