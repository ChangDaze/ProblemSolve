using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D18 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D18.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetSteps(input, 1024, 71));
            }
        }
        public int GetSteps(string input, int passBytes, int sideLength)
        {
            Queue<(int x, int y, int step)> queue = new Queue<(int x, int y, int step)> ();
            bool[][] records = new bool[sideLength][];
            for(int i = 0; i < records.Length; i++)
            {
                records[i] = new bool[sideLength];
            }
            List<(int x, int y)> datas = GetData(input);
            for(int i = 0; i < passBytes; i++)
            {
                (int x, int y) data = datas[i];
                records[data.x][data.y] = true;
            }
            records[0][0] = true;
            queue.Enqueue((0, 0, 0));

            while(queue.Count > 0)
            {
                (int x, int y, int step) current = queue.Dequeue();
                if(current.x == records.Length - 1 && current.y == records.Length - 1)
                {
                    return current.step;
                }

                int nextStep = current.step + 1;
                if (CheckPosition(records, (current.x + 1, current.y)))
                {
                    queue.Enqueue((current.x + 1, current.y, nextStep));
                    records[current.x + 1][current.y] = true;
                }

                if (CheckPosition(records, (current.x - 1, current.y)))
                {
                    queue.Enqueue((current.x - 1, current.y, nextStep));
                    records[current.x - 1][current.y] = true;
                }

                if (CheckPosition(records, (current.x, current.y + 1)))
                {
                    queue.Enqueue((current.x, current.y + 1, nextStep));
                    records[current.x][current.y + 1] = true;
                }

                if (CheckPosition(records, (current.x, current.y - 1)))
                {
                    queue.Enqueue((current.x, current.y - 1, nextStep));
                    records[current.x][current.y - 1] = true;
                }
            }

            return -1;
        }
        private List<(int x, int y)> GetData(string input)
        {
            List<(int x, int y)> result = new();
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 0;
                int[] registers = new int[3];
                while (line != null)
                {
                    string[] position = line.Split(',');
                    result.Add((Convert.ToInt32(position[0]), Convert.ToInt32(position[1])));
                    line = sr.ReadLine();
                }
            }
            return result;
        }
        private bool CheckPosition(bool[][] records, (int x, int y) position)
        {
            if( position.x < 0 || position.y < 0)
            {
                return false;
            }

            if(position.x >= records.Length || position.y >= records.Length)
            {
                return false;
            }

            if (records[position.x][position.y])
            {
                return false;
            }

            return true;
        }
    }
}
