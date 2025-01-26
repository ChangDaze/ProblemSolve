using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D05 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D05.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetOrderSum(input));
                Console.WriteLine(GetUnorderSum(input));
            }
        }
        public int GetOrderSum(string input)
        {
            int mode = 1; // 1:rules ; 2:numbers
            List<int[]> rules = new List<int[]>();
            int sum = 0;
            using(StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                while(line != null)
                {                    
                    if(mode == 1)
                    {
                        if (line == "")
                        {
                            mode++;
                            line = sr.ReadLine();
                            continue;
                        }

                        int[] rule = line.Split('|').Select(x=>Convert.ToInt32(x)).ToArray();
                        rules.Add(rule);
                    }
                    else if(mode == 2)
                    {
                        int[] numbers = line.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                        Dictionary<int,int> numberIndexs = numbers
                            .Select((number, index) => new { key = number, value = index })
                            .ToDictionary(pair => pair.key, pair => pair.value);

                        bool check = true;

                        foreach (int[] rule in rules)
                        {
                            if (numberIndexs.ContainsKey(rule[0]) && numberIndexs.ContainsKey(rule[1]) && numberIndexs[rule[0]] > numberIndexs[rule[1]])
                            {
                                check = false;
                                break;
                            }                                
                        }

                        if (check)
                            sum += numbers[numbers.Length / 2];
                    }

                    line = sr.ReadLine();
                }
            }
            return sum;
        }
        public int GetUnorderSum(string input)
        {
            int mode = 1; // 1:rules ; 2:numbers
            List<int[]> rules = new List<int[]>();
            int sum = 0;
            using (StringReader sr = new StringReader(input))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (mode == 1)
                    {
                        if (line == "")
                        {
                            mode++;
                            line = sr.ReadLine();
                            continue;
                        }

                        int[] rule = line.Split('|').Select(x => Convert.ToInt32(x)).ToArray();
                        rules.Add(rule);
                    }
                    else if (mode == 2)
                    {
                        int[] numbers = line.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                        Dictionary<int, int> numberIndexs = numbers
                            .Select((number, index) => new { key = number, value = index })
                            .ToDictionary(pair => pair.key, pair => pair.value);



                        HashSet<Tuple<int,int>> checkRules = new HashSet<Tuple<int,int>>();
                        int check = 0;

                        foreach (int[] rule in rules)
                        {
                            //gpt提供的簡單用法，可能可以參考一下 if (correctOrder.IndexOf(from) > correctOrder.IndexOf(to))
                            if (numberIndexs.ContainsKey(rule[0]) && numberIndexs.ContainsKey(rule[1]) && numberIndexs[rule[0]] > numberIndexs[rule[1]])
                            {
                                checkRules.Add(new Tuple<int, int>(rule[1], rule[0]));//紀錄目前的排序
                                check++;                                  
                            }
                        }

                        if (check > 0)
                        {
                            //bubble sort + 遞移律(規則一定環環相扣，所以當作比大小即可) + tuple key match 就交換
                            int temp;
                            for (int i = numbers.Length - 1; i > 0; i--)
                            {
                                for(int j = 0; j<= i-1; j++)
                                {
                                    //沒比對到的數字可以放原位無視(ex:正確排序、or no rule)
                                    if(checkRules.Contains(new Tuple<int, int>(numbers[j], numbers[j + 1])))
                                    {
                                        temp = numbers[j];                                        
                                        numbers[j] = numbers[j + 1];
                                        numbers[j+1] = temp;
                                    }
                                }
                            }
                            sum += numbers[numbers.Length / 2];
                        }                            
                    }

                    line = sr.ReadLine();
                }
            }
            return sum;
        }
        //gpt用拓樸排序，有向無環圖（DAG）+入度
    }
}
