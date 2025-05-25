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
                Console.WriteLine(CountValidCheats(input, 100, 20));
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
        /// 擴充cheatSteps版本
        /// </summary>
        private Dictionary<int, List<((int x, int y) sPoint, (int x, int y) ePoint)>> CollectList((string[][] map, (int x, int y) start, (int x, int y) end) data, List<(int x, int y)> path, int cheatSteps)
        {
            //前提 cheat 只能一次，
            //(原本以為不行卡了超久...，幸好有用測試題目對過各組數量，不然會直接撞壁)且中間可以經過一般道路(https://www.reddit.com/r/adventofcode/comments/1hivatr/comment/m31tsgs/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button)
            Dictionary<int, List<((int x, int y) sPoint, (int x, int y) ePoint)>> record = new();
            int[][] directions = [[0, 1], [0, -1], [-1, 0], [1, 0]]; //上下左右
            int max = data.map.Length;
            foreach (var basePoint in path)
            {
                //BFS讓進出都只會用最短路徑看一次
                int sStep = Convert.ToInt32(data.map[basePoint.x][basePoint.y]);
                HashSet<(int x, int y)> passed = new();
                Queue<(int x, int y, int step)> queue = new Queue<(int x, int y, int step)>();
                queue.Enqueue((basePoint.x, basePoint.y, 0));

                while (queue.Count > 0)
                {
                    (int x, int y, int step) current = queue.Dequeue();
                    if(
                        current.step > cheatSteps || //檢查步數
                        current.x < 0 || current.y <0 || current.x >= data.map.Length || current.y >= data.map.Length ||//檢查範圍
                        passed.Contains((current.x, current.y))//確認還沒來過
                    )
                    {
                        continue;
                    }

                    //紀錄已來過讓BFS生效
                    //【注意】包含ePoint => 因為相同起點終點就只留最短路徑了
                    passed.Add((current.x, current.y));

                    //結算
                    if (
                        int.TryParse(data.map[current.x][current.y], out int eStep) &&
                        eStep > (sStep + current.step) //有節省才結算
                    ) 
                    {
                        int diff = eStep - sStep - current.step;
                        var sp = ((basePoint.x, basePoint.y), (current.x, current.y));
                        if (record.TryGetValue(diff, out var list))
                        {
                            list.Add(sp);
                        }
                        else
                        {
                            record[diff] = new() { sp };
                        }
                    }
                    //中間可以經過一般道路，所以是數字且沒要結算也能繼續後面的路

                    //繼續走
                    int newStep = current.step + 1;
                    foreach (int[] direction in directions)
                    {
                        int newX = current.x + direction[0];
                        int newY = current.y + direction[1];
                        queue.Enqueue((newX, newY, newStep));
                    }
                }
            }

            return record;
        }
        public int CountValidCheats(string input, int standard, int cheatSteps)
        {

            var data = GetData(input);
            List<(int x, int y)> path = MarkMap(data);
            var record = CollectList(data, path, cheatSteps);

            int count = 0;

            foreach (var item in record)
            {
                if (item.Key >= standard)
                {
                    count += item.Value.Count;
                }
            }

            return count;
        }
    }
}
