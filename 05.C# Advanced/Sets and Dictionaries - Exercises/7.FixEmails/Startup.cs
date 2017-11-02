namespace _7.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> dict = new Dictionary<string, string>();

            while (!input.Equals("stop"))
            {
                string email = Console.ReadLine();

                if (email.EndsWith("uk") || email.EndsWith("us"))
                {
                    continue;
                }

                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, email);
                }
                else
                {
                    dict[input] = email;
                }

                input = Console.ReadLine();
            }

            foreach (var element in dict)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    }
}
