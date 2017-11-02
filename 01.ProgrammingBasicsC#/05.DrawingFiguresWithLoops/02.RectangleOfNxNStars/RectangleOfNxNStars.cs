using System;

class RectangleOfNxNStars
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string('*', n));
        }
    }
}

