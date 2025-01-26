using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D13 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D13.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetTokens(input));
                Console.WriteLine(GetTokens2(input));
            }
        }
        public decimal GetTokens(string input)
        {
            List<Equation[]> equationLst = GetEquation(input);

            decimal sum = 0;
            foreach (Equation[] equations in equationLst)
            {
                (decimal x, decimal y) = SolveEquation(equations[0], equations[1]);

                //need to be positive integer
                //each button would need to be pressed no more than 100 times to win a prize
                if (x == 0 && y == 0)
                    continue;
                if (x % 1 == 0 && y % 1 == 0 && x <= 100 && y <= 100 && x >= 0 && y >= 0)
                    sum += (x * 3 + y);
            }

            return sum;
        }
        private List<Equation[]> GetEquation(string input)
        {
            List<Equation[]> result = new List<Equation[]>();
            Equation equation1 = new Equation();
            Equation equation2 = new Equation();
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 1;
                while (line != null)
                {
                    if(line != "")
                    {
                        if(count == 1)
                        {
                            equation1.A = ExtractNumber(line, line.IndexOf('+')+1);
                            equation2.A = ExtractNumber(line, line.LastIndexOf('+') + 1);
                        }
                        else if(count == 2)
                        {
                            equation1.B = ExtractNumber(line, line.IndexOf('+') + 1);
                            equation2.B = ExtractNumber(line, line.LastIndexOf('+') + 1);
                        }
                        else if (count == 3)
                        {
                            equation1.C = ExtractNumber(line, line.IndexOf('=') + 1);
                            equation2.C = ExtractNumber(line, line.LastIndexOf('=') + 1);
                        }
                    }
                    else
                    {
                        count = 0;
                        result.Add([equation1, equation2]);
                        equation1 = new Equation();
                        equation2 = new Equation();
                    }
                    count++;
                    line = sr.ReadLine();
                }
                result.Add([equation1, equation2]); //最後一個要記得加上...ORZ前面沒檢查到找半天
            }

            return result;

            int ExtractNumber(string _line, int _startIndex)
            {
                string numStr = "";
                while (_startIndex < _line.Length && char.IsDigit(_line[_startIndex]))
                {
                    numStr += _line[_startIndex];
                    _startIndex++;
                }
                return Convert.ToInt32(numStr);
            }
        }
        public class Equation()
        {
            public decimal A { get; set; }
            public decimal B { get; set; }
            public decimal C { get; set; }
        }
        //寫完整一點可以參考這位
        //因為提物好像有特意用簡單的equation，所以型別其實不是問題，用int可能也可以
        //https://www.reddit.com/r/adventofcode/comments/1i20wpg/2024_day_13_what_if_the_buttons_are_linearly/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button
        //https://github.com/amundsno/advent-of-code-24/blob/48fd1b113ba9292a209d73b398948fc641585f36/day13/day13.py
        private (decimal x, decimal y) SolveEquation(Equation equation1, Equation equation2)
        {
            //這是問GPT的克拉默法則
            decimal d = equation1.A * equation2.B - equation2.A * equation1.B;

            //< 1e-10 代表接近0
            if (d != 0)//唯一解
            {
                decimal dx = (equation1.C * equation2.B - equation2.C * equation1.B);
                decimal dy = (equation1.A * equation2.C - equation2.A * equation1.C);

                if(dx % d == 0 && dy % d == 0)
                    return (dx / d, dy / d);
                return (0, 0);
            }
            else
            {
                return (0, 0);
                //這裡沒出現過，暫且先無視
                //if (Math.Abs(equation1.A * equation2.C - equation2.A * equation1.C) < 1e-10 && Math.Abs(equation1.B * equation2.C - equation2.B * equation1.C) < 1e-10)//無窮解
                //{                    
                //    return (0, 0); 
                //}
                //else//無解
                //{
                //    return ( 0, 0);
                //}
            }
        }
        //第二題沒有給Test，然後邏輯完全一樣，可能只是用int時會溢位?
        public decimal GetTokens2(string input)
        {
            List<Equation[]> equationLst = GetEquation2(input);

            decimal sum = 0;
            foreach (Equation[] equations in equationLst)
            {
                (decimal x, decimal y) = SolveEquation(equations[0], equations[1]);
                
                if (x == 0 && y == 0)
                    continue;
                if (x % 1 == 0 && y % 1 == 0 && x >= 0 && y >= 0)
                    sum += (x * 3 + y);
            }

            return sum;
        }
        private List<Equation[]> GetEquation2(string input)
        {
            List<Equation[]> result = new List<Equation[]>();
            Equation equation1 = new Equation();
            Equation equation2 = new Equation();
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                int count = 1;
                while (line != null)
                {
                    if (line != "")
                    {
                        if (count == 1)
                        {
                            equation1.A = ExtractNumber(line, line.IndexOf('+') + 1);
                            equation2.A = ExtractNumber(line, line.LastIndexOf('+') + 1);
                        }
                        else if (count == 2)
                        {
                            equation1.B = ExtractNumber(line, line.IndexOf('+') + 1);
                            equation2.B = ExtractNumber(line, line.LastIndexOf('+') + 1);
                        }
                        else if (count == 3)
                        {
                            equation1.C = ExtractNumber(line, line.IndexOf('=') + 1) + 10000000000000;
                            equation2.C = ExtractNumber(line, line.LastIndexOf('=') + 1) + 10000000000000;
                        }
                    }
                    else
                    {
                        count = 0;
                        result.Add([equation1, equation2]);
                        equation1 = new Equation();
                        equation2 = new Equation();
                    }
                    count++;
                    line = sr.ReadLine();
                }
                result.Add([equation1, equation2]); //最後一個要記得加上...ORZ前面沒檢查到找半天
            }

            return result;

            int ExtractNumber(string _line, int _startIndex)
            {
                string numStr = "";
                while (_startIndex < _line.Length && char.IsDigit(_line[_startIndex]))
                {
                    numStr += _line[_startIndex];
                    _startIndex++;
                }
                return Convert.ToInt32(numStr);
            }
        }
    }
}
