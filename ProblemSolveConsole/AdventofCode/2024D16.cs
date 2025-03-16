using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D16 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D16.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetLowestScorePath(input));
            }
        }
        public int GetLowestScorePath(string input)
        {
            

            //1.轉彎時不看目前方向，只有3個轉彎 + 前進共4個選項  (來時路(後來想說就不特別處理讓score去過濾就好))
            //2.到達過的點如果高於對應方向最低score就不必再走，使用priority queue快速記錄最低分
            //3.死路時不會增加新資訊
            //4.如果終點score低於目前物件就不比了
            PriorityQueue<Point,int> queue = new PriorityQueue<Point,int>();
            //int[] 0:^ , 1:V , 2:< , 3:>
            Dictionary<Tuple<int, int>, int[]> record = new Dictionary<Tuple<int, int>, int[]>();
            int[][] move = new int[4][] { [-1, 0], [1, 0], [0, -1], [0, 1] };
            int[] startPosition;
            int[] endPosition; //因為直接用data了，好像沒用到
            char[][] data = GetData(input,out startPosition, out endPosition);

            //處理起始點
            Point startPoint = new Point()
            {
                RPosition = startPosition[0],
                CPosition = startPosition[1],
                Direction = Direction.Right
            };

            queue.Enqueue(startPoint, 0);

            //開始比較
            int minScore = Int32.MaxValue;

            while (queue.TryDequeue(out Point point, out int score))
            {
                //判斷是否比較
                //1.score
                if (score > minScore)
                {
                    continue;
                }
                //2.record
                Tuple<int, int> position = Tuple.Create(point.RPosition, point.CPosition);
                if (record.ContainsKey(position))
                {
                    if (score >= record[position][(int)point.Direction])
                    {
                        continue;
                    }
                    else //更新最小record
                    {
                        record[position][(int)point.Direction] = score;
                    }
                }
                else //更新record
                {
                    record[position] = new int[4] {Int32.MaxValue, Int32.MaxValue , Int32.MaxValue , Int32.MaxValue };
                    record[position][(int)point.Direction] = score;
                }

                //&& data[point.RPosition][point.CPosition] != '#'
                //新增queue、判斷終點                
                //轉彎(不會到終點，也不會超出範圍)
                //處理4個方向
                if (point.Direction != Direction.Up)
                {
                    Point newPoint = point.ShallowCopy();
                    newPoint.Direction = Direction.Up;
                    queue.Enqueue(newPoint, score+1000);
                }

                if (point.Direction != Direction.Down)
                {
                    Point newPoint = point.ShallowCopy();
                    newPoint.Direction = Direction.Down;
                    queue.Enqueue(newPoint, score + 1000);
                }

                if (point.Direction != Direction.Left)
                {
                    Point newPoint = point.ShallowCopy();
                    newPoint.Direction = Direction.Left;
                    queue.Enqueue(newPoint, score + 1000);
                }

                if (point.Direction != Direction.Right)
                {
                    Point newPoint = point.ShallowCopy();
                    newPoint.Direction = Direction.Right;
                    queue.Enqueue(newPoint, score + 1000);
                }

                //處理前進(可能到終點，也可超出範圍)
                int newRPosition = point.RPosition + move[(int)point.Direction][0];
                int newCPosition = point.CPosition + move[(int)point.Direction][1];
                //判斷超出範圍
                if (newRPosition >= 0 && newRPosition < data.Length && newCPosition >= 0 && newCPosition < data[0].Length)
                {
                    //判斷死路
                    if (data[newRPosition][newCPosition] == '#')
                    {
                        continue;
                    }

                    int newScore = score + 1;
                    //判斷終點
                    if (data[newRPosition][newCPosition] == 'E')
                    {
                        minScore = newScore < minScore? newScore : minScore;
                    }
                    else
                    {
                        point.RPosition = newRPosition;
                        point.CPosition = newCPosition;
                        queue.Enqueue(point, newScore);
                    }
                }
            }

            return minScore;
        }

        public class Point()
        {
            public int RPosition;
            public int CPosition;
            public Direction Direction;

            public Point ShallowCopy()
            {
                return (Point)this.MemberwiseClone();  // 產生淺拷貝
            }
        }

        public enum Direction
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3,
            None = 4
        }

        private char[][] GetData(string input, out int[] startPosition, out int[] endPosition)
        {
            startPosition = new int[2];
            endPosition = new int[2];
            char[][] data = null;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 0;
                while (line != null && line != "")
                {
                    char[] chars = line.ToCharArray();
                    if (count == 0)
                    {
                        data = new char[chars.Length][];
                    }                        
                    else if (line.IndexOf('S') >= 0)
                    {
                        startPosition = [count, line.IndexOf('S')];
                    }
                    else if (line.IndexOf('E') >= 0)
                    {
                        endPosition = [count, line.IndexOf('E')];
                    }


                    data[count] = chars;
                    count++;
                    line = sr.ReadLine();
                }
            }
            return data;
        }
    }
}
