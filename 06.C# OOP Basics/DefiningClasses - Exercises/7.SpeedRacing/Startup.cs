using System.Collections.Generic;
using System.Linq;

namespace _7.SpeedRacing
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];
                var fuelAmount = decimal.Parse(tokens[1]);
                var consumptionFor1Km = decimal.Parse(tokens[2]);
                var car = new Car(model, fuelAmount, consumptionFor1Km);
                cars.Add(car);
            }

            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("End"))
            {
                var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[1];
                var travelDistance = int.Parse(tokens[2]);

                cars.Where(c => c.Model == model).ToList().ForEach(c => c.Drive(travelDistance));
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravel}");
            }
        }
    }
}
