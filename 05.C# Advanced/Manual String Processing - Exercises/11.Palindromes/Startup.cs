namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Trim()
                .Split(new char[] {',', ';', '!', '.', ' ', '?'}, StringSplitOptions.RemoveEmptyEntries);

            var sortedPolindromes = new SortedSet<string>();
                           
            foreach (var element in text)
            {
                if (IsPolindromes(element))
                {
                    sortedPolindromes.Add(element);
                }
            }

            Console.WriteLine($"[{string.Join(", ", sortedPolindromes)}]");
        }

        private static bool IsPolindromes(string s)
        {
            return s == new string(s.Reverse().ToArray());
        }
    }
}
