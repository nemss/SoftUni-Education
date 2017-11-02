namespace _6.CountSubstringOccurrences
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();                   
            string pattern = Console.ReadLine().ToLower();
            int counter = 0;

            int indexOfCurrence = text.IndexOf(pattern);
            while (indexOfCurrence != -1)
            {
                counter++;
                indexOfCurrence = text.IndexOf(pattern ,indexOfCurrence + 1);
            }

            Console.WriteLine(counter);
        }
    }
}
