namespace _3.NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\D";

            var regex = new Regex(pattern);
            var match = regex.Matches(input);

            Console.WriteLine($"Non-digits: {match.Count}");
        }
    }
}
