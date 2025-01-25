using ProblemSolveConsole.Interface;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D12 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D12.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetPrice(input));
                Console.WriteLine(GetDiscountPrice(input));
            }
        }
        public int GetPrice(string input)
        {
            char[][] data = GetData(input);
            int[][] map = new int[data.Length][];
            Dictionary<int, int[]> record = new Dictionary<int, int[]>(); //[area,perimeter]
            for (int i = 0; i < data.Length; i++)
                map[i] = new int[data[i].Length];


            int regionIndex = 1; //0是default, region 1 開始
            for (int i = 0; i < data.Length; i++)
            {
                for(int j = 0; j < data[i].Length; j++)
                {
                    int currentRegion = map[i][j];
                    if(currentRegion == 0)
                    {
                        currentRegion = regionIndex;
                        regionIndex++;
                    }
                    int fences = MarkMap(data, map, i, j, currentRegion, 0);
                    

                    if (record.ContainsKey(currentRegion))
                    {
                        record[currentRegion][0]++;
                        record[currentRegion][1] += fences;
                    }
                    else
                        record[currentRegion] = [1, fences];
                }
            }

            int sum = 0;
            foreach(KeyValuePair<int, int[]> pair in record)            
                sum += pair.Value[0] * pair.Value[1];
            
            return sum;
            //感覺floodfill跟union很相近@@，如果不一次做完每次都只檢查上下左右【一次】，第一次沒做到的相同的region在不同次檢查遇到會視作不同region，所以要一次fill到底
            int MarkMap(char[][] _data, int[][] _map, int _aIndex, int _bIndex, int _region, int _fences)
            {
                if (_map[_aIndex][_bIndex] != 0) return _fences;
                _map[_aIndex][_bIndex] = _region;
                //up
                if (_aIndex - 1 >= 0 && _data[_aIndex][_bIndex] == _data[_aIndex - 1][_bIndex])
                    _fences = MarkMap(_data, _map, _aIndex - 1, _bIndex, _region, _fences);
                else
                    _fences++;
                //down
                if (_aIndex + 1 < _data.Length && _data[_aIndex][_bIndex] == _data[_aIndex + 1][_bIndex])
                    _fences = MarkMap(_data, _map, _aIndex + 1, _bIndex, _region, _fences);
                else
                    _fences++;
                //left
                if (_bIndex - 1 >= 0 && _data[_aIndex][_bIndex] == _data[_aIndex][_bIndex - 1])
                    _fences = MarkMap(_data, _map, _aIndex, _bIndex - 1, _region, _fences);
                else
                    _fences++;
                //right
                if (_bIndex + 1 < _data[_aIndex].Length && _data[_aIndex][_bIndex] == _data[_aIndex][_bIndex + 1])
                    _fences = MarkMap(_data, _map, _aIndex, _bIndex + 1, _region, _fences);
                else
                    _fences++;

                return _fences;
            }
        }
        //https://www.reddit.com/r/adventofcode/comments/1hex153/2024_day_12_if_you_struggle_with_part_2/
        public int GetDiscountPrice(string input)
        {
            char[][] data = GetData(input);
            int[][] map = new int[data.Length][];
            Dictionary<int, int[]> record = new Dictionary<int, int[]>();
            for (int i = 0; i < data.Length; i++)
                map[i] = new int[data[i].Length];


            int regionIndex = 1; //0是default, region 1 開始
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    int currentRegion = map[i][j];
                    if (currentRegion == 0)
                    {
                        currentRegion = regionIndex;
                        regionIndex++;
                    }
                    MarkMap(data, map, i, j, currentRegion);
                    if (record.ContainsKey(currentRegion))
                        record[currentRegion][0]++;
                    else
                        record[currentRegion] = [1, 0];
                }
            }

            for(int i = 0; i < map.Length; i++)
                for(int j = 0;j < map[i].Length; j++)
                    record[map[i][j]][1] += GetRecordSide(map, i, j);

            int sum = 0;
            foreach (KeyValuePair<int, int[]> pair in record)
                sum += pair.Value[0] * pair.Value[1];
            return sum;
            //感覺floodfill跟union很相近@@，如果不一次做完每次都只檢查上下左右【一次】，第一次沒做到的相同的region在不同次檢查遇到會視作不同region，所以要一次fill到底
            void MarkMap(char[][] _data, int[][] _map, int _i, int _j, int _region)
            {
                if (_map[_i][_j] != 0) return;
                _map[_i][_j] = _region;
                //up
                if (_i - 1 >= 0 && _data[_i][_j] == _data[_i - 1][_j])
                    MarkMap(_data, _map, _i - 1, _j, _region);
                //down
                if (_i + 1 < _data.Length && _data[_i][_j] == _data[_i + 1][_j])
                    MarkMap(_data, _map, _i + 1, _j, _region);
                //left
                if (_j - 1 >= 0 && _data[_i][_j] == _data[_i][_j - 1])
                    MarkMap(_data, _map, _i, _j - 1, _region);
                //right
                if (_j + 1 < _data[_i].Length && _data[_i][_j] == _data[_i][_j + 1])
                    MarkMap(_data, _map, _i, _j + 1, _region);
            }
            int GetRecordSide(int[][] _map, int _i, int _j)
            {
                //幾個corner就會算出幾個side
                //一個點最多0~4個corner(NE、SE...)
                //只有凸角(兩個相鄰點都不同)或凹角(兩個相鄰點相同，但對角點要不同)有corner
                int corner = 0;
                //true : same ; false : different
                bool N = _i - 1 >= 0 && _map[_i][_j] == _map[_i - 1][_j];
                bool NE = _i - 1 >= 0 && _j + 1 < _map[_i].Length && _map[_i][_j] == _map[_i - 1][_j + 1];
                bool E = _j + 1 < _map[_i].Length && _map[_i][_j] == _map[_i][_j + 1];
                bool SE = _i + 1 < _map.Length && _j + 1 < _map[_i].Length && _map[_i][_j] == _map[_i + 1][_j + 1];
                bool S = _i + 1 < _map.Length && _map[_i][_j] == _map[_i + 1][_j];
                bool SW = _i + 1 < _map.Length && _j - 1 >= 0 && _map[_i][_j] == _map[_i + 1][_j - 1];
                bool W = _j - 1 >= 0 && _map[_i][_j] == _map[_i][_j - 1];
                bool NW = _i - 1 >= 0 && _j - 1 >= 0 && _map[_i][_j] == _map[_i - 1][_j - 1];
                
                //check是否為 凸角 或 凹角
                //NW
                if ( (!N && !W) || (N && W && !NW)) corner++;
                //NE
                if ((!N && !E) || (N && E && !NE)) corner++;
                //SW
                if ((!S && !W) || (S && W && !SW)) corner++;
                //SE
                if ((!S && !E) || (S && E && !SE)) corner++;
                return corner;
            }
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
