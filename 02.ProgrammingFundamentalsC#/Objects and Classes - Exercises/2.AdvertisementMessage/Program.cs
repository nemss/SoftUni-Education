using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] events = new[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] author = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int advertisementCount = int.Parse(Console.ReadLine());
            Random rand = new Random();
            for (int i = 0; i < advertisementCount; i++)
            {
                Console.WriteLine("{0} {1} {2} - {3}", phrases[rand.Next(0, phrases.Length)], events[rand.Next(0, phrases.Length)], author[rand.Next(0, author.Length)], cities[rand.Next(0, cities.Length)]);
            } 

        }
    }
}
