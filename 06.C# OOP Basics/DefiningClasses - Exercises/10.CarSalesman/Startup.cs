namespace _10.CarSalesman
{
    using  System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listEngines = new List<Engine>();
            var numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[0];
                var power = int.Parse(tokens[1]);

                if (tokens.Length == 2)
                {
                    listEngines.Add(new Engine(model, power));
                }
                else if (tokens.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(tokens[2], out displacement))
                    {
                        listEngines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        listEngines.Add(new Engine(model, power, tokens[2]));
                    }
                }
                else if (tokens.Length == 4)
                {
                    listEngines.Add(new Engine(model, power, int.Parse(tokens[2]), tokens[3]));
                }
            }

            var listCars = new List<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];
                var engine = listEngines.FirstOrDefault(e => e.Model == tokens[1]);

                if (tokens.Length == 2)
                {
                    listCars.Add(new Car(model, engine));
                }
                else if (tokens.Length == 3)
                {
                    int weight;
                    if (int.TryParse(tokens[2], out weight))
                    {
                        listCars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        listCars.Add(new Car(model, engine, tokens[2]));
                    }
                }
                else if (tokens.Length == 4)
                {
                    listCars.Add(new Car(model, engine, int.Parse(tokens[2]), tokens[3]));
                }
            }

            foreach (var car in listCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine("    Displacement: {0}", car.Engine.Displacement == 0 ? "n/a" : car.Engine.Displacement.ToString());
                Console.WriteLine($"    Efficiency: {car.Engine.Efficienty}");
                Console.WriteLine("  Weight: {0}", car.Weight == 0 ? "n/a" : car.Weight.ToString());
                Console.WriteLine($"  Color: {car.Color}");

            }
        }             
    }
}
