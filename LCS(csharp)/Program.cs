using System;

namespace LCS_csharp_
{
    class Program
    {
        static void Lcs(string s1, string s2)
        {
            var m = s1.Length;
            var n = s2.Length;
            //define lcs table (numbers)
            int[,] lcsTable = new int[m + 1, n + 1];

            for (int itt = 0; itt <= m; itt++)
            {
                for (int jtt = 0; jtt <= n; jtt++)
                {
                    //first row, fist column- fill with 0
                    if (itt == 0 || jtt == 0)
                        lcsTable[itt, jtt] = 0;
                    //if character of current row and current column  are the same fill by +1 to diagonal
                    else if (s1[itt - 1] == s2[jtt - 1])
                        lcsTable[itt, jtt] = lcsTable[itt - 1, jtt - 1] + 1;
                    //else take the maximum value from the previous column and previous row
                    else
                        lcsTable[itt, jtt] = Math.Max(lcsTable[itt - 1, jtt], lcsTable[itt, jtt - 1]);
                }
            }

            int index = lcsTable[m, n];
            //define lcs table (characters)
            char[] lcs = new char[index + 1];
            lcs[index] = '\0';
            int i = m, j = n;
            //going backward and finding diagonal elements
            while (i > 0 && j > 0)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    lcs[index - 1] = s1[i - 1];
                    i--;
                    j--;
                    index--;
                }
                else if (lcsTable[i - 1, j] > lcsTable[i, j - 1])
                    i--;
                else
                    j--;
            }
            Console.WriteLine($"S1 : {s1}\nS2 : {s2}\nLCS: {new string(lcs)} ");
        }

        static void Main()
        {
            Lcs("ACADB", "CBDA");
        }
    }
}
