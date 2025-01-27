using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D07 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D07.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetValidSum(input));
                Console.WriteLine(GetValidSum2(input));
            }
        }
        public long GetValidSum(string input)
        {
            long sum = 0;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split(':');
                    long target = Convert.ToInt64(data[0]);

                    int[] numbers = data[1].TrimStart(' ').Split(' ').Select(x=>Convert.ToInt32(x)).ToArray();
                    if (Recursive(numbers[0], numbers, 1, target, false))
                        sum += target;

                    line = sr.ReadLine();
                }
            }

            return sum;

            //就是排列組合，不過這樣寫組合多了看起來會很亂，應該重構
            bool Recursive(long _result, int[] _numbers, int _index, long _target, bool _valid)
            {
                //check over
                if(_valid) return true;

                //check result
                if(_index == _numbers.Length)
                {
                    if(_result == _target) return true;
                    return false;
                }

                //calculate and recursive
                _valid = Recursive(_result + _numbers[_index], _numbers, _index + 1, _target, _valid);
                if(_valid) return true;
                return Recursive(_result * _numbers[_index], _numbers, _index + 1, _target, _valid);

            }           
        }
        public long GetValidSum2(string input)
        {
            long sum = 0;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split(':');
                    long target = Convert.ToInt64(data[0]);

                    StringNumber[] stringNumbers = data[1].TrimStart(' ').Split(' ')
                                                    .Select(x => new StringNumber() {
                                                        Str = x,
                                                        Number = Convert.ToInt32(x),
                                                        Digit = x.Length
                                                    }).ToArray();
                    if (Recursive(stringNumbers[0].Number, stringNumbers, 1, target, false))
                        sum += target;

                    line = sr.ReadLine();
                }
            }

            return sum;

            //就是排列組合，不過這樣寫組合多了看起來會很亂，應該重構
            bool Recursive(long _result, StringNumber[] _numbers, int _index, long _target, bool _valid)
            {
                //check over
                if (_valid) return true;

                //check result
                if (_index == _numbers.Length)
                {
                    if (_result == _target) return true;
                    return false;
                }

                //calculate and recursive
                _valid = Recursive(_result + _numbers[_index].Number, _numbers, _index + 1, _target, _valid);
                if (_valid) return true;
                _valid = Recursive(_result * _numbers[_index].Number, _numbers, _index + 1, _target, _valid);
                if (_valid) return true;
                return Recursive(_result * (int)Math.Pow(10, _numbers[_index].Digit) + _numbers[_index].Number, _numbers, _index + 1, _target, _valid);
            }
        }

        private class StringNumber()
        {
            public string Str { get; set; }
            public int Number { get; set; }
            public int Digit {  get; set; }
        }
    }
}
