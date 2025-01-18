using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D6 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D6.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetVisitSum(input));
                Console.WriteLine(GetLoopSum(input));
            }
        }
        public int GetVisitSum(string input)
        {
            char[][] data = GetData(input);
            int sum = 0;
            int[] position = GetPosition(data); //叫ab是因為計算起來跟xy象限不同
            char direction = data[position[0]][position[1]];
            int aBoundry = data.Length;
            int bBoundry = data[0].Length;            
            while (position[1] >= 0 && position[1] < bBoundry && position[0] >= 0 && position[0] < aBoundry)
            {
                bool turn = false;
                bool skip = false;
                if (data[position[0]][position[1]] == '#')
                {
                    turn = true;
                    skip = true;
                }                    
                else if(data[position[0]][position[1]] == 'X')
                {
                    skip = true;
                }                    

                int[] move = [0, 0];
                switch (direction)
                {
                    case '^':
                        if (turn) //發現撞壁就退回重走
                        {
                            direction = '>';
                            move = [1, 1];
                        }
                        else
                            move = [-1, 0];                        
                        break;
                    case '>':
                        if (turn)
                        {
                            direction = 'v';
                            move = [1, -1];
                        }
                        else
                            move = [0, 1];
                        break;
                    case 'v':
                        if (turn)
                        {
                            direction = '<';
                            move = [-1, -1];
                        }
                        else
                            move = [1, 0];
                        break;
                    case '<':
                        if (turn)
                        {
                            direction = '^';
                            move = [-1, 1];
                        }
                        else
                            move = [0, -1];
                        break;
                    default:
                        position = [-9, -9];
                        break;
                }

                if (!skip)
                {
                    data[position[0]][position[1]] = 'X';
                    sum++;
                }

                position[0] += move[0];
                position[1] += move[1];
            }

            return sum;
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
        private int[] GetPosition(char[][] data)
        {
            int[] position = [-1, -1];
            for (int a = 0; a < data.Length; a++)
            {
                for (int b = 0; b < data[0].Length; b++)
                {
                    if (data[a][b] == '^')
                    {
                        position = [a, b];
                        break;
                    }
                }
            }
            return position;
        }
        public int GetLoopSum(string input)
        {
            //就是在走做的路徑上都放放看結果，也是暴力解，要跑數秒
            //目前觀察到的是，走過的路都要嘗試應應該是不可避免的測試
            //目前優化有一個方向            
            //紀錄走的[step]和當時的[方向]，在測試loop時有走上老路就算是Loop，但在這每次測試時都要有新一段紀錄記錄新走的路，舊的Path可以持續拿來比對，所以可能有兩組hashset，在圖更大時感覺判斷Loop效果會更好
            //然後目前是寫死Loop判斷的上限，除了優化的辦法，也不確定有沒有更合理的判斷
            char[][] data = GetData(input);
            int[] position = GetPosition(data);
            
            Tuple<int, int> start = new Tuple<int, int>(position[0], position[1]);
            HashSet<Tuple<int, int>> map = GetMap(data, position);
            map.Remove(start); //can not set obstacle at start point

            int sum = 0;            
            foreach (Tuple<int, int> point in map)
            {
                position[0] = start.Item1; position[1] = start.Item2;//reset start point at begining
                data[point.Item1][point.Item2] = '#';
                if(IsLoop(data))
                    sum++;
                data[point.Item1][point.Item2] = '.';
            }

            return sum;

            //下面這兩個方法應該能一定程度上的共用，但因為想速度快一點就沒特別做也懶得想
            HashSet<Tuple<int,int>> GetMap(char[][] _data, int[] _position)
            {                
                HashSet <Tuple<int, int>> result = new HashSet<Tuple<int, int>>();
                int[][] moves = [[-1, 0], [0, 1], [1, 0], [0, -1]];
                int direction = 0;
                
                int aBoundry = _data.Length;
                int bBoundry = _data[0].Length;
                int step = 0;
                int[] tempPosition = new int[2];
                while (true)
                {
                    int moveIndex = direction % 4;                    
                    tempPosition[0] = position[0] + moves[moveIndex][0];
                    tempPosition[1] = position[1] + moves[moveIndex][1];

                    //check outside
                    if (tempPosition[0] < 0 || tempPosition[0] >= aBoundry || tempPosition[1] < 0 || tempPosition[1] >= bBoundry)
                        break; 

                    //check turn
                    if (data[tempPosition[0]][tempPosition[1]] == '#')
                    {
                        direction++;
                        continue;
                    }

                    position[0] = tempPosition[0];
                    position[1] = tempPosition[1];
                    result.Add(new Tuple<int, int>(_position[0], _position[1]));
                    step++;
                    //check loop
                    if (step > 100000)
                        break;
                }
                return result;
            }
            bool IsLoop(char[][] _data)
            {
                int[][] moves = [[-1, 0], [0, 1], [1, 0], [0, -1]];
                int direction = 0;

                int aBoundry = _data.Length;
                int bBoundry = _data[0].Length;
                int step = 0;
                int[] tempPosition = new int[2];
                while (true)
                {
                    int moveIndex = direction % 4;
                    tempPosition[0] = position[0] + moves[moveIndex][0];
                    tempPosition[1] = position[1] + moves[moveIndex][1];

                    //check outside
                    if (tempPosition[0] < 0 || tempPosition[0] >= aBoundry || tempPosition[1] < 0 || tempPosition[1] >= bBoundry)
                        return false;

                    //check turn
                    if (data[tempPosition[0]][tempPosition[1]] == '#')
                    {
                        direction++;
                        continue;
                    }

                    position[0] = tempPosition[0];
                    position[1] = tempPosition[1];
                    step++;
                    //check loop
                    if (step > 100000)
                        break;
                }

                return true;
            }
        }

    }
}
