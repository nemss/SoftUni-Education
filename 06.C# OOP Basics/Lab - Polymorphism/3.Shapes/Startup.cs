using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

public class Startup
{
    public static void Main(string[] args)
    {
        var circle = new Circle(5);
        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.Draw());
    }
}