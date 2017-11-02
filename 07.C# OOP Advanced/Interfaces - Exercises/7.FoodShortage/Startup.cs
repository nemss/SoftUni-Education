namespace _7.FoodShortage
{
    using _7.FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var inhabitans = new List<IIhabitant>();
            var numbersOfIhabitant = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfIhabitant; i++)
            {
                var information = Console.ReadLine().Split(' ');

                if (information.Length == 4)
                {
                    inhabitans.Add(new Citizen(information[0], int.Parse(information[1]), information[2], information[3]));
                }
                else if (information.Length == 3)
                {
                    inhabitans.Add(new Rebel(information[0], int.Parse(information[1]), information[2]));
                }
            }

            string inputLine;
            var sum = 0;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var name = inhabitans.FirstOrDefault(x => x.Name == inputLine);

                if (name != null)
                {
                    sum += name.BuyFood();
                }
            }

            Console.WriteLine(sum);
        }
    }
}