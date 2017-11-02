namespace _3.CountUpperCaseWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            input.Where(checker)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
