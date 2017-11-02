namespace _2.ParseURLs
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var url = Console.ReadLine();

            string separator = "://";
            var urlTokens = url.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);

            if (urlTokens.Length != 2 || urlTokens[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = urlTokens[0];
                var server = urlTokens[1].Substring(0, urlTokens[1].IndexOf('/'));
                var resource = urlTokens[1].Substring(urlTokens[1].IndexOf('/') + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resource}");
            }
        }
    }
}
