using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0054SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            //就暴力解 simulation@@
            //time: O(n)
            //space: O(n)

            int steps = matrix.Length * matrix[0].Length;
            List<int> result = new List<int>();
            bool[][] flags = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                flags[i] = new bool[matrix[i].Length];
            }

            int currentX = 0;
            int currentY = 0;
            (int x, int y) direction = (0, 1);

            while (steps != 0)
            {
                //進來的都是合法的
                result.Add(matrix[currentX][currentY]);
                steps--;
                flags[currentX][currentY] = true;

                int newX = currentX + direction.x;
                int newY = currentY + direction.y;

                //走下一步前的確認
                if (newX < 0 || newX >= matrix.Length || newY < 0 || newY >= matrix[0].Length || flags[newX][newY])
                {
                    direction = Turn(direction);
                    newX = currentX + direction.x;
                    newY = currentY + direction.y;
                }

                currentX = newX;
                currentY = newY;
            }

            return result;
        }

        private (int x, int y) Turn((int x, int y) direction)
        {
            if(direction.x == 0 &&  direction.y == 1) //向右
            {
                return (1, 0);
            }
            else if (direction.x == 1 && direction.y == 0)//向下
            {
                return (0, -1);
            }
            else if (direction.x == 0 && direction.y == -1)//向左
            {
                return (-1, 0);
            }
            else if (direction.x == -1 && direction.y == 0)//向上
            {
                return (0, 1);
            }

            throw new Exception("Error");
        }

        //https://leetcode.com/problems/spiral-matrix/solutions/20599/super-simple-and-easy-to-understand-solu-uaw0/
        //這個人是一次繞一圈，就沒有像我用flags輔助，也能自然結束，好像還不錯
        //大部分人好像其實都是這種做法，可以記起來
    }
}
