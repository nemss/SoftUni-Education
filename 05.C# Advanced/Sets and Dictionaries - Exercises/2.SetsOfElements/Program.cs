namespace _2.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var arguments = Console.ReadLine()
                .Trim()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int n =int.Parse(arguments[0]);
            int m = int.Parse(arguments[1]);

            HashSet<string> nHashSet = new HashSet<string>();
            HashSet<string> mHashSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                nHashSet.Add(input);
            }

            for (int i = 0; i < m; i++)
            {
                string input = Console.ReadLine();
                mHashSet.Add(input);
            }

            Console.WriteLine($"{string.Join(" ", nHashSet.Intersect(mHashSet))}");
            
        }
    }
}
