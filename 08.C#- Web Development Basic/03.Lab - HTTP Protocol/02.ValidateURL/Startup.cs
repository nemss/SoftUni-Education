namespace _02.ValidateURL
{
    using System;
    using System.Net;

    public class Startup
    {
        public static void Main()
        {
            var url = Console.ReadLine();
            var decodeUrl = WebUtility.UrlDecode(url);

            var parseUrl = new Uri(decodeUrl);

            if (string.IsNullOrEmpty(parseUrl.Host)
                && string.IsNullOrEmpty(parseUrl.Host)
                && string.IsNullOrEmpty(parseUrl.LocalPath))
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            Console.WriteLine(parseUrl.Scheme);
            Console.WriteLine(parseUrl.Host);
            if (parseUrl.Scheme == "http")
            {
                Console.WriteLine($"Port: 80");
            }
            else
            {
                Console.WriteLine($"Port: 447");
            }

            if (parseUrl.LocalPath.Length > 1)
            {
                Console.WriteLine($"Path: {parseUrl.LocalPath}");
            }
            else
            {
                Console.WriteLine($"Path: /");
            }

            Console.WriteLine(parseUrl.Query);
            Console.WriteLine(parseUrl.Fragment);
        }
    }
}