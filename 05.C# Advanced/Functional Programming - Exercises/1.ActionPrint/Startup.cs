namespace _1.ActionPrint
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
                .ToList();

            Action<List<string>> print = p => p.ForEach(a => Console.WriteLine(a));

            print(input);
        }
    }
}
