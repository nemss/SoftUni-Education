using System;

namespace _2.WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string animalName, double weight, string livingRegion) 
            : base(animalName, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable")
            {
                Console.WriteLine("Mouses are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }
    }
}
