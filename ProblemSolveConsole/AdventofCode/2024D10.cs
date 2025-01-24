using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D10 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D10.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetScores(input));
                Console.WriteLine(GetScores2(input));
            }
        }
        public int GetScores(string input)
        {
            char[][] data = GetData(input);
            List < Tuple<int, int> > startPoints = GetStartPoints(data);
            int totalScores = 0;
            foreach(Tuple<int, int> startPoint in startPoints)
            {
                HashSet<Tuple<int, int>> scores = new HashSet<Tuple<int, int>>();
                DFS(data, startPoint.Item1, startPoint.Item2, 0, scores);
                totalScores += scores.Count;
            }

            return totalScores;
            char[][] GetData(string _input)
            {
                char[][] data = null;
                using (StringReader sr = new StringReader(_input))
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
            List<Tuple<int,int>> GetStartPoints(char[][] _data)
            {
                List<Tuple<int, int>> result = new List<Tuple<int,int>>();
                for(int i =0; i < _data.Length; i++)
                {
                    for(int j=0; j< _data[i].Length; j++)
                    {
                        if (_data[i][j] == '0')
                            result.Add(Tuple.Create(i, j));
                    }
                }
                return result;
            }
            //失敗的路徑之後不可能成功，成功的路徑之後必定成功，所以應該還能加入動態規劃超級加速(應該要用另一個class array 做紀錄)
            void DFS(char[][] _data, int _aIndex, int _bIndex, int _scale, HashSet<Tuple<int, int>> _scores)
            {
                if (Convert.ToInt32(_data[_aIndex][_bIndex].ToString()) != _scale) return;
                if(Convert.ToInt32(_data[_aIndex][_bIndex].ToString()) == 9)
                {
                    _scores.Add(Tuple.Create(_aIndex, _bIndex));
                    return;
                }
                if (_aIndex - 1 >= 0) DFS(_data, _aIndex - 1, _bIndex, _scale + 1, _scores);
                if (_aIndex + 1 < _data.Length) DFS(_data, _aIndex + 1, _bIndex, _scale + 1, _scores);
                if (_bIndex - 1 >= 0) DFS(_data, _aIndex, _bIndex - 1, _scale + 1, _scores);
                if (_bIndex + 1 < _data[_aIndex].Length) DFS(_data, _aIndex, _bIndex + 1, _scale + 1, _scores);
            }
        }
        public int GetScores2(string input)
        {
            char[][] data = GetData(input);
            List<Tuple<int, int>> startPoints = GetStartPoints(data);
            int totalScores = 0;
            foreach (Tuple<int, int> startPoint in startPoints)
                totalScores += DFS(data, startPoint.Item1, startPoint.Item2, 0, 0);

            return totalScores;
            char[][] GetData(string _input)
            {
                char[][] data = null;
                using (StringReader sr = new StringReader(_input))
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
            List<Tuple<int, int>> GetStartPoints(char[][] _data)
            {
                List<Tuple<int, int>> result = new List<Tuple<int, int>>();
                for (int i = 0; i < _data.Length; i++)
                {
                    for (int j = 0; j < _data[i].Length; j++)
                    {
                        if (_data[i][j] == '0')
                            result.Add(Tuple.Create(i, j));
                    }
                }
                return result;
            }
            //失敗的路徑之後不可能成功，成功的路徑之後必定成功，所以應該還能加入動態規劃超級加速(應該要用另一個class array 做紀錄)
            int DFS(char[][] _data, int _aIndex, int _bIndex, int _scale, int _score)
            {
                if (Convert.ToInt32(_data[_aIndex][_bIndex].ToString()) != _scale) 
                    return _score;
                if (Convert.ToInt32(_data[_aIndex][_bIndex].ToString()) == 9) 
                    return _score + 1;
                if (_aIndex - 1 >= 0)
                    _score = DFS(_data, _aIndex - 1, _bIndex, _scale + 1, _score);
                if (_aIndex + 1 < _data.Length)
                    _score = DFS(_data, _aIndex + 1, _bIndex, _scale + 1, _score);
                if (_bIndex - 1 >= 0)
                    _score = DFS(_data, _aIndex, _bIndex - 1, _scale + 1, _score);
                if (_bIndex + 1 < _data[_aIndex].Length)
                    _score = DFS(_data, _aIndex, _bIndex + 1, _scale + 1, _score);
                return _score;
            }
        }
    }
}
