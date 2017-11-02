namespace _2.VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"[aeiouyAEIOUY]";

            var regex = new Regex(pattern);
            var match = regex.Matches(input);

            Console.WriteLine($"Vowels: {match.Count}");
        }
    }
}
