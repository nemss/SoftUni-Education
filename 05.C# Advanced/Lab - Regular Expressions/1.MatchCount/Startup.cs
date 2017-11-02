namespace _1.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var input = Console.ReadLine();

            var regex = new Regex(pattern);
            var match = regex.Matches(input);

            Console.WriteLine(match.Count);
        }
    }
}
