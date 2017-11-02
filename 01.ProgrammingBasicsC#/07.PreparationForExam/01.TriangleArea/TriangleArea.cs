using System;

class TriangleArea
{
    static void Main()
    {
        var x1 = double.Parse(Console.ReadLine());
        var y1 = double.Parse(Console.ReadLine());
        var x2 = double.Parse(Console.ReadLine());
        var y2 = double.Parse(Console.ReadLine());
        var x3 = double.Parse(Console.ReadLine());
        var y3 = double.Parse(Console.ReadLine());
        y2 = y3;
        var a = x2 - x3;
        var h = y1- y3;
        var s = a * h / 2;
        Console.WriteLine(Math.Abs(s));
    }
}

