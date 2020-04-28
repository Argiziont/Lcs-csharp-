using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCS_csharp_
{
    class Lcs
    {
        //DB id
        public int Id { get; set; }

        public string FirstString { get; set; }
        public string SecondString { get; set; }
        public string AnswerString { get { return LcsFinder(); } set { } }

        [NotMapped]//unnecessary props that will not be shown on the table
        private int[,] lcsTable;
        [NotMapped]
        private char[] lcsAnswer;

        public Lcs() { }

        public Lcs(string s1, string s2)
        {
            FirstString = s1;
            SecondString = s2;
        }

        private void TableSet()
        {
            //define lcs table (numbers)
            lcsTable = new int[FirstString.Length + 1, SecondString.Length + 1]; ;

            for (int itt = 0; itt <= FirstString.Length; itt++)
            {
                for (int jtt = 0; jtt <= SecondString.Length; jtt++)
                {
                    //first row, fist column- fill with 0
                    if (itt == 0 || jtt == 0)
                        lcsTable[itt, jtt] = 0;

                    //if character of current row and current column  are the same fill by +1 to diagonal
                    else if (FirstString[itt - 1] == SecondString[jtt - 1])
                        lcsTable[itt, jtt] = lcsTable[itt - 1, jtt - 1] + 1;

                    //else take the maximum value from the previous column and previous row
                    else
                        lcsTable[itt, jtt] = Math.Max(lcsTable[itt - 1, jtt], lcsTable[itt, jtt - 1]);
                }
            }
        }
        private string LcsFinder()
        {
            TableSet();

            int index = lcsTable[FirstString.Length, SecondString.Length];

            //define lcs table (characters)
            lcsAnswer = new char[index + 1];
            lcsAnswer[index] = '\0';
            int i = FirstString.Length, j = SecondString.Length;

            //going backward and finding diagonal elements
            while (i > 0 && j > 0)
            {
                if (FirstString[i - 1] == SecondString[j - 1])
                {
                    lcsAnswer[index - 1] = FirstString[i - 1];
                    i--;
                    j--;
                    index--;
                }
                else if (lcsTable[i - 1, j] > lcsTable[i, j - 1])
                    i--;
                else
                    j--;
            }
            return new string(lcsAnswer);
        }

        public void LcsOut()
        {
            Console.WriteLine($"\nS1 : {FirstString}\nS2 : {SecondString}\nLCS: {AnswerString} ");
        }

    }
}
