using System;

namespace _2.WildFarm.Models
{
    public class Tiger : Felime
    {
        public Tiger(string animalName, double weight, string livingRegion) 
            : base(animalName, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine("Tigers are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }         
        }
    }
}
