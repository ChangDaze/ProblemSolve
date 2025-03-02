using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0728SelfDividingNumbers
    {
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            List<int> result = new List<int>();
            //因為每個數字都不同(除數和被除數都會變化)所以就都要檢查
            for(int i = left; i <= right; i++)
            {
                if (IsSelfDividingNumber(i))
                {
                    result.Add(i);
                }
            }

            return result;

            bool IsSelfDividingNumber(int number)
            {
                string numberStr = number.ToString();

                //用str的轉換很多，下次可以測測跟%10哪個速度會比較快
                for(int i = 0; i< numberStr.Length; i++)
                {
                    if(numberStr.Substring(i, 1) == "0" || number % Convert.ToInt32(numberStr.Substring(i,1)) != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        //看起來用%10在這題真的比較好，簡潔又有力，速度應該也可能較快，但這個的檢查digit 0隱含在for和%中要看仔細點
        //https://leetcode.com/problems/self-dividing-numbers/solutions/109458/java-c-clean-code/
        //就是暴力解
        //https://leetcode.com/problems/self-dividing-numbers/solutions/127482/self-dividing-numbers/
    }
}
