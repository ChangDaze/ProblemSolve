using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D19 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D19.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(CountDesigns(input));
            }
        }
        public int CountDesigns(string input)
        {
            var data = GetDatas(input);
            int result = 0;
            #region 拼字問題 DP 無限次使用
            foreach(string design in data.designs)
            {
                if(CheckDesign(design, data.patterns))
                {
                    result++;
                }
            }
            #endregion

            return result;
        }
        public bool CheckDesign(string design, List<string> patterns)
        {
            bool[] dp = new bool[patterns.Count + 1]; //第一格給長度為0用的檢查
            dp[0] = true;

            for (int i = 1; i < design.Length; i++) //逐字檢查
            {
                foreach (string pattern in patterns)
                {
                    if( 
                        //比對要照順序，有意義
                        i >= pattern.Length //此pattern長度可在此處比對
                        && dp[i - pattern.Length] == true //確認前面狀態已是可行(動態規劃概念後面的可以base on 前面可達成的點，前面不可行也代表後面不行) || i == 0
                        && design.Substring(i - pattern.Length + 1, pattern.Length) == pattern //確認dp[i]是否可行
                        )
                    {
                        dp[i] = true;
                        break; //確認可以dp[i]就可以不用比了
                    }
                }
            }

            return dp[design.Length - 1];
        }
        public (List<string> patterns, List<string> designs) GetDatas(string input)
        {
            List<string> patterns = new List<string>();
            List<string> designs = new List<string>();
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                bool isDesigns = false;
                while (line != null)
                {
                    if (!isDesigns)
                    {
                        if(line == "")
                        {
                            isDesigns = true;
                        }
                        else
                        {
                            patterns = line.Split(',').Select( x => x.TrimStart()).ToList();
                        }
                    }
                    else
                    {
                        designs.Add(line);
                    }

                    line = sr.ReadLine();
                }
            }
            return (patterns, designs);
        }
    }
}
