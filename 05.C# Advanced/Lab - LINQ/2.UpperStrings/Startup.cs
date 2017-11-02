namespace _2.UpperStrings
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            input.ToUpper()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)               
                .ToList()
                .ForEach(n => Console.Write($"{n} "));
        }
    }
}
