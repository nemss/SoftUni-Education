namespace _4.ShoppingSpree
{
    using System;

    public class Product
    {
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        private string name;
        private decimal cost;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return this.cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }
    }
}
