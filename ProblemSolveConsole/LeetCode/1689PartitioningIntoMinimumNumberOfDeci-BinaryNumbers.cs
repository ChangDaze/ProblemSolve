using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1689PartitioningIntoMinimumNumberOfDeci_BinaryNumbers
    {
#if false //舊方法，方法跟新方法一樣，不過沒剪枝
        public int MinPartitions(string n)
        {
            char max = ' ';
            foreach (char c in n)
            {
                if (c > max)
                    max = c;
            }
            return max - '0';
        }
#endif
        public int MinPartitions(string n)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)
            char cur = '0';

            for(int i = 0; i < n.Length; i++)
            {
                if(cur < n[i])
                {
                    cur = n[i];
                    if(cur == '9')//一個位數最高num是9，可以不用檢查後面了
                    {
                        break;//其實可以直接return 9;不過差異不大
                    }
                }
            }

            return cur - '0';
        }

        //https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/solutions/970318/javacpython-just-return-max-digit-by-lee-kj5l/
        //這方法跟我一樣

        //大家方法好像其實都一樣，其實證明就是，每次最多每個位數填1，如果以滿足填0就好，所以最高的digit就是次數限制，因為要1填最高的digit次
        //不太確定這題為啥是medium，討論區好像也沒多人疑惑XD
    }
}
