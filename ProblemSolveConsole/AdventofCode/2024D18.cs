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
                Console.WriteLine(GetByte(input, 2500, 71));
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
        public string GetByte(string input, int passBytes, int sideLength)
        {
            //兩種方法
            //1.記錄每條到達路徑，每次新阻擋落下橫掃每個路徑檢查
            //2.紀錄每條到達路徑的代號(hash)，並標註在地圖上([][] + list ? or dictionary < (,) + list >)，每次落下就依照標註在地圖的代號扣去hash

            bool[][] records = new bool[sideLength][];
            for (int i = 0; i < records.Length; i++)
            {
                records[i] = new bool[sideLength];
            }

            List<(int x, int y)> datas = GetData(input);
            //records[0][0] = true; 這個DFS是進去的點還沒走，所以不能標記start
            #region 使用passBytes偷吃步
            //結論是這個方法跑不完，用偷吃步先偷丟2500個障礙才過了
            //for (int i = 0; i < passBytes; i++)
            //{
            //    (int x, int y) data = datas[i];
            //    records[data.x][data.y] = true;
            //}

            //List<HashSet<(int x, int y)>> paths = GetPaths(records, (0, 0), (records.Length - 1, records.Length - 1));
            //for (int i = passBytes; i < datas.Count; i++)
            //{
            //    (int x, int y) data = datas[i];
            //    for (int j = paths.Count - 1; j >= 0; j--) //從後向前才不會影響list排序
            //    {
            //        if (paths[j].Contains(data))
            //        {
            //            paths.RemoveAt(j);
            //        }
            //    }
            //    if (paths.Count == 0)
            //    {
            //        return data.x.ToString() + "," + data.y.ToString();
            //    }
            //}
            #endregion

            #region 逆過來檢查-但感覺DFSBFS外還有更佳解適用更大的地圖，但可能沒有這麼泛用所以想不出來
            //可以搭配二分搜由後往前升ByteXD => 好像不用，老實的逆過來檢查直到有通路的那個點就可以了@@，二分搜可能快一點，但地圖大一點好像比較容易運氣不好第一次就跑不完
            //二分搜 + BFS可以直接不用找全通路，但跟DFS應該最後不會差異到很大??
            for (int i = 0; i < datas.Count; i++)
            {
                (int x, int y) data = datas[i];
                records[data.x][data.y] = true;
            }

            for (int i = datas.Count - 1; i >= 0; i--)
            {
                //GetPaths有處理records消去紀錄，所以可以重複用
                List<HashSet<(int x, int y)>> paths = GetPaths(records, (0, 0), (records.Length - 1, records.Length - 1));
                if(paths.Count > 0)
                {
                    if( i == datas.Count - 1)
                    {
                        return "";
                    }
                    else
                    {
                        //返回第一個導致沒出口的 => 上一個
                        (int x, int y) lastBlock = datas[i + 1];
                        return lastBlock.x.ToString() + "," + lastBlock.y.ToString();
                    }
                }
                //慢慢移掉障礙測試是否有出口
                (int x, int y) data = datas[i];
                records[data.x][data.y] = false;
            }

            #endregion

            return "";
        }
        private List<HashSet<(int x, int y)>> GetPaths(bool[][] records, (int x, int y) start, (int x, int y) end)
        {
            
            int count = 0;
            List<HashSet<(int x, int y)>> result = new();
            HashSet<(int x, int y)> path = new(); //應該可以用hashset，理論上路徑不會重複
            DFS(start);

            return result;

            void DFS((int x, int y) position)
            {
                if (!CheckPosition(records, position))
                {
                    return;
                }

                if (position == end)
                {
                    result.Add(path.ToHashSet()); //複製一份到達路徑出來
                    return;
                }

                count++;
                path.Add(position);
                records[position.x][position.y] = true; //標記走過，確認現在的路線不會重複走

                //上下左右dfs
                foreach ((int x, int y) in new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    DFS((position.x + x, position.y + y));
                }

                path.Remove(position); 
                records[position.x][position.y] = false; //移除最後路徑讓下個經過的路徑用                
            }
        }
        
    }
}
