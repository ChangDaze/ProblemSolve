using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                Console.WriteLine(GetSafeReportsWithDampener(data)); //因為想by字元處理解果導致程式複雜度一直上升，也很難維護，有點吃力不討好，也不確定有沒有全部情況都cover到
                Console.WriteLine(GetSafeReportsWithDampener2(data));
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
        public int GetSafeReportsWithDampener(string input)
        {
            int safeReports = 0; // answer (global value)
            string _content = input.TrimEnd('\n'); //original content and trim dirty data, the input give the empty line at the end
            int checkPoint = 0;
            int number = 0;
            int line = 1; //only for record not use
            PositionRecord currentPosition = new PositionRecord();

            char[] charsToJump = { ' ', '\r', '\n' };

            while (currentPosition.position < _content.Length)
            {
                //read next point
                checkPoint = _content.IndexOfAny(charsToJump, currentPosition.position);

                #region content end check last number 
                if (checkPoint == -1)
                {                    
                    number = Convert.ToInt32(_content.Substring(currentPosition.position));
                    DealReport(number, currentPosition, checkPoint, true);
                    if (!currentPosition.checkFail)
                        safeReports++;                    
                    break;
                }
                #endregion
                #region check number
                number = Convert.ToInt32(_content.Substring(currentPosition.position, checkPoint - currentPosition.position));
                DealReport(number, currentPosition, checkPoint);
                #endregion

                #region deal report result
                if (currentPosition.checkFail) 
                {
                    if (!currentPosition.lineEnd)
                    {
                        //read next line
                        int nextLine = _content.IndexOf('\n', currentPosition.position);
                        if (nextLine == -1)
                            break;
                        currentPosition.position = nextLine + 1;
                        currentPosition.lineEnd = true;
                    }
                }
                
                if (currentPosition.lineEnd)
                {
                    if (!currentPosition.checkFail)
                    {
                        Console.WriteLine($"{line} {number}");
                        safeReports++;
                    }
                    currentPosition.LineStartReset();
                    currentPosition.ignoreFirstTry = false;
                    currentPosition.lineStartPosition = currentPosition.position;
                    line++;
                }
                #endregion
            }

            return safeReports;            
            void DealReport(int _inputNumber, PositionRecord _inputPosition, int _checkPoint, bool _contentEnd = false)
            {
                char useDirection = _inputPosition.direction;
                int newPosition = _inputPosition.position;
                bool lineEnd = _inputPosition.lineEnd;
                //_inputNumber、 useDirection are temp variables to have space for previous check data
                CheckReport(_inputNumber, _inputPosition, out useDirection);
                if (!_contentEnd)
                    newPosition = GetNewPosition(_inputPosition, _checkPoint, out lineEnd);

                #region all condition need to do
                _inputPosition.position = newPosition;
                _inputPosition.lineEnd = lineEnd;
                #endregion

                #region use dampener
                if (!_inputPosition.useDampener)
                {
                    if (!_inputPosition.ignoreFirstTry)
                    {
                        _inputPosition.LineStartReset();                        
                        _inputPosition.useDampener = true;//simulate start at second number without dampner
                        return;
                    }

                    if (_inputPosition.checkFail)
                    {
                        _inputPosition.useDampener = true;
                        _inputPosition.checkFail = false;
                        _inputPosition.retryPosition = newPosition; //position - 1 retry start after using dampner(start at position + 1 )
                        _inputPosition.retryCheckNumber = _inputPosition.previousCheckNumber;
                        _inputPosition.retryDirection = _inputPosition.previousDirection;
                        _inputPosition.retryInputNumber = _inputNumber;
                        return;
                    }
                }

                #endregion
                #region check fail
                if (_inputPosition.checkFail)
                {
                    if (!_inputPosition.ignoreFirstTry)
                    {
                        _inputPosition.LineStartReset();
                        _inputPosition.ignoreFirstTry = true;
                        _inputPosition.position = _inputPosition.lineStartPosition;
                        return;
                    }

                    if (!_inputPosition.isRetry)
                    {
                        _inputPosition.isRetry = true;
                        // reset to retry data                    
                        _inputPosition.checkFail = false;
                        _inputPosition.position = _inputPosition.retryPosition;
                        _inputPosition.lineEnd = false; //這是必然，會隨position變化還原，沒還原會可能導致在非lineEnd的position認為是lineEnd
                        _inputPosition.checkNumber = _inputPosition.retryCheckNumber;
                        _inputPosition.direction = _inputPosition.retryDirection;
                        _inputNumber = _inputPosition.retryInputNumber;
                        //retry (no need to go through new position and use dampener procedure)
                        CheckReport(_inputNumber, _inputPosition, out useDirection);
                    }
                }
                #endregion
                //use dampener skip end record
                //record for position - 1 retry
                _inputPosition.previousCheckNumber = _inputPosition.checkNumber;
                _inputPosition.previousDirection = _inputPosition.direction;
                
                _inputPosition.checkNumber = _inputNumber;
                _inputPosition.direction = useDirection;
            }
            void CheckReport(int _inputNumber, PositionRecord _inputPosition, out char useDirection)
            {
                useDirection = _inputPosition.direction;
                if (_inputPosition.checkNumber != null)
                {
                    if (useDirection == ' ')
                    {
                        useDirection = DecideReportDrection(_inputPosition, _inputNumber);
                        if(useDirection == ' ')
                            _inputPosition.checkFail = true;
                    }
                    else
                    {
                        _inputPosition.checkFail = CheckSafe(useDirection, _inputPosition.checkNumber, _inputNumber);
                    }
                }
            }
            char DecideReportDrection(PositionRecord _inputPosition, int _inputNumber)
            {
                char result = ' ';
                if (_inputPosition.checkNumber > _inputNumber && _inputPosition.checkNumber - _inputNumber <= 3)
                    result = '-';
                else if (_inputPosition.checkNumber < _inputNumber && _inputNumber - _inputPosition.checkNumber <= 3)
                    result = '+';
                return result;
            }
            bool CheckSafe(char _direction, int? _checkNumber, int? _inputNumber)
            {
                bool result = false;
                switch (_direction)
                {
                    case '-':
                        if (!(_checkNumber > _inputNumber && _checkNumber - _inputNumber <= 3))
                            result = true;
                        break;
                    case '+':
                        if (!(_checkNumber < _inputNumber && _inputNumber - _checkNumber <= 3))
                            result = true;
                        break;
                    default:
                        result = true;
                        break;
                }
                return result;
            }
            int GetNewPosition(PositionRecord _inputPosition, int _checkPoint, out bool lineEnd)
            {
                int newPosition = _checkPoint + 1; //will jump across charsToJump
                lineEnd = false;
                if (_content[newPosition] == '\n' || _content[_checkPoint] == '\n') // deal \n
                {
                    lineEnd = true;
                    newPosition += _content[_checkPoint] == '\n' ? 0 : 1;
                }
                return newPosition;
            }
        }
        private class PositionRecord()
        {
            public int position = 0; //reading position            
            public bool lineEnd = false; //check read to line end
            public bool checkFail = false;
            public int? previousCheckNumber = null;
            public int? checkNumber = null;
            public char previousDirection = ' ';
            public char direction = ' '; // ' ','-','+'            
            public int retryPosition = 0; //position for retry use dampener at position - 1            
            public int? retryCheckNumber = null; //checkNumber for retry use dampener at position - 1
            public char retryDirection = ' ';//direction for retry
            public int retryInputNumber = 0;
            public int lineStartPosition = 0;
            //3 type condition 
            //1. use dampener at position ex: 86 82 87 , p = 0
            //2. use dampener at position - 1 ex: 86 85 87 , p = 0
            //3. use dampener at first ex: 86 85 86 , original method didn't consider use dampener at first when facing the success check at first, and give up th chance to check different direction when ignore first

            public bool useDampener = false;
            public bool isRetry = false;
            public bool ignoreFirstTry = false; 
            public void LineStartReset()
            {
                lineEnd = false;
                checkFail = false;
                previousCheckNumber = null;
                checkNumber = null;
                previousDirection = ' ';
                direction = ' ';
                useDampener = false;
                isRetry = false;
                retryPosition = 0;
                retryCheckNumber = null;
                retryDirection = ' ';
                retryInputNumber = 0;
            }
        }

        // ref : https://github.com/JoanaBLate/advent-of-code-js/blob/main/2024/day02-solve2.js
        public int GetSafeReportsWithDampener2(string input)
        {
            string _content = input.TrimEnd('\n');
            string[] lines = _content.Split('\n');
            int totalSafe = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lst = lines[i].Split(' ');
                List<int> intLst = new List<int>();
                for (int j = 0; j < lst.Length; j++) 
                {
                    intLst.Add(Convert.ToInt32(lst[j]));
                }

                if (isSomewhatSafe(intLst))
                {
                    Console.WriteLine($"{i+1} {intLst[intLst.Count - 1]} ");
                    totalSafe += 1;
                }                    
            }

            return totalSafe;

            bool isSomewhatSafe(List<int> input)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    List<int> newinput = new(input);
                    newinput.RemoveAt(i);
                    if (isSafe(newinput)) return true;
                }

                return false;
            }

            bool isSafe(List<int> input)
            {
                var expectedSign = Math.Sign(input[1] - input[0]);

                for (int i = 1; i < input.Count; i++)
                {
                    int a = input[i - 1];
                    int b = input[i];
                    int delta = b - a;
                    if (Math.Sign(delta) != expectedSign) return false;
                    if (Math.Abs(delta) < 1) return false;
                    if (Math.Abs(delta) > 3) return false;
                }
                return true;
            }
        }
    }
}
