using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D11 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D11.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetStonesCountResursive(input));
                Console.WriteLine(GetScoresIterative(input));
                Console.WriteLine(GetScores(input, 75));
            }
        }
        public int GetStonesCountResursive(string input)
        {
            string[] stones = input.TrimEnd('\n').Split(' '); //...這個\n髒資料沒跳錯...還會影響答案orz
            int count = 0;
            foreach (string stone in stones)
                count += Resursive(stone, 0, 25);

            return count;
            int Resursive(string _stone, int _blinkingTimes, int _blinkingGoal)
            {
                if (_blinkingTimes == _blinkingGoal) 
                    return 1;

                if (Convert.ToInt64(_stone) == 0)
                    return Resursive("1", _blinkingTimes + 1, _blinkingGoal);
                else if(_stone.Length % 2 == 0)
                {
                    return
                        Resursive(_stone.Substring(0, _stone.Length/2), _blinkingTimes + 1, _blinkingGoal) +
                        Resursive(Convert.ToInt64(_stone.Substring(_stone.Length / 2)).ToString(), _blinkingTimes + 1, _blinkingGoal);
                }

                return Resursive((Convert.ToInt64(_stone) * 2024).ToString(), _blinkingTimes + 1, _blinkingGoal);
            }
        }
        public long GetScoresIterative(string input)
        {
            long[] stones = input.TrimEnd('\n').Split(' ').Select(x=>Convert.ToInt64(x)).ToArray(); //...這個\n髒資料沒跳錯...還會影響答案orz
            int blinkingGoal = 25;
            long count = 0;
            Stack<long[]> stack = new Stack<long[]>();
            foreach (long stone in stones)
            {
                stack.Push([stone, 0]);
                while(stack.Count > 0)
                {
                    long[] current = stack.Pop();
                    while (current[1] < blinkingGoal)
                    {
                        current[1]++; //因為stack push 時要記錄所以放在while開頭

                        if (current[0] == 0)
                            current[0] = 1;
                        else if (current[0].ToString().Length % 2 == 0)
                        {
                            string currentStr = current[0].ToString();
                            int splitPoint = currentStr.Length / 2;
                            current[0] = Convert.ToInt64(currentStr.Substring(0, splitPoint));
                            stack.Push([Convert.ToInt64(currentStr.Substring(splitPoint)), current[1]]);
                        }
                        else
                            current[0] *= 2024;
                    }
                    count++;
                }
            }
                
            return count;
        }
        //前面兩種方法都算爆力解，當stone是指數型成長就爆開了，已知45次都要幾分鐘
        //這個方法是相同的可以一起做計算，因為order並不重要，75次也是幾毫秒只有37XX多種石頭，如果數字碎片化很嚴重，這個速度應該也會變慢畢竟每次要重做dictionary
        //gpt還有建議用Parallel，但應該也算暴力解
        //reference : https://github.com/SubNet32/AoC2024_PY/tree/main/days/day11
        public long GetScores(string input, int blinkingGoal)
        {
            //...這個\n髒資料沒跳錯...還會影響答案orz
            Dictionary<long, long> stones = input.TrimEnd('\n').Split(' ')
                .Select(x => Convert.ToInt64(x))
                .ToDictionary(
                    key => key,
                    item => (long)1
                );
            
            for(int i = 0; i < blinkingGoal; i++)
            {
                Dictionary<long, long> tempStones = new Dictionary<long, long>();
                //rule 1
                long newStoneOne = 0;
                stones.TryGetValue(0, out newStoneOne);
                if(newStoneOne > 0)
                {
                    tempStones.Add(1, newStoneOne);
                    stones.Remove(0);
                }                
                //rule 2 and rule 3
                foreach(KeyValuePair<long, long> stone in stones)
                {
                    if(stone.Key.ToString().Length % 2 == 0)
                    {
                        string stoneStr = stone.Key.ToString();
                        int splitPoint = stoneStr.Length / 2;
                        AddToDictionary(tempStones, Convert.ToInt64(stoneStr.Substring(0, splitPoint)), stone.Value);
                        AddToDictionary(tempStones, Convert.ToInt64(stoneStr.Substring(splitPoint)), stone.Value);
                    }
                    else
                    {
                        AddToDictionary(tempStones, stone.Key * 2024, stone.Value);
                    }
                }
                stones = tempStones;
            }
            return stones.Sum(x=>x.Value);
            void AddToDictionary(Dictionary<long, long> _dictionary, long _key, long _value)
            {
                if(_dictionary.ContainsKey(_key))
                    _dictionary[_key] += _value; //因為要用加法所以寫不了泛型@@
                else
                    _dictionary[_key] = _value;
            }
        }
    }
}
