using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    //https://adventofcode.com/2024/day/2
    public class _2024D2 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D2.txt"))
            {
                string data = sr.ReadToEnd();
                Console.WriteLine(GetSafeReports(data));
            }
        }
        public int GetSafeReports(string input)
        {
            int safeReports = 0; // answer
            string _content = input.TrimEnd('\n'); //original content and trim dirty data, the input give the empty line at the end
            int _position = 0; //reading position
            bool lineEnd = false; //check read to line end
            bool checkFail = false;
            int? checkNumber = null;
            char direction = ' '; // ' ','-','+'

            char[] charsToJump = { ' ', '\r', '\n' };

            while (_position < _content.Length)
            {
                //read next point
                int checkPoint = _content.IndexOfAny(charsToJump, _position);
                if (checkPoint == -1) //content end
                    break;
                
                //check number
                int number = Convert.ToInt32(_content.Substring(_position, checkPoint - _position));
                checkFail = CheckFail(number);

                //new position
                _position = checkPoint + 1; //will jump across charsToJump

                // deal \n                    
                if (_content[_position] == '\n' || _content[checkPoint] == '\n')
                {
                    lineEnd = true;
                    _position += _content[checkPoint] == '\n' ? 0 : 1;
                }            
                        

                if (checkFail) //deal fail first
                {
                    if (!lineEnd)
                    {
                        //read next line
                        int nextLine = _content.IndexOf('\n', _position);
                        if (nextLine == -1)
                            break;
                        _position = nextLine + 1;
                        lineEnd = true;
                    }
                    Initialize();
                }
                else if (lineEnd)
                {
                    safeReports++;
                    Initialize();
                }                
            }

            //last number check
            if(!checkFail && CheckFail(Convert.ToInt32(_content.Substring(_position))) == false)
                safeReports++;

            return safeReports;

            void Initialize()
            {
                checkNumber = null;
                direction = ' ';
                checkFail = false; //two true can happen same time
                lineEnd = false;
            }
            bool CheckFail(int input)
            {
                switch (direction)
                {
                    case ' ':
                        if (checkNumber == null)
                            checkNumber = input;
                        else                        
                            if (checkNumber > input && checkNumber - input <= 3)
                                direction = '-';
                            else if (checkNumber < input && input - checkNumber <= 3)
                                direction = '+';
                            else
                                return true;                        
                        break;
                    case '-':
                        if (!(checkNumber > input && checkNumber - input <= 3))
                            return true;
                        break;
                    case '+':
                        if (!(checkNumber < input && input - checkNumber <= 3))
                            return true;
                        break;
                    default:
                        return true;
                }

                checkNumber = input;
                return false;
            }
        }
    }
}
