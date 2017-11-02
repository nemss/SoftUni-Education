using System;

class AreaOfFigures
{
    static void Main()
    {
        var figures = Console.ReadLine().ToLower();

        if (figures =="square")
        {
            var a=double.Parse( Console.ReadLine());
            var area = a*a;
            Console.WriteLine(Math.Round(area, 3));
        }
        else if (figures =="rectangle")
        {
            var b = double.Parse(Console.ReadLine());
            var c = double.Parse(Console.ReadLine());
            var rectangleArea = b * c;
            Console.WriteLine(Math.Round(rectangleArea, 3));

        }
        else if (figures=="circle")
        {
            var rad = double.Parse(Console.ReadLine());
            var areaCircle = Math.PI * rad * rad;
            Console.WriteLine(Math.Round(areaCircle, 3));
        }
        else if (figures =="triangle")
        {
            var height = double.Parse(Console.ReadLine());
            var weight = double.Parse(Console.ReadLine());
            var areaTriangle = height * weight / 2;
            Console.WriteLine(Math.Round(areaTriangle, 3));
        }
    }
}

