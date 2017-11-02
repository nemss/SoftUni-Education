namespace _1.TakeTwo
{
    using System.Linq;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct();


            inputNumbers.Where(n => n >= 10 && n <= 20)
             .Take(2)
             .ToList()
             .ForEach(n => Console.Write($"{n} "));
        }
    }
}
