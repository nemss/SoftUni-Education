namespace _8.CustomComparator
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

            var orderEven = numbers.Where(n => n % 2 == 0)
                .OrderBy(n => n);

            var odd = numbers.Where(n => n % 2 != 0)
                .OrderBy(n => n);

            Console.WriteLine(string.Join(" ", orderEven.Concat(odd)));

        }
    }
}
