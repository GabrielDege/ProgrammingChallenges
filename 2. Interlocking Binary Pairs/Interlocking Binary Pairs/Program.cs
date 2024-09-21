using System;

/*
    Go to the attempt class as there are spoilers to a solution here.
    This is the code to check if your anwser is correct.
*/

namespace Interlocking_Binary_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Attempt attempt = new Attempt();
            Random rnd = new Random();
            int totalTests = 50000, correctTests = 0;
            for (int i = 0; i < totalTests; i++)
            {
                int a = rnd.Next()>>20, b = rnd.Next() >> 20;
                if (attempt.Interlockable(a, b) == ((a & b) == 0)) correctTests++;
            }
            if (correctTests == totalTests) Console.WriteLine("All tests passed!");
            else if (correctTests == 0) Console.WriteLine("No tests passed.");
            else Console.WriteLine("{0}/{1} tests passed.", correctTests, totalTests);
            Console.ReadKey();
        }
    }
}
