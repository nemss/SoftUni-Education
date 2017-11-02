namespace _4.ReplaceAtag
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"<a (href=.+?)>(.+)<\/a>";

            while (!input.Equals("end"))
            {
                var result = Regex.Replace(input, pattern, w => $"[URL {w.Groups[1]}]{w.Groups[2]}[/URL]");
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
