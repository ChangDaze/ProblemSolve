using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    internal class _1356SortIntegersbyTheNumberof1Bits
    {
#if false
            public int[] SortByBits(int[] arr)
            {
                int[][] record = new int[arr.Length][];
                for(int i = 0;i<record.Length ; i++)
                {
                    record[i] = new int[2] { CountBits(arr[i]), arr[i] };
                }

                return record.OrderBy(x => x[0]).ThenBy(x => x[1]).Select(x => x[1]).ToArray();
            }

            public int CountBits(int num)
            {
                int count = 0;
                while (num != 0)
                {
                    count += num % 2;//餘1代表這個位數有1
                    num = num / 2;
                }

                return count;
            }
#endif
        public int[] SortByBits(int[] arr)
        {
            return arr.OrderBy(x => System.Numerics.BitOperations.PopCount((uint)x)).ThenBy(x=>x).ToArray();
        }
    }
}
