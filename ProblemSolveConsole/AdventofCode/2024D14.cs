using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.AdventofCode._2024D13;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D14 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D14.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetSafetyFactor(input, 101, 103, 100));
                TryGetTree(input, 101, 103);
            }
        }
        public int GetSafetyFactor(string input, int wide, int tall, int seconds)
        {
            List<int[]> dataLst = GetData(input);
            int[] sum = new int[4];

            int xMiddle = wide / 2;
            int yMiddle = tall / 2;

            Dictionary<(int newX, int newY), int> newRecord = new Dictionary<(int newX, int newY), int>(); //單純記錄用，可以不用
            foreach (int[] data in dataLst)
            {
                (int newX, int newY) = (((data[0] + 1) + (data[2] * seconds)) % wide, ((data[1] + 1) + (data[3] * seconds)) % tall); //+1是為了消除0 index對%的影響
                newX = (newX <= 0 ? wide + newX : newX) - 1; //-1 是為了回復 0 index , 比較時包含=，=就是剛好到最底
                newY = (newY <= 0 ? tall + newY : newY) - 1;

                if (newX < xMiddle && newY < yMiddle)
                    sum[0]++; //LT
                else if (newX < xMiddle && newY > yMiddle)
                    sum[1]++; //LD
                else if (newX > xMiddle && newY > yMiddle)
                    sum[2]++; //RD
                else if (newX > xMiddle && newY < yMiddle)
                    sum[3]++; //RT

                AddToDictionary(newRecord, newX, newY);
            }

            return sum[0] * sum[1] * sum[2] * sum[3];
            void AddToDictionary(Dictionary<(int newX, int newY), int> _dictionary, int _newX, int _newY)
            {
                if (_dictionary.ContainsKey((_newX, _newY)))
                    _dictionary[(_newX, _newY)] += 1; //因為要用加法所以寫不了泛型@@
                else
                    _dictionary[(_newX, _newY)] = 1;
            }
        }
        private List<int[]> GetData(string input)
        {
            List<int[]> result = new List<int[]>();
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (line.Length > 0) //會有空白行
                    {
                        string[] p = ExtractData(line, line.IndexOf('=') + 1).Split(',');
                        string[] v = ExtractData(line, line.LastIndexOf('=') + 1).Split(',');

                        result.Add([Convert.ToInt32(p[0]), Convert.ToInt32(p[1]), Convert.ToInt32(v[0]), Convert.ToInt32(v[1])]);
                    }
                    line = sr.ReadLine();
                }
            }

            return result;
            string ExtractData(string _line, int _index)
            {
                string str = "";
                while (_index < _line.Length && (char.IsDigit(_line[_index]) || _line[_index] == '-' || _line[_index] == ','))
                {
                    str += _line[_index];
                    _index++;
                }
                return str;
            }
        }
        //reference : https://advent-of-code.xavd.id/writeups/2024/day/14/
        //基本上這題要先找出firstSpecialSecond，然後在自己慢慢按到樹出現
        //然後移動是有規律的所以才漸漸變成樹，可以看看reference說的
        public void TryGetTree(string input, int wide, int tall)
        {
            int[][] map = new int[tall][];
            for (int i = 0; i < map.Length; i++)
                map[i] = new int[wide];
            List<RobotInfo> robotInfos = GetRobotInfos(input, map);
            int firstSpecialSecond = 53;
            int second = 0;

            while(second < 10000)
            {
                if ((second - firstSpecialSecond) % tall == 0)
                {
                    PrintData(map);
                    Console.WriteLine();
                    Console.WriteLine(second);
                    Console.ReadLine();
                }
                
                RobotsMove(robotInfos, map, wide, tall);
                second++;
            }

            void PrintData(int[][] _map)
            {
                for (int y = 0; y < _map.Length; y++)
                {
                    for (int x = 0; x < _map[y].Length; x++)
                    {
                        if (_map[y][x] == 0) Console.Write('.');
                        else Console.Write(_map[y][x]);
                    }
                    Console.WriteLine();
                }
            }
            void RobotsMove(List<RobotInfo> _robotInfos, int[][] _map, int _wide, int _tall)
            {
                foreach(RobotInfo _robotInfo in _robotInfos)
                {
                    //start
                    map[_robotInfo.Y][_robotInfo.X]--;
                    //end
                    _robotInfo.X += _robotInfo.VX;
                    if (_robotInfo.X < 0)
                        _robotInfo.X += _wide; //這邊是有預設wide和tall都小於邊界才能這樣計算
                    else if (_robotInfo.X >= _wide)
                        _robotInfo.X -= _wide;

                    _robotInfo.Y += _robotInfo.VY;
                    if (_robotInfo.Y < 0)
                        _robotInfo.Y += _tall;
                    else if (_robotInfo.Y >= _tall)
                        _robotInfo.Y -= _tall;

                    map[_robotInfo.Y][_robotInfo.X]++;
                }
            }
        }
        private List<RobotInfo> GetRobotInfos(string input, int[][] map)
        {
            List<RobotInfo> robotInfos = new List<RobotInfo>();
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (line.Length > 0) //會有空白行
                    {
                        string[] p = ExtractData(line, line.IndexOf('=') + 1).Split(',');
                        string[] v = ExtractData(line, line.LastIndexOf('=') + 1).Split(',');

                        RobotInfo robotInfo = new RobotInfo()
                        {
                            X = Convert.ToInt32(p[0]),
                            Y = Convert.ToInt32(p[1]),
                            VX = Convert.ToInt32(v[0]),
                            VY = Convert.ToInt32(v[1])
                        };

                        map[robotInfo.Y][robotInfo.X]++;
                        robotInfos.Add(robotInfo);
                    }
                    line = sr.ReadLine();
                }
            }

            return robotInfos;
            string ExtractData(string _line, int _index)
            {
                string str = "";
                while (_index < _line.Length && (char.IsDigit(_line[_index]) || _line[_index] == '-' || _line[_index] == ','))
                {
                    str += _line[_index];
                    _index++;
                }
                return str;
            }
        }
        public class RobotInfo()
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int VX { get; set; }
            public int VY { get; set; }
        }
    }
}
