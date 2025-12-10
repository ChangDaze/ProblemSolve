using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3577CounttheNumberofComputerUnlockingPermutations
    {
        public int CountPermutations(int[] complexity)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            //index 0 一定是最小的 否則 permutation[1]就排不了了 (complexity, index其中之一會違反)
            //後面只要比index 0小(不含等於) 都符合組合
            //排除重複組合

            //確認是否complexity[0]最小
            int indexZero = complexity[0];
            for(int i = 1; i<complexity.Length; i++)
            {
                if(complexity[i] <= indexZero)
                {
                    return 0;
                }
            }
            
            //pemutation排除重複計算數量 => 也不用耶，因為是用index每個都算獨立個體
            return Factorial(complexity.Length - 1, 1000000000+7);
        }

        public int Factorial(int n, long primeNum)
        {
            long result = 1;

            for(int i = 1; i<=n; i++)
            {
                if(result >  primeNum)
                {
                    result %= primeNum;
                }
                result *= i;
            }

            result %= primeNum; //避免最後剛好大於int
            return (int)result;
        }

        //這題應該算考題目理解，有點腦筋急轉彎，然後自己歸納好後去看hint就發現完全一樣...，一開始差點用DP下去，用下去反而可能解很久
        //https://leetcode.com/problems/count-the-number-of-computer-unlocking-permutations/solutions/7403537/most-optimal-explained-by-aashaypawar-tach/
        //大家解法其實一樣
    }
}
