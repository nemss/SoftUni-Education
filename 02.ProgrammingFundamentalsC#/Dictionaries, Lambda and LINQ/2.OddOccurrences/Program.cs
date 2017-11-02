using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numberAsString = Console.ReadLine().ToLower().Split();

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (var word in numberAsString)
            {
                if(wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            List<string> sortWord = new List<string>();

            foreach ( KeyValuePair<string,int> word in wordCount)
            {
                if(word.Value % 2 == 1)
                {
                    sortWord.Add(word.Key);
                }
            }

            Console.WriteLine(string.Join(", ", sortWord));
        }
    }
}
