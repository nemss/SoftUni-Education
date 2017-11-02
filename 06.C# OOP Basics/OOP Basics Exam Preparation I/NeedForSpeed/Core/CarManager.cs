using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (type.Equals("Performance"))
        {
            Car car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            this.cars.Add(id, car);
        }
        else if (type.Equals("Show"))
        {
            Car car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            this.cars.Add(id, car);
        }
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int lenght, string route, int prizePool)
    {
        if (type.Equals("Casual"))
        {
            Race race = new CasualRace(lenght, route, prizePool);
            this.races.Add(id, race);
        }
        else if (type.Equals("Drag"))
        {
            Race race = new DragRace(lenght, route, prizePool);
            this.races.Add(id, race);
        }
        else if (type.Equals("Drift"))
        {
            Race race = new DriftRace(lenght, route, prizePool);
            this.races.Add(id, race);
        }

    }

    public void Open(int id, string type, int lenght, string route, int prizePool, int bonus)
    {
        if (type.Equals("TimeLimit"))
        {
            Race race = new TimeLimitRace(lenght, route, prizePool, bonus);
            this.races.Add(id, race);
        }
        else if (type.Equals("Circuit"))
        {
            Race race = new CircuitRace(lenght, route, prizePool, bonus);
            this.races.Add(id, race);
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Contains(carId))
        {
            this.races[raceId].Participants.Add(carId, cars[carId]);
        }
    }

    public string Start(int id)
    {
        if (races[id].StartRace() == null)
        {
            return "Cannot start the race with zero participants.";
        }

        var race = races[id].StartRace();
        races.Remove(id);
        return race;
    }

    public void Park(int id)
    {
        foreach (var race in races.Values)
        {
            if (race.Participants.ContainsKey(id))
            {
                return;
            }
        }

        this.garage.ParkedCars.Add(id);
    }

    public void Unpark(int id)
    {
        garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var carGarage in garage.ParkedCars)
        {
            var car = cars[carGarage];
            car.Tune(tuneIndex, addOn);
        }
    }
}

