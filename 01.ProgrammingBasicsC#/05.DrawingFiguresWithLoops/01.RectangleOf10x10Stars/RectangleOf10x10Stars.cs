using System;

class RectangleOf10x10Stars
{
    static void Main()
    {
        var stars = 10;
        for (int i = 0; i < stars; i++)
        {
            Console.WriteLine(new string('*', stars));
        }
    }
}

