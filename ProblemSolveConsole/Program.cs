using ProblemSolveConsole.AdventofCode;
using ProblemSolveConsole.LeetCode;

namespace ProblemSolveConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 11;
            int b = 22;

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }


            new _2024D18().Execute();
            Console.WriteLine("Hello, World!");
        }
    }
}
