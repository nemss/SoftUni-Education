using System;

class Bricks
{
    static void Main()
    {
        var x = double.Parse(Console.ReadLine());
        var w = double.Parse(Console.ReadLine());
        var m = double.Parse(Console.ReadLine());

        var kursove = w * m;
        var tuhli = x / kursove;
        Console.WriteLine(Math.Ceiling( tuhli));
    }
}

