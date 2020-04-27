using System;
using System.Linq;

namespace LCS_csharp_
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Program for solving LCS problem \n Please enter 2 string separated with ',' : ");
                var input = Console.ReadLine();
                string[] words = input.Split(',');
                if (words.Length == 2 && input.All(c => Char.IsLetterOrDigit(c) || c == ','))
                {
                    Lcs lcs = new Lcs(words[0], words[1]);

                    Console.WriteLine("\nYour answer\n" + new string('-' , 25));
                    lcs.LcsOut();
                    Console.WriteLine("\n" + new string('-', 25));

                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Wrong input, please try again \n");
                }
            }
        }
    }
}
