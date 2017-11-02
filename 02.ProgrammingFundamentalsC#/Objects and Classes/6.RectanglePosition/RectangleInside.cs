using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class RectangleInside
    {
        static void Main()
        {
        var r1 = Rectangle.ReadRectangle();
        var r2 = Rectangle.ReadRectangle();

        Console.WriteLine(Rectangle.isInside(r1,r2) ? "Inside" : "Not inside"); 
        }
    }


class Rectangle
{
    public double Top  { get; set; }

    public double Left { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Bottom
    {
        get
        {
            return this.Top + this.Height;
        }
    }

    public double Right
    {
        get
        {
            return this.Left + this.Width;
        }
    }

    public static Rectangle ReadRectangle()
    {
        var tokens = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        var rect = new Rectangle()
        {
            Left = tokens[0],
            Top = tokens[1],
            Width = tokens[2],
            Height = tokens[3]
        };

        return rect;
    }

    public override string ToString()
    {
        return String.Format("Rect[Top = {0}, Left = {1}, Bottom = {2}, Right = {3}]", this.Left, this.Top, this.Bottom,this.Right);
    }

    public static bool isInside(Rectangle r1, Rectangle r2)
    {
        var inside =
            r1.Left >= r2.Left &&
            r1.Right <= r2.Right &&
            r1.Top >= r2.Top && 
            r1.Bottom <= r2.Bottom;

        return inside;
    }
}

