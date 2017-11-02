public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    private double height;
    private double width;

    public double Height { get; set; }
    public double Width { get; set; }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Height + this.Width);
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
