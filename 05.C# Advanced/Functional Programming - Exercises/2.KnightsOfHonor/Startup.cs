namespace _2.KnightsOfHonor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' ', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printCollection = p => p.ForEach(s => Console.WriteLine($"Sir {s}"));

            printCollection(input);

        }
    }
}
