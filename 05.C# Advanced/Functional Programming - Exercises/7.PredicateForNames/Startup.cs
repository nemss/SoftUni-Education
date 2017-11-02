namespace _7.PredicateForNames
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var nameLenght = int.Parse(Console.ReadLine());
            var inputNames = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> checkLenghtName = x => x.Length <= nameLenght;

            inputNames.Where(i => checkLenghtName(i) == true)
                .ToList()
                .ForEach(i => Console.WriteLine($"{i}"));
                
        }
    }
}
