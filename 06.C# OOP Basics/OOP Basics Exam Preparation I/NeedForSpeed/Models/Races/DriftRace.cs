using System.Collections.Generic;

public class DriftRace : Race
{
    public DriftRace(int legth, string route, int prizePool) 
        : base(legth, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];
        return (car.Suspension + car.Durability);
    }
}
