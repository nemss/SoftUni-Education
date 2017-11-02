namespace Card_Problem.Core
{
    using Card_Problem.Enums;
    using Card_Problem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private string firstPlayerName;
        private string secondPlayerName;
        private IList<Card> deck;
        private IList<Card> firstPlayer;
        private IList<Card> secondPlayer;

        public Engine()
        {
            this.firstPlayer = new List<Card>();
            this.secondPlayer = new List<Card>();
            this.deck = GenerateDeck();
        }

        public void Run()
        {
            this.firstPlayerName = Console.ReadLine();
            this.secondPlayerName = Console.ReadLine();

            while (firstPlayer.Count < 5 || secondPlayer.Count < 5)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new string[] { " of " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                try
                {
                    var card = new Card(inputArgs[0], inputArgs[1]);
                    if (deck.Contains(card))
                    {
                        deck.Remove(card);
                        if (firstPlayer.Count < 5)
                        {
                            firstPlayer.Add(card);
                        }
                        else
                        {
                            secondPlayer.Add(card);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            var winner = GetWinner();

            Console.WriteLine(winner);
        }

        private string GetWinner()
        {
            Card biggesFirstPlayer = firstPlayer.OrderByDescending(c => c.CalculatePower()).FirstOrDefault();
            Card biggestSecondPlayer = secondPlayer.OrderByDescending(c => c.CalculatePower()).FirstOrDefault();

            if (biggesFirstPlayer.CalculatePower() >= biggestSecondPlayer.CalculatePower())
            {
                return
                    $"{this.firstPlayerName} wins with {biggesFirstPlayer.CardRank} of {biggesFirstPlayer.CardSuits}.";
            }
            else
            {
                return $"{this.secondPlayerName} wins with {biggestSecondPlayer.CardRank} of {biggestSecondPlayer.CardSuits}.";
            }
        }

        private IList<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();

            foreach (var suit in Enum.GetNames(typeof(CardSuits)))
            {
                foreach (var rank in Enum.GetNames(typeof(CardRank)))
                {
                    deck.Add(new Card(rank, suit));
                }
            }

            return deck;
        }
    }
}