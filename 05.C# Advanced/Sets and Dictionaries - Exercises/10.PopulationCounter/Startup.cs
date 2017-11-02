namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dict = new Dictionary<string, Dictionary<string, long>>();

            while (!input.Equals("report"))
            {
                var arguments = input
                    .Trim()
                    .Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var city = arguments[0];
                var country = arguments[1];
                var population = long.Parse(arguments[2]);

                if (dict.ContainsKey(country))
                {
                    if (dict[country].ContainsKey(city))
                    {
                        long value = dict[country][city];
                        dict[country][city] = value + population;
                    }
                    else
                    {
                        dict[country][city] = population;
                    }
                }
                else
                {
                    dict[country] = new Dictionary<string, long>(){{city, population}};
                }

                input = Console.ReadLine();
            }

            PrintUsers(dict);
        }

        private static void PrintUsers(Dictionary<string, Dictionary<string, long>> dict)
        {
            foreach (var element in dict.OrderByDescending(x => x.Value.Sum(p => p.Value)))
            {
                Console.WriteLine($"{element.Key} (total population: {element.Value.Sum(a => a.Value)})");
                Console.WriteLine($"{string.Join("\n", element.Value.OrderByDescending(x => x.Value).Select(a => $"=>{a.Key}: {a.Value}"))}");

            }
        }
    }
}
