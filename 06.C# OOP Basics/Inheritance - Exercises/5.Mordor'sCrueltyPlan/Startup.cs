namespace _5.Mordor_sCrueltyPlan
{
    using System;
    using System.Collections.Generic;
    using _5.Mordor_sCrueltyPlan.FoodModels;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listOfFood = new List<Food>();
            var inputLine = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var food in inputLine)
            {
                var createFood = FoodFactory.CreateFood(food);
                listOfFood.Add(createFood);
            }

            Console.WriteLine(MoodFactory.CalculatePointsOfHappiness(listOfFood));
            MoodFactory.PrintMood(listOfFood);
        }
    }
}
