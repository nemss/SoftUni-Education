using System;

class LongerLine
{
    static void Main()
    {
        var x1 = double.Parse(Console.ReadLine());
        var y1 = double.Parse(Console.ReadLine());

        var x2 = double.Parse(Console.ReadLine());
        var y2 = double.Parse(Console.ReadLine());

        var x3 = double.Parse(Console.ReadLine());
        var y3 = double.Parse(Console.ReadLine());

        var x4 = double.Parse(Console.ReadLine());
        var y4 = double.Parse(Console.ReadLine());

        GetCloserCenter(x1, y1, x2, y2);
        GetCloserCenter2(x3, y3, x4, y4);

        var GetPointToA = GetCloserCenter(x1, y1, x2, y2);
        var GetPointToB = GetCloserCenter2(x3, y3, x4, y4);

        if (GetPointToA> GetPointToB)
        {
            PrintLineA(x1, y1, x2, y2);
        }
        else
        {
            PrintLineB(x3, y3, x4, y4);
        } 

    }

    private static void PrintLineB(double x3, double y3, double x4, double y4)
    {
        var GetPointToA = GetCloserCenter(x3, y3, 0, 0);
        var GetPointToB = GetCloserCenter(x4, y4, 0, 0);
        if (GetPointToA > GetPointToB)
        {
            Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
        }
        else
        {
            Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
        }

    }

    private static void PrintLineA(double x1, double y1, double x2, double y2)
    {
        var GetPointToA = GetCloserCenter(x1, y1, 0, 0);
        var GetPointToB = GetCloserCenter(x2, y2, 0, 0);

        if (GetPointToA > GetPointToB)
        {
            Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
        }
        else
        {
            Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
        }
    }

    private static double GetCloserCenter2(double x3, double y3, double x4, double y4)
    {
        var distance1 = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
        return distance1;
    }

    private static double GetCloserCenter(double x1, double y1, double x2, double y2)
    {
        var distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        return distance;
    }
}