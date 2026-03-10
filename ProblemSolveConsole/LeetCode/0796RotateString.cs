using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0796RotateString
    {
#if false //舊方法
    public bool RotateString(string A, string B) {
        
        if(A.Length != B.Length)
            return false;
        if(A == "" && B =="")
            return true;
       
        int k = 0;
        while(k < A.Length)
        {
            char[] temp = new char[A.Length];
            for(int i = 0; i < A.Length; i++)
                temp[i] = A[(i + A.Length - k) % A.Length]; // left shift
            
            string str = new string(temp);
            if(str == B)
                return true;
            
            k++;
        }
        
        return false;
    }
#endif
        public bool RotateString(string s, string goal)
        {
            if(s.Length != goal.Length) return false; //因為目標是rotate所以原始長度一定要相同

            string ss = s[1..] + s;//C# 新有的字串切片寫法
            return ss.Contains(goal);
        }
    }
}
