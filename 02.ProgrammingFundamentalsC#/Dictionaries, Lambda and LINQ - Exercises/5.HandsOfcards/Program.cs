using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.HandsOfcards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> playersCards = new Dictionary<string, List<string>>();

            string commandLine = Console.ReadLine();

            while(! commandLine.Equals("JOKER"))
            {
                string[] commadArgs = commandLine.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string playerName = commadArgs[0];
                string[] cards = commadArgs[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                if (!playersCards.ContainsKey(playerName))
                {
                    playersCards.Add(playerName, new List<string>());
                }

                playersCards[playerName].AddRange(cards);

                commandLine = Console.ReadLine();
            }

            PrintPlayearsScores(playersCards);
        }

        private static void PrintPlayearsScores(Dictionary<string, List<string>> playersCards)
        {
            foreach (var playearEntry in playersCards)
            {
                string playerName = playearEntry.Key;
                List<string> cards = playearEntry.Value.Distinct().ToList();

                int playerScore = 0;

                foreach (var card in cards)
                {
                    string rank = card.Substring(0, card.Length - 1);
                    string suite = card.Substring(card.Length - 1);

                    int rankPower = GetRank(rank);
                    int suitePower = GetSuite(suite);

                    playerScore += rankPower * suitePower;
                }

                Console.WriteLine("{0}: {1}",playerName, playerScore);
            }
        }

        private static int GetSuite(string suite)
        {
            switch (suite)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
                default:
                    return 1;
                    break;
            }
        }

        private static int GetRank(string rank)
        {
            switch (rank)
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return 1;
                    break;
            }
        }
    }
}
