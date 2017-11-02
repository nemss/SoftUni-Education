namespace _1.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"[A-Z][a-z]+ [A-Z][a-z]+";

            while(input != "end")
            {
                var regex = new Regex(pattern);
                var matches = regex.Matches(input);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
