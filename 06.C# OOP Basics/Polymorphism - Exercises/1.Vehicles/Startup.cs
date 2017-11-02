namespace _1.Vehicles
{
    using System;
    using _1.Vehicles.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var carTokens = Console.ReadLine()
                .Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            var trackTokens = Console.ReadLine()
                .Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            var busTokens = Console.ReadLine()
                .Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            var numberOfCommands = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
            Vehicle truck = new Truck(double.Parse(trackTokens[1]), double.Parse(trackTokens[2]),
                double.Parse(trackTokens[3]));
            Vehicle bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (command[1].Equals("Car"))
                    {
                        Execute(car, command[0], double.Parse(command[2]));
                    }
                    else if (command[1].Equals("Truck"))
                    {
                        Execute(truck, command[0], double.Parse(command[2]));
                    }
                    else if (command[1].Equals("Bus"))
                    {
                        Execute(bus, command[0], double.Parse(command[2]));
                    }
                }


                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void Execute(Vehicle vehicle, string command, double parameter)
        {
            switch (command)
            {
                case "Drive":
                    var result = vehicle.TryTravelDistance(parameter);
                    Console.WriteLine(result);
                    break;
                case "Refuel":
                    vehicle.Refuel(parameter);
                    break;
                case "DriveEmpty":
                    result = vehicle.TryTravelDistance(parameter, false);
                    Console.WriteLine(result);
                    break;;
            }
        }
    }
}

   

        
        
    

