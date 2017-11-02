namespace _13.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dict = new Dictionary<string, Dictionary<string, long>>();

            while (!input.Equals("End"))
            {

                var arguments = input
                    .Split(new string[] { " @" }, StringSplitOptions.RemoveEmptyEntries);

                if (arguments.Length == 2)
                {

                    var firstPart = arguments[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var secondPart = arguments[1].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    var singer = string.Join(" ", firstPart);
                    var venue = string.Join(" ", secondPart.Take(secondPart.Length - 2));
                    var ticketPrice = long.Parse(secondPart[secondPart
                                                                .Length - 2]);
                    var ticketsCount = long.Parse(secondPart[secondPart.Length - 1]);

                    if (dict.ContainsKey(venue))
                    {
                        if (dict[venue].ContainsKey(singer))
                        {
                            dict[venue][singer] += ticketPrice * ticketsCount;
                        }
                        else
                        {
                            dict[venue][singer] = ticketPrice * ticketsCount;
                        }
                    }
                    else
                    {
                        dict[venue] = new Dictionary<string, long>() {{singer, ticketsCount * ticketPrice}};
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var element in dict)
            {
                Console.WriteLine($"{element.Key}");

                foreach (var e in element.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {e.Key} -> {e.Value}");
                }
            }
        }
    }
}
