using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0150EvaluateReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            //Time complexity:O(n)
            //Space complexity:O(n)
            Stack<int> stack = new Stack<int>();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int value))
                {
                    stack.Push(value);
                }
                else
                {
                    int right = stack.Pop();
                    int left = stack.Pop();//先出現的數要放左邊
                    //計算完結果要push回去
                    switch (token)
                    {                        
                        case "+":
                            stack.Push(left + right);
                            break;
                        case "-":
                            stack.Push(left - right);
                            break;
                        case "*":
                            stack.Push(left * right);
                            break;
                        case "/":
                            stack.Push(left / right);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
            }

            return stack.Pop();
        }
        //逆波蘭符號 : 遇到符號時用前兩個數字計算
        //用一般Stack方式即可處理
        //https://leetcode.com/problems/evaluate-reverse-polish-notation/solutions/47514/fancy-c-lambda-expression-solution-by-he-2ker/
        //這蠻特別的，用map+委派，不知道C#能否這樣用
        //https://leetcode.com/problems/evaluate-reverse-polish-notation/solutions/47430/java-accepted-code-stack-implementation-h2vxv/
        //這就if else硬寫，看來不會有太特別解法
    }
}
