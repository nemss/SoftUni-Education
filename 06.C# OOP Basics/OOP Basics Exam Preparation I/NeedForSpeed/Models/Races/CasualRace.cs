using System.Collections.Generic;

public class CasualRace : Race
{
    public CasualRace(int legth, string route, int prizePool) 
        : base(legth, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];
        return (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);
    }
}
