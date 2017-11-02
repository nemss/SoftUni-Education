namespace _3.CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> minFunction = p => p.Min();

            var result = minFunction(input);
            Console.WriteLine(result);
        }
    }
}
