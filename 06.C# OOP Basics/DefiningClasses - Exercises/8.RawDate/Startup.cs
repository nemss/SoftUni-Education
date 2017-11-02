namespace _8.RawDate
{
    using  System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listCars = new List<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var speed = int.Parse(carInfo[1]);
                var power = int.Parse(carInfo[2]);
                var weight = int.Parse(carInfo[3]);
                var type = carInfo[4];
                var tire1Pressure = double.Parse(carInfo[5]);
                var tire1Age = int.Parse(carInfo[6]);
                var tire2Pressure = double.Parse(carInfo[7]);
                var tire2Age = int.Parse(carInfo[8]);
                var tire3Pressure = double.Parse(carInfo[9]);
                var tire3Age = int.Parse(carInfo[10]);
                var tire4Pressure = double.Parse(carInfo[11]);
                var tire4Age = int.Parse(carInfo[12]);

                var car = new Car(model, new Engine(speed, power), new Cargo(weight, type),
                    new List<Tyre>
                    {
                        new Tyre(tire1Pressure, tire1Age),
                        new Tyre(tire2Pressure, tire2Age),
                        new Tyre(tire3Pressure, tire3Age),
                        new Tyre(tire4Pressure, tire4Age)
                    });
                listCars.Add(car);
            }

            var command = Console.ReadLine();

            if (command.Equals("fragile"))
            {
                listCars.Where(c => c.cargo.Type.Equals("fragile"))
                    .Where(c => c.tires.Any(x => x.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList()
                    .ForEach(output => Console.WriteLine(output));
            }
            else if (command.Equals("flamable"))
            {
                listCars.Where(c => c.cargo.Type.Equals("flamable"))
                    .Where(c => c.engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList()
                    .ForEach(output => Console.WriteLine(output));
            }
        }
    }    
}


