using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS_csharp_
{
    class RandomStringGenerator
    {
        public string CharSet { get; }// charset for random string
        Random random;
        public RandomStringGenerator(string chars)
        {
            CharSet = chars;
            random = new Random();
        }
        public string getRandString()
        {
            var stringChars = new char[15];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = CharSet[random.Next(CharSet.Length)];
            }

            return new string(stringChars);
        }
    }
}
