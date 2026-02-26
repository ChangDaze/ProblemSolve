using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne
    {
        public int NumSteps(string s)
        {
            int step = 0;
            LinkedList<char> chars = new LinkedList<char>(s.ToCharArray());
            while (chars.Count > 1)
            {

                if (chars.Last() == '0')
                {
                    step++;
                }
                else
                {
                    LinkedListNode<char> current = chars.Last;

                    while (current != null)
                    {
                        if (current.Value == '0')
                        {
                            current.Value = '1';
                            break;
                        }
                        else
                        {
                            current.Value = '0';
                        }

                        current = current.Previous;
                    }

                    if (current == null)
                    {
                        chars.AddFirst('1');
                    }

                    step += 2;
                }
                chars.RemoveLast();                
            }
            return step;
        }
    }
}
