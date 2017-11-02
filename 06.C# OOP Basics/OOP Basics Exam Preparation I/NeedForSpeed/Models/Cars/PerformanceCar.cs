using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.HorsePower = this.HorsePower + this.HorsePower / 2;
        this.Suspension = this.Suspension - this.Suspension / 4;
        this.addOns = new List<string>();
    }

    public override string ToString()
    {
        var sb = new StringBuilder(base.ToString());
         
        if (this.addOns.Count > 0)
        {
            sb.Append($"Add-ons: {string.Join(", ", addOns)}");
        }
        else
        {
            sb.Append("Add-ons: None");
        }

        return sb.ToString();
    }

    public override void Tune(int tuneIndex, string tuneAddOn)
    {
        base.Tune(tuneIndex, tuneAddOn);
        this.addOns.Add(tuneAddOn);
    }
}
