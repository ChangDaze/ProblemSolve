using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _2960CountTestedDevicesAfterTestOperations
    {
        public int CountTestedDevices(int[] batteryPercentages)
        {
            int testedDevices = 0;
            int decreaseTotal = 0; 

            foreach (int batteryPercentage in batteryPercentages)
            {
                if(batteryPercentage - decreaseTotal > 0) 
                { 
                    testedDevices++;
                    decreaseTotal++;//作用範圍是i + 1, n - 1，所以下次要用前更新就好
                }
            }

            return testedDevices;
        }

        //這位把testedDevices和decreaseTotal組在一起用了，但感覺看懂會需要一點說明
        //https://leetcode.com/problems/count-tested-devices-after-test-operations/solutions/4384489/java-c-python-easy-and-concise/
    }
}
