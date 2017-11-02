public abstract class Bender
{
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    private string name;
    private int power;

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public int Power
    {
        get { return this.power; }
        protected set { this.power = value; }
    }

    public abstract double GetPower();

    public override string ToString()
    {
        var benderType = this.GetType().Name;
        var typeEnd = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEnd, " ");

        return $"{benderType}: {this.Name}, Power: {this.Power}";
    }
}

