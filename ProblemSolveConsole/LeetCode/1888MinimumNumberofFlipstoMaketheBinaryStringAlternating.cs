using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1888MinimumNumberofFlipstoMaketheBinaryStringAlternating
    {
        public int MinFlips(string s)
        {
            int len = s.Length;
            int zeroFirst = 0;//match
            int oneFirst = 0;

            for (int i = 0; i < len; i++)
            {
                if(i%2 == 0)
                {
                    if (s[i] == '0')
                    {
                        zeroFirst++;
                    }
                    else
                    {
                        oneFirst++;
                    }
                }
                else
                {
                    if (s[i] == '0')
                    {
                        oneFirst++;                        
                    }
                    else
                    {
                        zeroFirst++;
                    }
                }
            }

            int max = Math.Max(zeroFirst, oneFirst);
            bool lastEven = (len - 1)%2 == 0;

            for (int i = 0; i < len; i++)//指到的位置從0變到Last
            {
                zeroFirst = len - zeroFirst;
                oneFirst = len - oneFirst;

                if (s[i] == '1')// index 0 > index -1, even to odd
                {
                    zeroFirst--; //zeroFirst odd時是'1'match               
                }
                else
                {
                    oneFirst--; //oneFirst odd時是'0'match
                }

                if (lastEven)
                {
                    if (s[i] == '0')
                    {
                        zeroFirst++;
                    }
                    else
                    {
                        oneFirst++;
                    }
                }
                else
                {
                    if (s[i] == '0')
                    {
                        oneFirst++;
                    }
                    else
                    {
                        zeroFirst++;
                    }
                }

                max = Math.Max(Math.Max(max,zeroFirst), oneFirst);
            }

            return len - max;
        }
    }
}
