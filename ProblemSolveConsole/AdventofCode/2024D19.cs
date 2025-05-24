using ProblemSolveConsole.Interface;
using System;
using System.Collections;
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
                Console.WriteLine(CountWays(input));
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
        public long CountWays(string input)
        {
            var data = GetDatas(input);
            long count = 0;

            HashSet<string> patterns = data.patterns.ToHashSet();

            foreach (var design in data.designs)
            {

                #region recursive 所有組合
                //會stack overflow
                //Dictionary<int, List<List<string>>> records = new();
                //var ways = DFS(0, design, records);
                //count += ways.Count;
                #endregion

                #region iterative 所有組合
                //結果有組合還是算不完，只能單純算數量
                //這方法是把recursive轉換成iterative，如果要保留memory的應用就要轉成button up，最終 records[0]裡面會包含所有組合
                //Dictionary<int, List<List<string>>> records = new() { { design.Length, new List<List<string>>() {new List<string>() } } };

                //for(int start = design.Length - 1; start >= 0; start--)
                //{
                //    List<List<string>> result = new();
                //    for (int end = start + 1; end <= design.Length; end++)
                //    {
                //        string prefix = design.Substring(start, end - start);
                //        if (patterns.Contains(prefix))
                //        {
                //            foreach (var subList in records[end])
                //            {
                //                result.Add(
                //                    (new List<string>() { prefix }).Concat(subList).ToList()
                //                ); 
                //            }
                //        }
                //    }
                //    records[start] = result;
                //}

                //count += records[0].Count;
                #endregion

                //下面這有個小bug，就是如果完全沒有組合match時沒處理應該會直接跳key not found exception
                //結果組合太多只能用long，想當然入果紀錄完整組合會做不完...
                Dictionary<int, long> records = new() { { design.Length, 1 } };                
                for (int start = design.Length - 1; start >= 0; start--)
                {
                    long result = 0;
                    for (int end = start + 1; end <= design.Length; end++) //for loop 完想果會像 prefix collection * records[end] 數量
                    {
                        string prefix = design.Substring(start, end - start);
                        if (patterns.Contains(prefix))
                        {
                            result += records[end];
                        }
                    }
                    records[start] = result;
                }

                count += records[0];
            }

            return count;

            #region recursive 所有組合
            //會stackoverflow
            //資料結構是List<List<string>>每一個elemet list都能組成design，每個elemet list都包含著pattern和一個例外【空結尾】
            List<List<string>> DFS(int start, string target, Dictionary<int, List<List<string>>> records)
            {
                if (records.ContainsKey(start)) //DP，有過的紀錄就重複使用
                {
                    return records[start];
                }

                if(start == target.Length)//已到字串末尾沒字了，給個空結尾，也代表遞迴的終止點
                {
                    return new List<List<string>>() { new List<string>()}; 
                }

                List<List<string>> result = new(); //組合的結果

                for (int end = start + 1; end <= target.Length; end++) //注意是 [start + 1 ~ target.Length]
                {
                    string prefix = target.Substring(start, end - start);//所有可能 = [target.Substring(start,1) ~ target.Substring(start)]

                    //當end = target.Length => prefix = target.Substring(start) => 如果有中 pattern => 觸發 DFS(target.Length, target, records) => start == target.Length 觸發遞迴的終止點

                    if (patterns.Contains(prefix)) //有prefix
                    {
                        //組合所有 prefix + subffix = 所有可能
                        foreach (var subList in DFS(end, target, records)) //subffix委派給遞迴去找 end = start + 1 => 代表委派出去的 suffix = 其他字的 prefix
                        {
                            result.Add(
                                (new List<string>() { prefix }).Concat(subList).ToList()
                            ); ;
                        }
                    }
                }

                //好像不用這樣寫，records[start]應該只會寫入一次? 後面有同樣的就都直接取dictionary了
                //if (!records.TryGetValue(start, out var value))//DP紀錄結果
                //{
                //    records[start] = result; 
                //}
                records[start] = result;

                return result; //丟回所有組合結果
            }
            #endregion
        }
    }
}
