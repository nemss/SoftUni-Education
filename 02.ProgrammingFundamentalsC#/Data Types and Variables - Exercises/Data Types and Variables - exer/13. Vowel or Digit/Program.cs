using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char word = char.Parse(Console.ReadLine());

            if (word == 'a' || word == 'e' || word == 'i' || word == 'o' || word == 'u')
            {
                Console.WriteLine("vowel");
            }

            else if (word >= '0' && word <= '9')
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
