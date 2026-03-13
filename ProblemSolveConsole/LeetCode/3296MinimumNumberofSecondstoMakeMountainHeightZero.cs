using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _3296MinimumNumberofSecondstoMakeMountainHeightZero
    {
        public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
        {
            PriorityQueue<long[], long> pq = new PriorityQueue<long[], long>(); //[cost, futurecount, used], needsecond

            foreach (int worker in workerTimes)
            {
                pq.Enqueue([worker, 1, 0], worker);
            }

            while(mountainHeight > 0)
            {
                long[] workerInfo = pq.Dequeue();
                mountainHeight -= 1;
                workerInfo[2] += workerInfo[0] * workerInfo[1];
                workerInfo[1]++;
                pq.Enqueue(workerInfo, workerInfo[2] + workerInfo[0] * workerInfo[1]);
            }

            long result = 0;

            while(pq.Count > 0)
            {
                long[] workerInfo = pq.Dequeue();
                if (workerInfo[2] > result)
                {
                    result = workerInfo[2];
                }
            }

            return result;
        }
    }
}
