namespace _8.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();

            while (!input.Equals("JOKER"))
            {
                var arguments = input
                    .Split(':');
                    
                var name = arguments[0];
                var cards = new HashSet<string>(arguments[1].Split(',').Select(a => a.Trim()));

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, cards);
                }
                else
                {
                    dict[name].UnionWith(cards);
                }

                input = Console.ReadLine();
            }

            foreach (var player in dict)
            {
                var score = 0.0;

                foreach (var card in player.Value)
                {
                    long powerScore;
                    var power = card.Substring(0, card.Length - 1);
                    var type = card[card.Length - 1];
                    var isNumber = long.TryParse(power, out powerScore);

                    if (!isNumber)
                    {
                        switch (power)
                        {
                            case "J":
                                powerScore = 11;
                                break;
                            case "Q":
                                powerScore = 12;
                                break;
                            case "K":
                                powerScore = 13;
                                break;
                            case "A":
                                powerScore = 14;
                                break;
                        }
                    }

                    switch (type)
                    {
                        case 'S':
                            powerScore *= 4;
                            break;
                        case 'H':
                            powerScore *= 3;
                            break;
                        case 'D':
                            powerScore *= 2;
                            break;
                        case 'C':
                            powerScore *= 1;
                            break;
                    }

                    score += powerScore;
                }

                Console.WriteLine($"{player.Key}: {score}");
            }

        }
    }
}
