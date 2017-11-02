using System;
using System.Text;

public abstract class Harvester
{
    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    private string id;
    private double oreOutput;
    private double energyRequirement;

    public string Id
    {
        get => id;
        protected set => id = value;
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException(
                    $"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var name = GetType().Name;
        name = name.Substring(0, name.IndexOf("Harvester"));

        sb.AppendLine($"{name} Harvester - {id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}