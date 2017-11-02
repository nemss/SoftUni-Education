using System;
using System.Reflection;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        carManager = new CarManager();
    }
    
    public void Run()
    {
        string inputLine;
        while (!(inputLine = Console.ReadLine()).Equals("Cops Are Here"))
        {
            var tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ExecuteCommand(tokens);           
        }
    }

    public void ExecuteCommand(string[] tokens)
    {
        switch (tokens[0])
        {
            case "register":
                var id = int.Parse(tokens[1]);
                var type = tokens[2];
                var brand = tokens[3];
                var model = tokens[4];
                var yearOfProduction = int.Parse(tokens[5]);
                var horsepower = int.Parse(tokens[6]);
                var acceleration = int.Parse(tokens[7]);
                var suspension = int.Parse(tokens[8]);
                var durability = int.Parse(tokens[9]);
                carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "check":
                id = int.Parse(tokens[1]);
                Console.WriteLine(carManager.Check(id));
                break;
            case "open":
                id = int.Parse(tokens[1]);
                type = tokens[2];
                var length = int.Parse(tokens[3]);
                var route = tokens[4];
                var prizePool = int.Parse(tokens[5]);
                if (type.Equals("TimeLimit") || type.Equals("Circuit"))
                {
                    carManager.Open(id, type, length, route, prizePool, int.Parse(tokens[6]));
                }
                else
                {
                    carManager.Open(id, type, length, route, prizePool);
                }
                break;
            case "participate":
                var carId = int.Parse(tokens[1]);
                var raceId = int.Parse(tokens[2]);
                carManager.Participate(carId, raceId);
                break;
            case "start":
                raceId = int.Parse(tokens[1]);
                Console.WriteLine(carManager.Start(raceId));
                break;
            case "park":
                carId = int.Parse(tokens[1]);
                carManager.Park(carId);
                break;
            case "unpark":
                carId = int.Parse(tokens[1]);
                carManager.Unpark(carId);
                break;
            case "tune":
                var tuneIndex = int.Parse(tokens[1]);
                var tuneAddOn = tokens[2];
                carManager.Tune(tuneIndex, tuneAddOn);
                break;
        }
    }
}

