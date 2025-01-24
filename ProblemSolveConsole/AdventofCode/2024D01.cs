using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    //https://adventofcode.com/2024/day/1
    public class _2024D01 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D01.txt"))
            {
                string data = sr.ReadToEnd();
                Console.WriteLine(GetTotalDistance(data));
                Console.WriteLine(GetSimilarityScore(data));
            }                            
        }        
        public double GetTotalDistance(string input)
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
            for(int j = 0; j < leftLst.Count; j++) //照理來講程式能執行到這leftLst、rightLst會一樣長
            {
                sum += Math.Abs(leftLst[j] - rightLst[j]);
            }

            return sum;
        }
        public long GetSimilarityScore(string input)
        {
            Regex regex = new Regex(@"-?\d+(\.\d+)?");
            MatchCollection matches = regex.Matches(input);

            int i = 0;
            List<int> leftLst = new List<int>();
            List<int> rightLst = new List<int>();
            while (i < matches.Count)
            {
                int.TryParse(matches[i].Value, out int number);
                if (i % 2 == 0)
                    leftLst.Add(number);
                else
                    rightLst.Add(number);
                i++;
            }
            //statistics the right list
            Dictionary<int, int> rightDic = new Dictionary<int, int>();
            for (int j = 0; j < rightLst.Count; j++)
            {
                if (rightDic.ContainsKey(rightLst[j]))
                    rightDic[rightLst[j]]++;
                else
                    rightDic[rightLst[j]] = 1;
            }
            //iterate the left list to calculate the sum score
            long sum = 0;
            for (int k = 0; k < leftLst.Count; k++)
            {
                if (rightDic.ContainsKey(leftLst[k]))
                {
                    sum += leftLst[k] * rightDic[leftLst[k]];
                }                    
            }

            return sum;
        }
    }
}
