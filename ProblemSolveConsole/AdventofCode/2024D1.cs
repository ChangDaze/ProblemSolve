using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    //https://adventofcode.com/2024/day/1
    public class _2024D1 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("AdventofCode/Input/2024Q1_1.txt"))
            {
                string data = sr.ReadToEnd();
                Console.WriteLine(GetTotalDistance1(data));
            }                            
        }        
        public double GetTotalDistance1(string input)
        {
            Regex regex = new Regex(@"-?\d+(\.\d+)?");
            MatchCollection matches = regex.Matches(input);

            int i = 0;
            List<double> leftLst = new List<double>();
            List<double> rightLst = new List<double>();
            while (i < matches.Count)
            {
                double.TryParse(matches[i].Value, out double number);
                if (i % 2 == 0)
                    leftLst.Add(number);
                else
                    rightLst.Add(number);
                i++;
            }

            leftLst.Sort();
            rightLst.Sort();

            double sum = 0;
            for(int j = 0; j < leftLst.Count && j < rightLst.Count ; j++)
            {
                sum += Math.Abs(leftLst[j] - rightLst[j]);
            }

            return sum;
        }
    }
}
