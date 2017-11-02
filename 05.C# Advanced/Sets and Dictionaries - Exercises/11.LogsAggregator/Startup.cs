namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var dict = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine()
                    .Trim()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var user = input[1];
                var ip = input[0];
                var duration = int.Parse(input[2]);

                if (dict.ContainsKey(user))
                {
                    if (dict[user].ContainsKey(ip))
                    {
                        var lastDuration = dict[user][ip];
                        dict[user][ip] = duration + lastDuration;
                    }
                    else
                    {
                        dict[user][ip] = duration;
                    }
                }
                else
                {
                    dict[user] = new SortedDictionary<string, int>(){{ip, duration}};
                }
            }

            PrintUsers(dict);
        }

        private static void PrintUsers(SortedDictionary<string, SortedDictionary<string, int>> dict)
        {
            foreach (var user in dict)
            {
                Console.WriteLine($"{user.Key}: {user.Value.Sum(a => a.Value)} [{string.Join(", ", user.Value.Select(a => a.Key))}]");
            }
        }
    }
}
