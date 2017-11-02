using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Randomize_Words
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] word = Console.ReadLine().Split();

            Random rnd = new Random();
             
            for (int i = 0; i < word.Length; i++)
            {
                int randomIndex = rnd.Next(word.Length);
                string oldValue = word[i];
                word[i] = word[randomIndex];
                word[randomIndex] = oldValue;
            }

            Console.WriteLine(string.Join("\n", word));
        }
    }
}
