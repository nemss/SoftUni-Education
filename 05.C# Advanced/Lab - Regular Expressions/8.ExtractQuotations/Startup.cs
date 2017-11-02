namespace _8.ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = "('|\")(.+?)\\1";


            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}
