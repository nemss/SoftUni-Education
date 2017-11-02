using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public double GetTotalPower()
    {
        var monumentsAffinity = this.monuments.Sum(m => m.GetAffinity());
        var bendersPower = this.benders.Sum(b => b.GetPower());
        var totalPowerIncrease = (bendersPower / 100) * monumentsAffinity;

        return bendersPower + totalPowerIncrease;
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (this.benders.Any())
        {
            sb.AppendLine("Benders:");
            foreach (var bender in benders)
            {
                sb.AppendLine($"###{bender}");
            }
        }
        else
        {
            sb.AppendLine("Benders: None");
        }


        if (this.monuments.Any())
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in monuments)
            {
                sb.AppendLine($"###{monument}");
            }
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }

        return sb.ToString().Trim();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}

