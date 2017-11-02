using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    protected Race(int legth, string route, int prizePool)
    {
        this.Legth = legth;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
        this.Winners = new List<Car>();
    }

    private int legth;
    private string route;
    private int prizePool;

    public Dictionary<int, Car> Participants { get; set; }
    public List<Car> Winners { get; set; }
    public int Legth
    {
        get { return this.legth; }
        protected set { this.legth = value; }
    }

    public string Route
    {
        get { return this.route; }
        protected set { this.route = value; }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        protected set { this.prizePool = value; }
    }

    public abstract int GetPerformance(int id);

    public virtual Dictionary<int, Car> GetWinners()
    {
        var winners = this.Participants.OrderByDescending(n => this.GetPerformance(n.Key)).Take(3)
            .ToDictionary(n => n.Key, m => m.Value);

        return winners;
    }

    public List<int> GetPrizez()
    {
        var result = new List<int>();
        result.Add((this.PrizePool * 50) / 100);
        result.Add((this.PrizePool * 30) / 100);
        result.Add((this.PrizePool * 20) / 100);

        return result;
    }
    public virtual string StartRace()
    {
        var winners = this.GetWinners();
        var prizes = this.GetPrizez();

        if (winners.Count == 0)
        {
            return null;
        }
       
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Legth}");

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);
            sb.AppendLine(
                $"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${prizes[i]}");
        }

        return sb.ToString().Trim();
    }

}

