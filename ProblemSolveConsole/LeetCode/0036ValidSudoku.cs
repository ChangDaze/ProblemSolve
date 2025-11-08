using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0036ValidSudoku
    {
#if false //brute force => 靠時間
        public bool IsValidSudoku(char[][] board)
        {
            for(int i = 0; i < 9; i++)
            {
                HashSet<int> row = new HashSet<int>();
                HashSet<int> column = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    //解row
                    if (board[i][j] != '.')
                    {
                        if (row.Contains(board[i][j]))
                        {
                            return false;
                        }
                        row.Add(board[i][j]);
                    }

                    //解column
                    if (board[j][i] != '.')
                    {
                        if (column.Contains(board[j][i]))
                        {
                            return false;
                        }
                        column.Add(board[j][i]);
                    }
                }

            }

            

            //解block
            for (int k = 0; k < 9; k = k + 3)
            {
                for (int l = 0; l < 9; l = l + 3)
                {
                    HashSet<int> block = new HashSet<int>();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i+k][j+l] != '.')
                            {
                                if (block.Contains(board[i + k][j + l]))
                                {
                                    return false;
                                }
                                block.Add(board[i + k][j + l]);
                            }
                        }
                    }
                }
            }

            return true;
        }
#endif
        public bool IsValidSudoku(char[][] board)
        {
            //總共18個區域需要比較一次建起來比brute force => 靠空間
            List<HashSet<int>> rows = new List<HashSet<int>>();
            List<HashSet<int>> columns = new List<HashSet<int>>();
            List<HashSet<int>> blocks = new List<HashSet<int>>();

            //建立容器
            for (int i = 0; i < 9; i++)
            {
                rows.Add(new HashSet<int>());
                columns.Add(new HashSet<int>());
                blocks.Add(new HashSet<int>());
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        continue;
                    }

                    if (rows[i].Contains(board[i][j])){
                        return false;
                    }
                    rows[i].Add(board[i][j]);

                    if (columns[j].Contains(board[i][j]))
                    {
                        return false;
                    }
                    columns[j].Add(board[i][j]);

                    int blockIndex = (i / 3) * 3 + (j / 3);
                    /*
                     ex:3層，每層3塊共9塊
                     (row/3) 決定它在第幾層（0,1,2）
                     每層有 3 塊，所以換層把前面幾層(row)pass的區塊(*3)加上，才加層這層的第幾區塊(col) → * 3
                     (col/3) 決定是該層的第幾塊（0,1,2）
                     */
                    if (blocks[blockIndex].Contains(board[i][j]))
                    {
                        return false;
                    }
                    blocks[blockIndex].Add(board[i][j]);
                }
            }

            return true;
        }

        //https://leetcode.com/problems/valid-sudoku/solutions/15472/shortsimple-java-using-strings-by-stefan-rmwb/
        //結果自己encode每種有效情境+hashset最清晰...XD
        //'4' in row 7 is encoded as "(4)7".
        //'4' in column 7 is encoded as "7(4)".
        //'4' in the top-right block is encoded as "0(4)2  top => row第0層 column第2層 用 i/3 j/3就能抓到
    }
}
