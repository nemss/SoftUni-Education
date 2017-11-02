using System;

class CenterPoint
{
    static void Main()
    {
        var x1 = double.Parse(Console.ReadLine());
        var y1 = double.Parse(Console.ReadLine());
        var x2 = double.Parse(Console.ReadLine());
        var y2 = double.Parse(Console.ReadLine());

        var distance = GetDistanceBetweenToPoints(x1, y1, x2, y2);
        var GetPointToA = GetDistanceBetweenToPoints(x1, y1, 0, 0);
        var GetPointToB = GetDistanceBetweenToPoints(x2, y2, 0, 0);
        GetClosestPointToCenter(x1, y1, x2, y2, GetPointToA, GetPointToB);
    }

    private static void GetClosestPointToCenter(double x1, double y1, double x2, double y2, double GetPointToA, double GetPointToB)
    {
        if (GetPointToA > GetPointToB)
        {
            Console.WriteLine($"({x2}, {y2})");
        }
        else
        {
            Console.WriteLine($"({x1}, {y1})");
        }
    }

    private static double GetDistanceBetweenToPoints(double x1, double y1, double x2, double y2)
    {
        var distance = Math.Sqrt(Math.Pow(x2-x1, 2)+Math.Pow(y2-y1, 2));
        return distance;
    }
}