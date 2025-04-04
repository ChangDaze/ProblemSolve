using Microsoft.Win32;
using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
                            _pointer = operand - 2;                            
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

    }
}
