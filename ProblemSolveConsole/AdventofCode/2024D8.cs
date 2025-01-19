using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D8 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D8.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetAntinodeSum(input));
                Console.WriteLine(GetAntinodeSum2(input));
            }
        }
        public int GetAntinodeSum(string input)
        {
            char[][] data = GetData(input);
            HashSet<Tuple<int,int>> locations = new HashSet<Tuple<int,int>>();

            Dictionary<char, List<Tuple<int, int>>> antennaMap = new Dictionary<char, List<Tuple<int, int>>>();

            int aBoundary = data.Length;
            int bBoundary = data[0].Length;

            //create map
            for (int i = 0; i < aBoundary; i++)
            {
                for (int j = 0; j < bBoundary; j++)
                {
                    if (char.IsDigit(data[i][j]) || char.IsLower(data[i][j]) || char.IsUpper(data[i][j]))
                    {
                        if (antennaMap.ContainsKey(data[i][j]))
                            antennaMap[data[i][j]].Add(new Tuple<int, int>(i, j));
                        else
                            antennaMap[data[i][j]] = new List<Tuple<int, int>>() { new Tuple<int, int>(i, j) };
                    }
                }
            }

            //slide window check antinode
            foreach(char key in antennaMap.Keys)
            {
                var antennas = antennaMap[key];//如果List長度只有1也會因for迴圈判斷直接跳掉不會出exception
                for(int i = 0; i < antennas.Count - 1; i++)
                {
                    for(int j = i + 1; j < antennas.Count; j++) 
                    {
                        //check two side base on i point
                        //distance = j - i
                        Tuple<int, int> distance = new Tuple<int, int>(antennas[j].Item1 - antennas[i].Item1, antennas[j].Item2 - antennas[i].Item2);
                        //far side = i + 2*distance
                        Tuple<int, int> farSide = new Tuple<int, int>(antennas[i].Item1 + 2 * distance.Item1, antennas[i].Item2 + 2 * distance.Item2);
                        if (farSide.Item1 >= 0 && farSide.Item1 < aBoundary && farSide.Item2 >= 0 && farSide.Item2 < bBoundary)
                            locations.Add(farSide);

                        //near side = i - distance
                        Tuple<int, int> nearSide = new Tuple<int, int>(antennas[i].Item1 - distance.Item1, antennas[i].Item2 - distance.Item2);
                        if (nearSide.Item1 >= 0 && nearSide.Item1 < aBoundary && nearSide.Item2 >= 0 && nearSide.Item2 < bBoundary)
                            locations.Add(nearSide);
                    }
                }
            }

            return locations.Count;
        }
        public int GetAntinodeSum2(string input)
        {
            char[][] data = GetData(input);
            HashSet<Tuple<int, int>> locations = new HashSet<Tuple<int, int>>();

            Dictionary<char, List<Tuple<int, int>>> antennaMap = new Dictionary<char, List<Tuple<int, int>>>();

            int aBoundary = data.Length;
            int bBoundary = data[0].Length;

            //create map
            for (int i = 0; i < aBoundary; i++)
            {
                for (int j = 0; j < bBoundary; j++)
                {
                    if (char.IsDigit(data[i][j]) || char.IsLower(data[i][j]) || char.IsUpper(data[i][j]))
                    {
                        if (antennaMap.ContainsKey(data[i][j]))
                            antennaMap[data[i][j]].Add(new Tuple<int, int>(i, j));
                        else
                            antennaMap[data[i][j]] = new List<Tuple<int, int>>() { new Tuple<int, int>(i, j) };
                    }
                }
            }

            //超多層迴圈...但感覺也不算完全錯...
            //slide window check antinode
            foreach (char key in antennaMap.Keys)
            {
                var antennas = antennaMap[key];//如果List長度只有1也會因for迴圈判斷直接跳掉不會出exception

                if(antennas.Count > 1)
                {
                    for (int i = 0; i < antennas.Count; i++)                    
                        locations.Add(antennas[i]);//只要成line的antenna都算     
                }

                for (int i = 0; i < antennas.Count - 1; i++)
                {
                    for (int j = i + 1; j < antennas.Count; j++)
                    {
                        //check two side base on i point
                        //distance = j - i
                        Tuple<int, int> distance = new Tuple<int, int>(antennas[j].Item1 - antennas[i].Item1, antennas[j].Item2 - antennas[i].Item2);
                        //far side = i + 2*distance
                        int[] farSide = [antennas[i].Item1 + 2 * distance.Item1, antennas[i].Item2 + 2 * distance.Item2];
                        while(farSide[0] >= 0 && farSide[0] < aBoundary && farSide[1] >= 0 && farSide[1] < bBoundary)
                        {
                            locations.Add(new Tuple<int, int>(farSide[0], farSide[1]));
                            farSide[0] += distance.Item1;
                            farSide[1] += distance.Item2;
                        }


                        //near side = i - distance
                        int[] nearSide = [antennas[i].Item1 - distance.Item1, antennas[i].Item2 - distance.Item2];
                        while (nearSide[0] >= 0 && nearSide[0] < aBoundary && nearSide[1] >= 0 && nearSide[1] < bBoundary)
                        {
                            locations.Add(new Tuple<int, int>(nearSide[0], nearSide[1]));
                            nearSide[0] -= distance.Item1;
                            nearSide[1] -= distance.Item2;
                        }
                    }
                }
            }

            return locations.Count;
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
