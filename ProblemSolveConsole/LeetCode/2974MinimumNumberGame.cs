using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2974MinimumNumberGame
    {
        public int[] NumberGame(int[] nums)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            foreach(int num in nums)
            {
                pq.Enqueue(num, num);
            }

            List<int> result = new List<int>();

            while(pq.Count > 0)
            {
                int alice = pq.Dequeue();
                int bob = pq.Dequeue();

                result.Add(bob);
                result.Add(alice);
            }

            return result.ToArray();
        }
    }
}
