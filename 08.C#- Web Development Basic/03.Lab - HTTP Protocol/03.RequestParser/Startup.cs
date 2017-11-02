namespace _03.RequestParser
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var validUrls = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                var urlParts = line.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var path = $"/{urlParts[0]}";
                var method = urlParts[1];

                if (!validUrls.ContainsKey(path))
                {
                    validUrls[path] = new HashSet<string>();
                }

                validUrls[path].Add(method);
            }

            var request = Console.ReadLine();
            var requestParts = request.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var requestMethod = requestParts[0];
            var requestUrl = requestParts[1];
            var requestProtocol = requestParts[2];

            var responseStatusText = "Not Found";
            var responseStatus = 404;

            if (validUrls.ContainsKey(requestUrl)
                && validUrls[requestUrl].Contains(requestMethod.ToLower()))
            {
                responseStatus = 200;
                responseStatusText = "OK";
            }

            Console.WriteLine($"{requestProtocol} {responseStatus} {responseStatusText}");
            Console.WriteLine($"Content-Length: {responseStatusText.Length}");
            Console.WriteLine("Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(responseStatusText);
        }
    }
}