using System;

class PointInFigure
{
    static void Main()
    {
        var x = int.Parse(Console.ReadLine());
        var y = int.Parse(Console.ReadLine());

        if ((4 <= x && x <= 10 && -5<=y && y<=3) || (x>=2 && x<=12 && y>=-3 && y<=1))
        {
            Console.WriteLine("In");
        }
        else
        {
            Console.WriteLine("Out");
        }
        
    }
}