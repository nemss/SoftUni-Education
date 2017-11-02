namespace _4.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        private string name;
        private decimal money;
        private List<Product> products;
        public List<Product> Products { get; set; }

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

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }
                this.money = value;
            }
        }

        public void ByProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                this.Money -= product.Cost;
                this.Products.Add(product);
            }

        }
    }
}
