using System;

class Program
{
    static void Main()
    {
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());
        double area=TriangleArea(width, height);
        Console.WriteLine(area);
    }

    private static double TriangleArea(double width, double height)
    {
        return width * height / 2;
    }
}