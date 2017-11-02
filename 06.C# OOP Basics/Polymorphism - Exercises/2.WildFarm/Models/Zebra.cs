using System;

namespace _2.WildFarm.Models
{
    public class Zebra : Mammal
    {
        public Zebra(string animalName, double weight, string livingRegion) 
            : base(animalName, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable")
            {
                Console.WriteLine("Zebras are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }
    }
}
