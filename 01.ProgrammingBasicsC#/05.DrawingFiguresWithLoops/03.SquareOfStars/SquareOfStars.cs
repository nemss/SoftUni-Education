using System;

class SquareOfStars
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int row = 1; row <= n; row++)
        {
            Console.Write("*");
            for (int cow = 1; cow < n; cow++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
            
        }
    }
}

