using System;
using System.Linq;

namespace LCS_csharp_
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Attempting to make connection with ' DESKTOP-K3B9EQ2\\SQLEXPRESS '");

            LocalContext lcsContext = new LocalContext();

            Console.Clear();
            while (true)
            {
                Console.Write("Program for solving LCS problem \n Please enter 2 string separated with ',' : ");

                var input = Console.ReadLine();
                string[] words = input.Split(',');

                if (words.Length == 2 && input.All(c => Char.IsLetterOrDigit(c) || c == ','))
                {
                    Lcs lcs = new Lcs(words[0], words[1]);
                    lcsContext.LcsStrings.Add(new Lcs(words[0], words[1]));//saving results to DB

                    Console.WriteLine("\nLast answers\n" + new string('-', 25));

                    var answs = (from answers in lcsContext.LcsStrings select answers).ToList();

                    //writes last 5 or less elements from DB
                    for (int i = answs.Count - 1; i > answs.Count-6 && i > 0; i--)
                        Console.WriteLine($"\nS1 : {answs[i].FirstString}\nS2 : {answs[i].SecondString}\nLCS: {answs[i].AnswerString} \n");
                    

                    Console.WriteLine(new string('-', 25)+ "\nYour answer\n"+ new string('-', 25));
                    lcs.LcsOut();
                    Console.WriteLine("\n" + new string('-', 25));
                    Console.WriteLine("Press 'Enter' for saving changes or close Console for discard");
                    Console.ReadKey();
                    lcsContext.SaveChanges();
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
