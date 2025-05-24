using ProblemSolveConsole.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D20 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D20.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(CountValidCheats(input, 100));
            }
        }
        public int CountValidCheats(string input, int standard)
        {
            
            var data = GetData(input);
            List<(int x, int y)>  path = MarkMap(data);
            var record = CollectList(data, path);

            int count = 0;

            foreach (var item in record)
            {
                if(item.Key >= standard)
                {
                    count += item.Value.Count;
                }
            }

            return count;
        }
        private (string[][] map, (int x, int y) start, (int x, int y) end) GetData(string input)
        {
            (int x, int y) start = (0, 0);
            (int x, int y) end = (0, 0);
            string[][] map = null;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 0;
                while (line != null && line != "")
                {
                    string[] strings = line.ToCharArray().Select(x => x.ToString()).ToArray();
                    if (count == 0)
                    {
                        map = new string[strings.Length][];
                    }
                    else if (line.IndexOf('S') >= 0)
                    {
                        start = (count, line.IndexOf('S'));
                    }
                    else if (line.IndexOf('E') >= 0)
                    {
                        end = (count, line.IndexOf('E'));
                    }


                    map[count] = strings;
                    count++;
                    line = sr.ReadLine();
                }
            }
            return (map, start, end)!;
        }
        private List<(int x, int y)> MarkMap((string[][] map, (int x, int y) start, (int x, int y) end) data)
        {
            //前提 : 路只有一條、外圍有圍起來
            List<(int x, int y)> path = new();
            int[][] directions = [[0, 1], [0, -1], [-1, 0], [1, 0]]; //上下左右

            data.map[data.start.x][data.start.y] = 0.ToString();
            path.Add((data.start.x, data.start.y));
           
            int count = 1;            
            (int x, int y) current = data.start;
            bool end = false;
            while(!end && count < 9999999)
            {
                foreach (int[] direction in directions)
                {
                    int newX = current.x + direction[0];
                    int newY = current.y + direction[1];
                    if (data.map[newX][newY] == "." || data.map[newX][newY] == "E")
                    {                        
                        data.map[newX][newY] = count.ToString();
                        current = (newX, newY);
                        path.Add((newX, newY));
                        if (data.map[newX][newY] == "E")
                        {
                            end = true;
                        }

                        break;
                    }
                }
                count++;
            }
            return path;
        }
        private Dictionary<int, List<((int x, int y) sPoint, (int x, int y) ePoint)>> CollectList((string[][] map, (int x, int y) start, (int x, int y) end) data, List<(int x, int y)> path)
        {
            Dictionary<int, List<((int x, int y) sPoint, (int x, int y) ePoint)>> record = new();
            int[][] directions = [[0, 2], [0, -2], [-2, 0], [2, 0]]; //上下左右
            int max = data.map.Length;
            foreach (var point in path)
            {
                int currentStep = Convert.ToInt32(data.map[point.x][point.y]);
                foreach (int[] direction in directions)
                {
                    int newX = point.x + direction[0];
                    int newY = point.y + direction[1];
                    if (newX < 0 || newY < 0 || newX >= max || newY >= max)
                    {
                        continue;
                    }

                    if (int.TryParse(data.map[newX][newY], out int ePointStep) && currentStep < ePointStep)
                    {
                        int diff = ePointStep - currentStep - 2;
                        var sp = ((point.x, point.y), (newX, newY));
                        if (record.TryGetValue(diff, out var list))
                        {
                            list.Add(sp);
                        }
                        else
                        {
                            record[diff] = new() { sp };
                        }
                    }
                }
            }

            return record;            
        }
        /// <summary>
        /// 因為只有一條路所以也不用了
        /// </summary>
        private bool CheckRoad(char[][] map, (int x, int y) position)
        {
            if(map[position.x][position.y] != '.')
            {
                return false;
            }
            return true;
        }
    }
}
