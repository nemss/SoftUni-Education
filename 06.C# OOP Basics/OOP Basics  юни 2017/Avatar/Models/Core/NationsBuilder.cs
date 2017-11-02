using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{

    private Dictionary<string, Nation> nations;
    private List<string> warHistory;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation()},
            {"Fire", new Nation()},
            {"Water", new Nation()},
            {"Earth", new Nation()}
        };
        this.warHistory = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParameter = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                Bender bender = new AirBender(name, power, secondaryParameter);
                this.nations[type].AddBender(bender);
                break;
            case "Water":
                bender = new WaterBender(name, power, secondaryParameter);
                this.nations[type].AddBender(bender);
                break;
            case "Fire":
                bender = new FireBender(name, power, secondaryParameter);
                this.nations[type].AddBender(bender);
                break;
            case "Earth":
                bender = new EarthBender(name, power, secondaryParameter);
                this.nations[type].AddBender(bender);
                break;
        }
    }//Done

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                Monument monument = new AirMonument(name, affinity);
                this.nations[type].AddMonument(monument);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                this.nations[type].AddMonument(monument);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                this.nations[type].AddMonument(monument);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                this.nations[type].AddMonument(monument);
                break;
        }
    } //Done

    public string GetStatus(string nationsType)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");
        sb.AppendLine($"{this.nations[nationsType]}");

        return sb.ToString().Trim();

    }//Done

    public void IssueWar(string nationsType)
    {
        var maxPower = this.nations.Max(k => k.Value.GetTotalPower());
        foreach (var nation in this.nations.Values)
        {
            if (nation.GetTotalPower() != maxPower)
            {
                nation.DeclareDefeat();
            }
        }
        this.warHistory.Add($"War {this.warHistory.Count + 1} issued by {nationsType}");
    }//Done

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.warHistory);
    }//Done

}
