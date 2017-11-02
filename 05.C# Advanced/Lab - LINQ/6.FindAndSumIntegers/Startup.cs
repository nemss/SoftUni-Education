namespace _6.FindAndSumIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var result = 0;
            var inputSomeText = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(i => int.TryParse(i, out result))
                .Select(long.Parse)
                .Sum();

            if (inputSomeText != 0)
            {
                Console.WriteLine(inputSomeText);
            }
            else
            {
                Console.WriteLine("No match");
            }

        }
    }
}