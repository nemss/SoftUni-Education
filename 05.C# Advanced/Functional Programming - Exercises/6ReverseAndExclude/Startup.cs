namespace _6ReverseAndExclude
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var devisibleN = int.Parse(Console.ReadLine());

            numbers.Where(n => n % devisibleN != 0)
                .Reverse()
                .ToList()
                .ForEach(n => Console.Write($"{n} "));
        }
    }
}
