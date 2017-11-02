namespace _5.MinEvenNumber
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
                var inputNumbers = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .Where(n => n % 2 == 0)
                    .DefaultIfEmpty()
                    .Min();

            if (inputNumbers != 0.00)
            {
                Console.WriteLine($"{inputNumbers:f2}");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
