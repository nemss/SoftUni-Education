namespace Card_Problem.Models
{
    using Card_Problem.Enums;
    using System;

    public class Card : IComparable<Card>
    {
        public CardRank CardRank { get; protected set; }
        public CardSuits CardSuits { get; protected set; }

        public Card(string rank, string suit)
        {
            this.CardRank = (CardRank)Enum.Parse(typeof(CardRank), rank);
            this.CardSuits = (CardSuits)Enum.Parse(typeof(CardSuits), suit);
        }

        public int CalculatePower()
        {
            return (int)this.CardRank + (int)this.CardSuits;
        }

        public override string ToString()
        {
            return $"Card name: {Enum.GetName(typeof(CardRank), this.CardRank)} of {Enum.GetName(typeof(CardSuits), this.CardSuits)}; Card power: {this.CalculatePower()}";
        }

        public int CompareTo(Card other)
        {
            var result = other.CalculatePower().CompareTo(this.CalculatePower());

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Card card = obj as Card;

            return this.CalculatePower().Equals(card.CalculatePower());
        }
    }
}