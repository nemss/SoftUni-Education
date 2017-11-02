namespace _5.Phonebok
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();

            while (!input.Equals("search"))
            {
                var arguments = input.Trim()
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (!dict.ContainsKey(arguments[0]))
                {
                    dict.Add(arguments[0], arguments[1]);
                }
                else
                {
                    dict[arguments[0]] = arguments[1];
                }

                input = Console.ReadLine();
            }

            while (!input.Equals("stop"))
            {
                if (dict.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {dict[input]}");
                }
                else
                {
                    if (!input.Equals("search"))
                    {
                        Console.WriteLine($"Contact {input} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
