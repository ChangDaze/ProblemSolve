using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D4 : ISolution
    {
        public void Execute()
        {
            char[][] data = null;
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D4.txt"))
            {                
                string input = sr.ReadToEnd();
                Console.WriteLine(GetXMAS(input));
                Console.WriteLine(GetX_MAS(input));
            }
        }
        public int GetXMAS(string input)
        {
            char[][] data = GetData(input);

            string target = "XMAS";

            int[][] directions = new int[][] {
                new[] {-1, 0}, new[] { -1, -1 }, new[] { -1, 1 },
                new[] { 1, 0 }, new[] { 1, -1 }, new[] { 1, 1 },
                new[] {0, 1}, new[] {0, -1}};

            int xBoundary = data[0].Length;
            int yBoundary = data.Length;

            int result = 0;
            for(int y = 0; y < yBoundary; y++)
            {
                for(int x = 0; x < xBoundary; x++)
                {
                    foreach (int[] direction  in directions)
                    {
                        if (DFS(x, y, 0, direction))
                            result++;
                    }
                }
            }

            return result;

            bool DFS(int _row, int _col, int _index, int[] _direction)
            {
                if (_index == target.Length)
                    return true;

                if (_row < 0 || _row >= xBoundary || _col < 0 || _col >= yBoundary || data[_row][_col] != target[_index])
                    return false;

                return DFS(_row + _direction[0], _col + _direction[1], _index + 1, _direction);
            }

        }
        public int GetX_MAS(string input)
        {
            char[][] data = GetData(input);

            string target = "MAS";

            int xBoundary = data[0].Length;
            int yBoundary = data.Length;
            CheckInfo[] checkLst = new CheckInfo[]
                                {
                                    new CheckInfo(){ToStartDirection = [ -1, 1 ], Direction = [1, -1,] },
                                    new CheckInfo(){ToStartDirection = [ 1, 1 ], Direction = [-1, -1,] },
                                    new CheckInfo(){ToStartDirection = [ 1, -1 ], Direction = [-1, 1,] },
                                    new CheckInfo(){ToStartDirection = [ -1, -1 ], Direction = [1, 1,] }
                                };

            int result = 0;
            for (int y = 0; y < yBoundary; y++)
            {
                for (int x = 0; x < xBoundary; x++)
                {
                    if(x-1 >=0 && x+1 < xBoundary && y-1 >= 0 && y+1 < yBoundary && data[x][y] == 'A')
                    {
                        int odd = 0;
                        int even = 0;
                        for(int i = 0; i < checkLst.Length; i++)
                        {
                            if (DFS(x + checkLst[i].ToStartDirection[0], y + checkLst[i].ToStartDirection[1], 0, checkLst[i].Direction))
                            {
                                if(i%2 == 0)
                                    odd++;
                                else
                                    even++;
                            }
                        }
                        result += odd * even;
                    }
                }
            }

            return result;

            bool DFS(int _row, int _col, int _index, int[] _direction)
            {
                if (_index == target.Length)
                    return true;

                if (data[_row][_col] != target[_index])
                    return false;

                return DFS(_row + _direction[0], _col + _direction[1], _index + 1, _direction);
            }
        }
        private class CheckInfo
        {
            public int[] Direction {  get; set; }
            public int[] ToStartDirection { get; set; }
        }
        private char[][] GetData(string input)
        {
            char[][] data = null;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 0;
                while (line != null)
                {
                    char[] chars = line.ToCharArray();
                    if (count == 0)
                        data = new char[chars.Length][];
                    data[count] = chars;
                    count++;
                    line = sr.ReadLine();
                }
            }
            return data;
        }
    }
}
