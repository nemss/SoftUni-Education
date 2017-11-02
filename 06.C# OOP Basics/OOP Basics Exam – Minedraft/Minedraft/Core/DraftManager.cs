using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalMinedOre;
    private double totalEnergyStored;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.totalEnergyStored = 0;
        this.totalEnergyStored = 0;
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        var sb = new StringBuilder();

        try
        {
            if (type == "Sonic")
            {
                var sonicFactor = int.Parse(arguments[4]);
                harvesters.Add(id, new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor));
            }
            else if (type == "Hammer")
            {
                harvesters.Add(id, new HammerHarvester(id, oreOutput, energyRequirement));
            }
        }
        catch (ArgumentException e)
        {
            return sb.Append(e.Message).ToString();
        }

        return sb.Append($"Successfully registered {type} Harvester - {id}").ToString();
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);
        var sb = new StringBuilder();

        try
        {
            if (type == "Solar")
            {
                providers.Add(id, new SolarProvider(id, energyOutput));
            }
            else if (type == "Pressure")
            {
                providers.Add(id, new PressureProvider(id, energyOutput));
            }
        }
        catch (ArgumentException e)
        {
            return sb.Append(e.Message).ToString();
        }

        return sb.Append($"Successfully registered {type} Provider - {id}").ToString();
    }

    public string Day()
    {
        var sb = new StringBuilder();
        var dayEnergy = 0d;
        var dayOre = 0d;
        var harvestNeededEnergyForDay = 0d;

        totalEnergyStored += providers.Sum(x => x.Value.EnergyOutput);
        dayEnergy = providers.Sum(x => x.Value.EnergyOutput);
        harvestNeededEnergyForDay = harvesters.Sum(x => x.Value.EnergyRequirement);

        if (totalEnergyStored >= harvestNeededEnergyForDay)
        {
            if (this.mode == "Full")
            {
                dayOre += harvesters.Sum(x => x.Value.OreOutput);
                totalEnergyStored -= harvestNeededEnergyForDay;
            }
            else if (this.mode == "Half")
            {
                dayOre += harvesters.Sum(x => (x.Value.OreOutput * 50) / 100);
                totalEnergyStored -= (harvestNeededEnergyForDay * 60) / 100;
            }

            totalMinedOre += dayOre;
        }

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {dayEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {dayOre}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var modeCommand = arguments[0];

        switch (modeCommand)
        {
            case "Full":
                this.mode = "Full";
                break;

            case "Half":
                this.mode = "Half";
                break;

            case "Energy":
                this.mode = "Energy";
                break;
        }

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var sb = new StringBuilder();

        if (harvesters.ContainsKey(id))
        {
            sb.AppendLine($"{harvesters[id]}");
        }
        else if (providers.ContainsKey(id))
        {
            sb.AppendLine($"{providers[id]}");
        }
        else
        {
            sb.AppendLine($"No element found with id - {id}");
        }

        return sb.ToString().Trim();
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }
}