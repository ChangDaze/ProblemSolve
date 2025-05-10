using Microsoft.Win32;
using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.AdventofCode._2024D16;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D17 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D17.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetProgramOutput(input));
                Console.WriteLine(GetSameOutputRegisterA(input));
            }
        }

        //operand
        //Combo operands 0 through 3 represent literal values 0 through 3.
        //Combo operand 4 represents the value of register A.
        //Combo operand 5 represents the value of register B.
        //Combo operand 6 represents the value of register C.
        //Combo operand 7 is reserved and will not appear in valid programs.

        //opcode 精簡版, input=x(combo operand), rx(literal operand)
        //adv(opcode 0) registerA / ((2^x)); registerA = floor(result)
        //bxl(opcode 1) registerB XOR rx; registerB = result
        //bst(opcode 2) x%8 ; registerB = result
        //jnz(opcode 3) registerA == 0 ? nothing : nothing and jump 【to】 rx
        //bxc(opcode 4) registerB XOR registerC ; registerB = result
        //out(opcode 5) x%8; output result
        //bdv(opcode 6) registerA / ((2^x)); registerB = floor(result)
        //cdv(opcode 7) registerA / ((2^x)); registerC = floor(result)

        #region
        //0,1,5,4,3,0
        //(0,1) A: 729 B: 0 C: 0
        //729 / 2 = 364 = A
        //(5,4) A: 364 B: 0 C: 0
        //364 % 8 = 4 = out
        //(3,0) A: 364 B: 0 C: 0
        //jump to 0
        //(0,1) A: 364 B: 0 C: 0
        //364 / 2 = 182 = A
        //(5,4) A: 182 B: 0 C: 0
        //182 % 8 = 6 = out
        //(3,0) A: 182 B: 0 C: 0
        //jump to 0
        //(0,1) A: 182 B: 0 C: 0
        //182 / 2 = 91 = A
        //(5,4) A: 91 B: 0 C: 0
        //91 % 8 = 3 = out
        //(3,0) A: 91 B: 0 C: 0
        //jump to 0
        //...
        # endregion

        public string GetProgramOutput(string input)
        {
            Tuple<int, int, int, string> data = GetData(input);
            Computer computer = new Computer();
            computer.SetProgram(data.Item1, data.Item2, data.Item3, data.Item4);
            string result = computer.Run();
            return result;
        }
        private Tuple<int, int, int, string> GetData(string input)
        {
            Tuple<int, int, int, string> result = null;
            using (StringReader sr = new StringReader(input))
            {                
                string line = sr.ReadLine();
                int count = 0;
                int[] registers = new int[3];
                while (line != null)
                {
                    switch (count)
                    {
                        case 0:
                            if(line.IndexOf("Register A: ") != -1)
                            {
                                registers[0] = Convert.ToInt32(line.Substring(12));
                                count++;
                            }
                            break;
                        case 1:
                            if (line.IndexOf("Register B: ") != -1)
                            {
                                registers[1] = Convert.ToInt32(line.Substring(12));
                                count++;
                            }
                            break;
                        case 2:
                            if (line.IndexOf("Register C: ") != -1)
                            {
                                registers[2] = Convert.ToInt32(line.Substring(12));
                                count++;
                            }
                            break;
                        default:
                            if (line.IndexOf("Program: ") != -1)
                            {
                                result = Tuple.Create(registers[0], registers[1], registers[2], line.Substring(9));
                            }
                            break;
                    }
                    line = sr.ReadLine();
                }
            }
            return result;
        }
        public class Computer
        {
            //2,4,
            //1,2,
            //7,5,
            //4,5,
            //0,3,
            //1,7,
            //5,5,
            //3,0
            private int _registerA;
            private int _registerB;
            private int _registerC;
            private int[] _program;
            private int _pointer;
            private StringBuilder _output;
            private bool runnable;

            public void SetProgram(int registerA, int registerB, int registerC, string program)
            {
                _registerA = registerA;
                _registerB = registerB;
                _registerC = registerC;
                _program = program.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                _pointer = 0;
                _output = new StringBuilder();
                runnable = true;
            }
            public string Run()
            {
                if (!runnable)
                {
                    throw new Exception("not runnable");
                }

                for(_pointer =  0; _pointer < _program.Length; _pointer = _pointer + 2)
                {
                    OperateByCode(_program[_pointer], _program[_pointer + 1], GetOperandValue(_program[_pointer + 1]));
                }
                if(_output.Length > 0)
                {
                    _output.Remove(_output.Length -1 , 1); //去除最後的逗點
                }
                runnable = false;
                return _output.ToString();
            }
            private int GetOperandValue(int operand)
            {
                switch (operand)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        return operand;
                    case 4:
                        return _registerA;
                    case 5:
                        return _registerB;
                    case 6:
                        return _registerC;
                    case 7:
                        //throw new Exception("reserved and will not appear in valid programs");
                        return operand;
                    default:
                        throw new Exception("exception operand");
                }
            }
            private void OperateByCode(int opcode, int operand, int operandValue)
            {
                switch (opcode)
                {
                    case 0:
                        _registerA = (int)Math.Truncate(_registerA / (decimal)Math.Pow(2, operandValue));
                        return;
                    case 1:
                        _registerB = _registerB ^ operand;
                        return;
                    case 2:
                        _registerB = operandValue % 8;
                        return;
                    case 3:
                        if( _registerA != 0)
                        {
                            _pointer = operand - 2;//因為出去的迴圈pointer會+2，所以這裡再出去前先-2                            
                        }
                        return;
                    case 4:
                        _registerB = _registerB ^ _registerC;
                        return;
                    case 5:
                        _output.Append((operandValue % 8).ToString());
                        _output.Append(',');
                        return;
                    case 6:
                        _registerB = (int)Math.Truncate(_registerA / (decimal)Math.Pow(2, operandValue));
                        return;
                    case 7:
                        _registerC = (int)Math.Truncate(_registerA / (decimal)Math.Pow(2, operandValue));
                        return;
                    default:
                        throw new Exception("exception opcode");
                }
            }
        }
        public long GetSameOutputRegisterA(string input)
        {
            Tuple<int, int, int, string> data = GetData(input);
            Computer2 computer = new Computer2();
            computer.SetProgram(data.Item4);
            long result = computer.Run();
            return result;
        }
        public class Computer2()
        {
            //3個假設
            //(1)最後只有和必定是3,0來讓loop達成
            //(2)必定有類似5,5來輸出結果
            //(3)在解的時候0,3是唯一編輯A的部分，搭配2,4 | 7,5一定會讓B | C 變A的下游，最終5,5一定是A計算出的結果
            //(4)0,3是A/8無條件捨去的過程，或者說A右移 3 位的過程 (右移操作會自動丟掉右邊的位元，相當於無條件捨去（floor）)
            // 非負整數 x // 8   ≡   x >> 3

            //因為A最終=0，所以逆推就是每次找被右移掉的3bit的值，這3bit會是0~7 (8的餘數)
            //逆推就是 A << 3 (先左移讓出3bit) | t (因為是000，用OR補上0~7某一數字)，然後試試此輪B是否符合

            //2,4, b from a
            //1,2, b from b
            //7,5, c from a
            //4,5, b from c
            //0,3, * a 此輪不再影響b、c， a << 3
            //1,7, b from b
            //5,5, output b
            //3,0  loop

            //目的是計算出原本的A                        
            private int[] _program;
            private long _answer;
            public void SetProgram(string program)
            {
                _program = program.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            }
            public long Run()
            {
                _answer = -1;
                RecursiveProgram(_program.Length - 1, 0);
                return _answer;
            }           
            private bool RecursiveProgram(int recursivePointer, long currentRegisterA)
            {
                if(recursivePointer < 0)
                {
                    _answer = currentRegisterA;
                    return true;
                }

                for(int i = 0; i < 8; i++)
                {
                    long registerA = 0;
                    long registerB = 0;
                    long registerC = 0;
                    long output = -1; //初始化output避免誤導
                    long tempCurrentRegisterA = currentRegisterA << 3 | i; //設定每輪起始registerA
                    registerA = tempCurrentRegisterA;

                    for (int pointer = 0; pointer < _program.Length; pointer = pointer + 2)
                    {
                        OperateByCode(
                            ref output,
                            ref registerA,
                            ref registerB,
                            ref registerC,
                            _program[pointer],
                            _program[pointer + 1],
                            GetOperandValue(
                                registerA,
                                registerB,
                                registerC,
                                _program[pointer + 1]));
                    }

                    if (output == _program[recursivePointer])
                    {
                        if(RecursiveProgram(recursivePointer - 1, tempCurrentRegisterA))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            private long GetOperandValue(long registerA, long registerB, long registerC, int operand)
            {
                switch (operand)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        return operand;
                    case 4:
                        return registerA;
                    case 5:
                        return registerB;
                    case 6:
                        return registerC;
                    case 7:
                        //throw new Exception("reserved and will not appear in valid programs");
                        return operand;
                    default:
                        throw new Exception("exception operand");
                }
            }
            /// <param name="opcode">動作</param>
            /// <param name="operand">代表值</param>
            /// <param name="operandValue">實際值</param>
            private void OperateByCode(ref long output,ref long registerA, ref long registerB, ref long registerC, int opcode, int operand, long operandValue)
            {
                switch (opcode)
                {
                    case 0:
                        registerA = (long)Math.Truncate(registerA / (decimal)Math.Pow(2, operandValue));
                        break;
                    case 1:
                        registerB = registerB ^ operand;
                        break;
                    case 2:
                        registerB = operandValue % 8;
                        break;
                    case 3: //目前無用 因為預設為 3,0了
                        break;
                    case 4:
                        registerB = registerB ^ registerC;
                        break;
                    case 5: //要核對的結論
                        output = operandValue % 8;
                        break;
                    case 6:
                        registerB = (long)Math.Truncate(registerA / (decimal)Math.Pow(2, operandValue));
                        break;
                    case 7:
                        registerC = (long)Math.Truncate(registerA / (decimal)Math.Pow(2, operandValue));
                        break;
                    default:
                        throw new Exception("exception opcode");
                }
            }
        }
    }
}
