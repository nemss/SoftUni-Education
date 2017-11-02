using _2.WildFarm.Models;

namespace _2.WildFarm
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var tokensAnimal = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var tokensFood = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Food food = null;
                var nameFood = tokensFood[0];
                var foodQuantity = int.Parse(tokensFood[1]);
                switch (tokensFood[0])
                {
                    case "Vegetable":
                        food = new Vegetable(foodQuantity);
                        break;
                    case "Meat":
                        food = new Meat(foodQuantity);
                        break;
                }


                Animal animal;

                var animalName = tokensAnimal[1];
                var weight = double.Parse(tokensAnimal[2]);
                var livingRegion = tokensAnimal[3];

                switch (tokensAnimal[0])
                {
                    case "Mouse":
                        animal = new Mouse(animalName, weight, livingRegion);
                        animal.MakeSound();
                        animal.Eat(food);
                        Console.WriteLine(animal);
                        break;
                    case "Zebra":
                        animal = new Zebra(animalName, weight, livingRegion);
                        animal.MakeSound();
                        animal.Eat(food);
                        Console.WriteLine(animal);
                        break;
                    case "Cat":
                        var bread = tokensAnimal[4];
                        animal = new Cat(animalName, weight, livingRegion, bread);
                        animal.MakeSound();
                        animal.Eat(food);
                        Console.WriteLine(animal);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalName, weight, livingRegion);
                        animal.MakeSound();
                        animal.Eat(food);
                        Console.WriteLine(animal);
                        break;
                }

            }
        }
    }
}
