namespace _5.Mordor_sCrueltyPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _5.Mordor_sCrueltyPlan.FoodModels;

    public class MoodFactory
    {
        public static void PrintMood(List<Food> foods)
        {
            var sumHappines = MoodFactory.CalculatePointsOfHappiness(foods);

            if (sumHappines < -5)
            {
                Console.WriteLine("Angry");
            }
            else if (sumHappines >= -5 && sumHappines <= 0)
            {
                Console.WriteLine("Sad");
            }
            else if (sumHappines >= 1 && sumHappines <= 15)
            {
                Console.WriteLine("Happy");
            }
            else if (sumHappines > 15)
            {
                Console.WriteLine("JavaScript");
            }
        }

        public static int CalculatePointsOfHappiness(List<Food> foods)
        {
            return foods.Sum(x => x.PointOfHappiness);
        }
    }
}
