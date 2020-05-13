using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DataBaseAndLogic.DBlogic;
using DataBaseAndLogic.Logic;

namespace LCS_csharp_
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Attempting to make connection with ' DESKTOP-K3B9EQ2\\SQLEXPRESS '");

            Console.Clear();
            while (true)
            {
                Console.Write("Program for solving LCS problem \n Please enter 2 string separated with ',' : ");

                var input = Console.ReadLine();
                string[] words = input.Split(',');

                if (words.Length == 2 && input.All(c => Char.IsLetterOrDigit(c) || c == ','))
                {
                    using (LocalContext lcsContext = new LocalContext())
                    {
                        Lcs lcs = new Lcs(words[0], words[1]);
                        lcsContext.LcsStrings.Add(new Lcs(words[0], words[1]));//saving results to DB

                        Console.WriteLine("\nLast answers\n" + new string('-', 25));

                        var answs = (from answers in lcsContext.LcsStrings select answers).ToList();
                        //writes last 5 or less elements from DB
                        lcsContext.LcsStrings.Skip(Math.Max(0, lcsContext.LcsStrings.Count() - 5)).ToList().ForEach(e =>
                        Console.WriteLine($"\nS1 : {e.FirstString}\nS2 : {e.SecondString}\nLCS: {e.AnswerString} \n"));


                        Console.WriteLine(new string('-', 25)+ "\nYour answer\n"+ new string('-', 25));
                        lcs.LcsOut();
                        Console.WriteLine("\n" + new string('-', 25));
                        Console.WriteLine("Press 'Enter' for saving changes or close Console for discard");
                        Console.ReadKey();

                        lcsContext.SaveChanges();
                    }
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
