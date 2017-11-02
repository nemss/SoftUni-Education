using System;

namespace _2.WildFarm.Models
{
    public class Cat : Felime
    {
        public Cat(string animalName, double weight, string livingRegion, string bread)
            : base(animalName, weight, livingRegion)
        {
            this.Bread = bread;
        }

        public string Bread { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return
                $"{this.GetType().Name}[{this.AnimalName}, {this.Bread}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
