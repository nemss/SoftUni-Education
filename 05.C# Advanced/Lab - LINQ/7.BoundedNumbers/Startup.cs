namespace _7.BoundedNumbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var bounds = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => bounds.Min() <= n && n <= bounds.Max())
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
