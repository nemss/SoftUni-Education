public class CircuitRace : Race
{
    public CircuitRace(int legth, string route, int prizePool, int laps) 
        : base(legth, route, prizePool)
    {
    }

    private int laps;

    public int Laps
    {
        get { return this.laps; }
        set { this.laps = value; }
    }

    public override int GetPerformance(int id)
    {
        throw new System.NotImplementedException();
    }
}
