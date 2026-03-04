using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1582SpecialPositionsinaBinaryMatrix
    {
#if false
            public int NumSpecial(int[][] mat)
            {
                int result = 0;
                int[] rRecord = new int[mat.Length];
                int[] cRecord = new int[mat[0].Length];
                for(int i = 0;i<mat.Length; i++)
                    for (int j = 0; j < mat[0].Length; j++)
                        if (mat[i][j] == 1)
                        {
                            rRecord[i]++;
                            cRecord[j]++;
                        }

                for (int i = 0; i < rRecord.Length; i++)
                    for (int j = 0; j < cRecord.Length; j++)
                        if (rRecord[i] == 1 && cRecord[j] == 1)
                        {
                            if (mat[i][j]==1)
                                result++;
                        }
                            

                return result;
            }
#endif
        public int NumSpecial(int[][] mat)
        {
            Dictionary<int, bool> iStatus = new Dictionary<int, bool>();
            Dictionary<int, bool> jStatus = new Dictionary<int, bool>();
            List<(int, int)> potentilas = new List<(int, int)> ();

            for (int i = 0; i < mat.Length; i++)
            {
                for(int j = 0; j < mat[i].Length; j++) //不能跳過整行或整列會影響狀態蒐集
                {
                    if(mat[i][j] == 0) { continue; }

                    bool skip = false;
                    if (iStatus.ContainsKey(i))
                    {
                        skip = true;
                    }

                    if (jStatus.ContainsKey(j))
                    {
                        skip = true;
                    }

                    if(!skip)
                    {
                        iStatus[i] = true;
                        jStatus[j] = true;
                        potentilas.Add((i, j));
                    }
                    else
                    {
                        iStatus[i] = false;
                        jStatus[j] = false;
                    }
                }
            }

            int result = 0;
            foreach((int, int) point in potentilas)
            {
                if (iStatus[point.Item1] && jStatus[point.Item2])
                {
                    result++;
                }
            }

            return result;
        }
    }
}
