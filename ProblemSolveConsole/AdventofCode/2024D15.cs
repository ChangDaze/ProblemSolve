using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D15 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D15.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetCoordinatesSum(input));
                Console.WriteLine(GetScaledUpSum(input));
            }
        }
        public int GetCoordinatesSum(string input)
        {
            int[] point;
            string command = "";
            char[][] data = GetData(input, out command, out point);
            foreach(char direction in command)            
                MovePoint(data, point, direction);
            
            int sum = 0;

            for(int y = 0; y < data.Length; y++)
            {
                for(int x = 0; x < data[y].Length; x++)
                {
                    if (data[y][x] == 'O')
                        sum += (x + 100 * y);
                }
            }

            return sum;
            void MovePoint(char[][] _data, int[] _point, char _direction)
            {
                int[] move = [0, 0];
                switch(_direction)
                {
                    case '^':
                        move[0] = -1;
                        break;
                    case 'v':
                        move[0] = 1;
                        break;
                    case '<':
                        move[1] = -1;
                        break;
                    case '>':
                        move[1] = 1;
                        break;
                    default:
                        break;
                }

                //start move
                int[] temp = new int[_point.Length];
                Array.Copy(_point, temp, _point.Length);

                do
                {
                    temp[0] += move[0];
                    temp[1] += move[1];
                }
                while (_data[temp[0]][temp[1]] == 'O');

                if(_data[temp[0]][temp[1]] == '.')
                {
                    _data[temp[0]][temp[1]] = 'O';
                    _data[_point[0] + move[0]][_point[1] + move[1]] = _data[_point[0]][_point[1]];
                    _data[_point[0]][_point[1]] = '.';
                    _point[0] += move[0];
                    _point[1] += move[1];
                }
            }
        }
        private char[][] GetData(string input, out string command, out int[] startPoint)
        {
            startPoint = new int[2];
            command = "";
            char[][] data = null;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 0;
                while (line != null && line != "")
                {
                    char[] chars = line.ToCharArray();
                    if (count == 0)
                        data = new char[chars.Length][];
                    else if (line.IndexOf('@') >= 0)
                        startPoint = [count, line.IndexOf('@')];

                    data[count] = chars;
                    count++;
                    line = sr.ReadLine();
                }

                line = sr.ReadLine();
                StringBuilder stringBuilder = new StringBuilder();
                while (line != null && line != "")
                {
                    stringBuilder.Append(line);
                    line = sr.ReadLine();
                }
                command = stringBuilder.ToString();
            }
            return data;
        }
        public int GetScaledUpSum(string input)
        {
            int[] point;
            string command = "";
            char[][] data = GetScaledUpData(input, out command, out point);
            foreach (char direction in command)
            {
                int move = 0;
                switch (direction)
                {
                    case '^':
                        move = -1;
                        MoveVertical(data, point, move);
                        break;
                    case 'v':
                        move = 1;
                        MoveVertical(data, point, move);
                        break;
                    case '<':
                        move = -1;
                        MoveHorizontal(data, point, move);
                        break;
                    case '>':
                        move = 1;
                        MoveHorizontal(data, point, move);
                        break;
                    default:
                        break;
                }
                
            }
                

            int sum = 0;

            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    if (data[y][x] == '[')
                        sum += (x + 100 * y);
                }
            }

            return sum;
            void MoveHorizontal(char[][] _data, int[] _point, int _move)
            {
                //start move
                int[] temp = [_point[0], _point[1] + _move];
                Stack<(int x, int y)> movePoints = new Stack<(int x, int y)>();
                
                while (_data[temp[0]][temp[1]] == '[' || _data[temp[0]][temp[1]] == ']')
                {
                    movePoints.Push((x: temp[0], y: temp[1]));
                    temp[1] += _move;
                }

                if (_data[temp[0]][temp[1]] == '.')
                {
                    (int x, int y) movePoint;
                    while (movePoints.Count > 0)
                    {
                        movePoint = movePoints.Pop();
                        _data[movePoint.x][movePoint.y + _move] = _data[movePoint.x][movePoint.y];
                        _data[movePoint.x][movePoint.y] = '.';
                    }

                    _data[_point[0]][_point[1]] = '.';
                    _point[1] += _move;
                    _data[_point[0]][_point[1]] = '@';
                }
            }
            void MoveVertical(char[][] _data, int[] _point, int _move)
            {
                //目前寫起來只單純用較複雜的模擬，還沒特別用演算法
                //start move
                HashSet<(int x, int y)> moveRecords = new HashSet<(int x, int y)>();
                Stack<(int x, int y)> movePoints = new Stack<(int x, int y)>();
                Queue<(int x, int y)> checkLst = new Queue<(int x, int y)>(); 
                //不能用stack因為會變深度優先，倒置第一條檢查完後中間檢查了一點另一條的後面，就預設第二條後面也都檢查完了，ex: 1-10，2被橫向檢查了導致沒把3~10加到檢查中，要廣度優先然需要檢查的下一步都立即加入檢查

                checkLst.Enqueue((x : _point[0] + _move, y: _point[1]));

                bool needMove = true;

                while (checkLst.Count > 0) 
                {
                    (int x, int y) checkPoint = checkLst.Dequeue();
                    if (_data[checkPoint.x][checkPoint.y] == '.' || moveRecords.Contains(checkPoint))                    
                        continue;                                            
                    else if (_data[checkPoint.x][checkPoint.y] == '#')
                    {
                        needMove = false;
                        break;
                    }                    
                    else if (_data[checkPoint.x][checkPoint.y] == '[')
                        checkLst.Enqueue((x: checkPoint.x, y: checkPoint.y + 1));
                    else if (_data[checkPoint.x][checkPoint.y] == ']')
                        checkLst.Enqueue((x: checkPoint.x, y: checkPoint.y - 1));

                    checkLst.Enqueue((x: checkPoint.x + _move, y: checkPoint.y));
                    moveRecords.Add(checkPoint);
                    movePoints.Push(checkPoint);
                }


                if (needMove)
                {
                    (int x, int y) movePoint;
                    while (movePoints.Count > 0)
                    {
                        movePoint = movePoints.Pop();
                        _data[movePoint.x + _move][movePoint.y] = _data[movePoint.x][movePoint.y];
                        _data[movePoint.x][movePoint.y] = '.';
                    }

                    _data[_point[0]][_point[1]] = '.';
                    _point[0] += _move;
                    _data[_point[0]][_point[1]] = '@';
                }
            }
        }
        private char[][] GetScaledUpData(string input, out string command, out int[] startPoint)
        {
            startPoint = new int[2];
            command = "";
            char[][] data = null;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 0;
                while (line != null && line != "")
                {
                    char[] chars = new char[line.Length * 2];

                    for(int i = 0; i < line.Length; i++)
                    {
                        int scaleUpPoint = i * 2;
                        switch(line[i])
                        {
                            case '#':
                                chars[scaleUpPoint] = '#';
                                chars[scaleUpPoint+1] = '#';
                                break;
                            case 'O':
                                chars[scaleUpPoint] = '[';
                                chars[scaleUpPoint + 1] = ']';
                                break;
                            case '.':
                                chars[scaleUpPoint] = '.';
                                chars[scaleUpPoint + 1] = '.';
                                break;
                            case '@':
                                chars[scaleUpPoint] = '@';
                                chars[scaleUpPoint + 1] = '.';
                                break ;
                            default:
                                break;
                        }
                    }

                    if (count == 0)
                        data = new char[line.Length][]; //原本是正方形
                    else if (line.IndexOf('@') >= 0)
                        startPoint = [count, line.IndexOf('@') * 2];

                    data[count] = chars;
                    count++;
                    line = sr.ReadLine();
                }

                line = sr.ReadLine();
                StringBuilder stringBuilder = new StringBuilder();
                while (line != null && line != "")
                {
                    stringBuilder.Append(line);
                    line = sr.ReadLine();
                }
                command = stringBuilder.ToString();
            }
            return data;
        }
    }
}
