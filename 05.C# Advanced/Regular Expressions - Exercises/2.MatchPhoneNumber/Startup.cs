namespace _2.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\+359( |-)\d{1}\1\d{3}\1\d{4}\b";

            while (!input.Equals("end"))
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
