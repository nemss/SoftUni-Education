namespace _5.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }
        public List<Topping> Toppings
        {
            get { return this.toppings; }
            set
            {
                this.toppings = value;
            }
        }

        public void AddToppind(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        public double Callories()
        {
            double callories = 0;
            callories += this.dough.Calories();
            this.Toppings.ForEach(c => callories += c.Callories());

            return callories;
        }

    }
}
