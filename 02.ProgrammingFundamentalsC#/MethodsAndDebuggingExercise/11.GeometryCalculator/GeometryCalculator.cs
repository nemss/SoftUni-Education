using System;

class GeometryCalculator
{
    static void Main()
    {
        var geometryFigures = Console.ReadLine();

        PrintAreaFromGeometryFigures(geometryFigures);
    }

    static void PrintAreaFromGeometryFigures(string geometryFigures)
    {
        if (geometryFigures=="triangle")
        {
            Console.WriteLine("{0:F2}", GetTriangleArea());
        }
        else if (geometryFigures=="square")
        {
            Console.WriteLine("{0:F2}", GetSquareArea());
        }
        else if (geometryFigures=="rectangle")
        {
            Console.WriteLine("{0:F2}", GetRectangleArea());
        }
        else if (geometryFigures=="circle")
        {
            Console.WriteLine("{0:F2}", GetCircleArea());
        }
    }

    static double GetCircleArea()
    {
        var radius = double.Parse(Console.ReadLine());
        var area = Math.PI * radius * radius;
        return area;
    }

    static double GetRectangleArea()
    {
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());
        var area = width * height;
        return area;
    }

    static double GetSquareArea()
    {
        var side = double.Parse(Console.ReadLine());
        var area = Math.Pow(side, 2);
        return area;
    }

    static double GetTriangleArea()
    {
        var side = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());
        var area = (side * height) / 2;
        return area;
    }
}