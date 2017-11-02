namespace _5.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"(?:^|\s)((?:[a-zA-Z0-9]+[.\-_])*[a-zA-Z0-9]+@(?:[a-zA-z]+-*)+(?:\.[a-zA-Z]+)+)(?:\.\s)?";

            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
}
