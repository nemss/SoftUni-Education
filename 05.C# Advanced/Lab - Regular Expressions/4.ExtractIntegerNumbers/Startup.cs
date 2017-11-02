namespace _4.ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\d+";

            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
