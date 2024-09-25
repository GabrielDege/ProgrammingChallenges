using System;
using System.Linq;

/*
    Go to the attempt class as there are spoilers to a solution here.
    This is the code to check if your anwser is correct.
*/

namespace Index_of_N_unique_characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            Attempt attempt = new Attempt();
            Random rnd = new Random();
            int totalTests = 100, correctTests = 0;
            for (int i = 0; i < totalTests; i++)
            {
                string stream = new string(Enumerable.Repeat(chars, rnd.Next(100000,500000)).Select(s => s[rnd.Next(s.Length)]).ToArray());
                int n = rnd.Next(14, 22);
                int uIndex = attempt.ReturnIndex(stream, n), cIndex = GetIndex(stream, n); 
                Console.WriteLine("Test {0} : N = {1} : index = {2} : user = {3}", i + 1, n, cIndex, uIndex);
                if (cIndex == -1) Console.WriteLine("{0}", "No index within stream");
                else if (uIndex + n > stream.Length) Console.WriteLine("Index too large");
                if (cIndex != -1)
                {
                    if (uIndex != -1) Console.WriteLine("Index found at {0}", uIndex);
                    //Console.Write("   Correct string = \x1b[1m"); ESCAPE CODES DON'T WORK ON SCOOL PC's
                    Console.Write("   Correct string = ");
                    for (int j = cIndex; j < cIndex + n; j++) Console.Write(stream[j]);
                    //Console.Write("\n\x1B[0mUser found string = \x1b[1m");
                    Console.Write("\nUser found string = ");
                    if (uIndex != -1) for (int j = uIndex; j < uIndex + n; j++) Console.Write(stream[j]);
                    else Console.Write("Not found");
                }
                //Console.WriteLine("\n{0}\n\n", cIndex == uIndex ? "\x1b[1m\x1b[32mTest Passed!" : "\x1b[1m\x1b[31mTest Failed");
                if (cIndex == uIndex) { Console.ForegroundColor = ConsoleColor.Green; correctTests++; }
                else Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n{0}\n\n", cIndex == uIndex ? "Test Passed!" : "Test Failed");
                //if (cIndex == uIndex) correctTests++;
                Console.ResetColor();
            }
            Console.Write((totalTests == correctTests ? "All "+ correctTests : correctTests == 0 ? "None of the " + totalTests : correctTests + " / " + totalTests) + " tests were correct");
            Console.ReadKey();
        }
        static int GetIndex(string stream, int n)
        {
            for (int i = 0; i < stream.Length-n; i++)
            {
                int filter = 0, c = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((1 << ((int)stream[i + j] % 32) & filter) != 0) continue;
                    filter ^= 1 << (int)stream[i + j] % 32; c++;
                }
                if (c == n) return i;
            }
            return -1;
        }
    }
}