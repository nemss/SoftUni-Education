using System;
using System.Text;

public abstract class Provider
{
    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    private string id;
    private double energyOutput;

    public string Id
    {
        get => id;
        protected set => id = value;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var name = GetType().Name;
        name = name.Substring(0, name.IndexOf("Provider"));

        sb.AppendLine($"{name} Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {energyOutput}");

        return sb.ToString().Trim();
    }
}