using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    //https://adventofcode.com/2024/day/3
    public class _2024D3 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D3.txt"))
            {
                string data = sr.ReadToEnd();
                Console.WriteLine(GetSum(data));
                Console.WriteLine(GetSumWithInstructions(data));
            }
        }
        public long GetSum(string input)
        {
            long result = 0;
            //Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)"); //用這算出來反而沒對，可能GetValueFromDirection寫錯了
            Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");//使用捕獲組
            MatchCollection matches = regex.Matches(input);

            foreach(Match match in matches)
            {
                //string[] pair = match.Value.Split(',');
                //result += (GetValueFromDirection('L', pair[0]) * GetValueFromDirection('R', pair[1]));
                result += (Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value));
            }

            return result;

            int GetValueFromDirection(char _direction, string _input)
            {
                string valueStr = "";
                if (_direction == 'L')
                {
                    for(int i = _input.Length-1; i >= 0; i--)
                    {
                        if (char.IsDigit(_input[i]))
                            valueStr = _input[i] + valueStr; //右到左依序，加在左邊
                        else
                            break;
                    }
                }                    
                else if (_direction == 'R')
                {
                    for (int i = 0; i < _input.Length; i++)
                    {
                        if (char.IsDigit(_input[i]))
                            valueStr = valueStr + _input[i]; //左到右依序，加在右邊
                        else
                            break;
                    }
                }

                return Convert.ToInt32(valueStr);
            }
        }
        public long GetSumWithInstructions(string input)
        {
            long result = 0;
            bool ignore = false;
            Regex regex = new Regex(@"do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\)");//使用捕獲組
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                if (match.Value == "do()")
                    ignore = false;
                else if (match.Value == "don't()")
                    ignore = true;
                else
                {
                    if(!ignore)
                        result += (Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value));
                }                    
            }

            return result;
        }
    }
}
