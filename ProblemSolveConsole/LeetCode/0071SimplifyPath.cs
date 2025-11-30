using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0071SimplifyPath
    {
        public string SimplifyPath(string path)
        {
            // time：O(n)
            // space：O(n)

            string[] paths = path.Split('/');
            List<string> stack = new List<string>();

            foreach (string p in paths)
            {
                if (p == "" || p == ".")// // || .
                {
                    continue;
                }
                else if( p == "..")// ..
                {
                    if(stack.Count > 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                }
                else
                {
                    stack.Add(p);
                }
            }

            return "/" + String.Join("/", stack);
        }

        //https://leetcode.com/problems/simplify-path/solutions/1847357/c-easy-stack-simple-explained-algorithm-qhwp2/
        //這位就是逐字處理，沒有像我靠工具簡化，方法一樣
        //https://leetcode.com/problems/simplify-path/solutions/1847526/best-explanation-ever-possible-not-a-cli-jz2y/
        //這位方法也一樣
        //不過他們都用stack，我因為不想倒過來就簡單用list而已

    }
}
