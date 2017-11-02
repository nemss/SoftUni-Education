using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int legth, string route, int prizePool, int goldTime) 
        : base(legth, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    private int goldTime;

    public int GoldTime
    {
        get { return this.goldTime; }
        set { this.goldTime = value; }
    }
    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];
        return this.Legth * ((car.HorsePower / 100) * car.Acceleration);
    }

    public override Dictionary<int, Car> GetWinners()
    {
        var winners = this.Participants.Take(1)
            .ToDictionary(n => n.Key, m => m.Value);

        return winners;
    }

    public override string StartRace()
    {
        var sb = new StringBuilder();
        var winners = this.GetWinners();
        var car = winners.ElementAt(0);

        sb.AppendLine($"{this.Route} - {this.Legth}");
        sb.AppendLine($"{car.Value.Brand} {car.Value.Model} - {this.GetPerformance(car.Key)} s.");
        sb.AppendLine()
    }
}

