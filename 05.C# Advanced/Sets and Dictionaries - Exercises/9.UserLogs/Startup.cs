namespace _9.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> dict = new SortedDictionary<string, Dictionary<string, int>>();

            while (!input.Equals("end"))
            {
                var arguments = input.Split(' ');
                var ip = arguments[0].Replace("IP=", "");
                var username = arguments[2].Replace("user=", "");

                if (dict.ContainsKey(username))
                {
                    if (dict[username].ContainsKey(ip))
                    {
                        dict[username][ip]++;
                    }
                    else
                    {
                        dict[username][ip] = 1;
                    }
                }
                else
                {
                    dict[username] = new Dictionary<string, int>(){{ip, 1}};
                }
                
                input = Console.ReadLine();
            }
                PrintUsers(dict);
        }

        private static void PrintUsers(SortedDictionary<string, Dictionary<string, int>> dict)
        {
            foreach (var user in dict)
            {
                Console.WriteLine($"{user.Key}:");
                Console.WriteLine($"{string.Join(", ", user.Value.Select(a => $"{a.Key} => {a.Value}"))}.");
            }
        }
    }
}
