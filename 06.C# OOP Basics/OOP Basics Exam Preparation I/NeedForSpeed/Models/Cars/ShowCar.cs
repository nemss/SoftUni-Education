using System.Text;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    private int stars;

    public int Stars
    {
        get { return this.stars; }
        set { this.stars = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder(base.ToString());
        sb.Append($"{this.Stars} *");
        return sb.ToString();
    }

    public override void Tune(int tuneIndex, string tuneAddOn)
    {
        base.Tune(tuneIndex, tuneAddOn);
        this.Stars += tuneIndex;
    }
}

